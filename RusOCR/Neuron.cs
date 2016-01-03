using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Math;

namespace RusOCR
{
    public class Neuron
    {
        #region var

        private readonly int _firstrIndex = 30;
        private readonly int _secondIndex = 30;

        private string _name;
        private int[,] _input;
        private int _output;
        private int[,] _memory;

        #endregion


        #region prop
        public int[,] Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set { _name = value; }
        }

        public int FirstrIndex
        {
            get { return _firstrIndex; }
        }

        public int SecondIndex
        {
            get { return _secondIndex; }
        }

        #endregion


        #region constr
        /// <summary>
        /// КонструкторЬЩ
        /// </summary>
        public Neuron()
        {
            Initialize();
        }

        #endregion


        #region methods
        public void TeachNeuron(System.Drawing.Image image)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    var pix = ((Bitmap) image).GetPixel(i, j);
                    int value = (pix.B + pix.G + pix.R)/3;

                    // вычисляем разницу между полученными значениями
                    if (_memory[i,j] == -1)
                    {
                        _memory[i, j] = value;
                    }
                    else
                    {
                        // вычисление среднего значения между точками (memory = 100 value = 130, срз = 115)
                        _memory[i, j] += ((_memory[i,j] - value)/2) * -1;
                    }

                }
            }
        }

        public void PrintToPng()
        {
            Bitmap bitmapToSave = new Bitmap(30,30);

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    bitmapToSave.SetPixel(i,j, Color.FromArgb(_memory[i,j], _memory[i, j], _memory[i, j]));
                }
            }

            bitmapToSave.Save($@"result/{this.Name}.png");
        }

        private void Initialize()
        {
            this._input = new int[_firstrIndex, _secondIndex];
            this._memory = new int[_firstrIndex, _secondIndex];

            // заполняем память -1, для пустого значения
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    _memory[i, j] = -1;
                }
            }
        }

        #endregion
    }
}