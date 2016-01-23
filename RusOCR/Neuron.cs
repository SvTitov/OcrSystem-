using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Math;

namespace RusOCR
{
    public class Neuron
    {
        #region var

        private readonly int _height = 30;
        private readonly int _width = 30;

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

        public int Height
        {
            get { return _height; }
        }

        public int Width
        {
            get { return _width; }
        }

        #endregion


        #region constr
        /// <summary>
        /// Конструктор
        /// </summary>
        public Neuron()
        {
            Initialize();
        }

        #endregion


        #region methods
        public void TeachNeuron(System.Drawing.Image image)
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
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
            this._input = new int[_height, _width];
            this._memory = new int[_height, _width];

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