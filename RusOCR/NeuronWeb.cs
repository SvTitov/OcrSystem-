using System.Drawing;
using System.Linq;

namespace RusOCR
{
    public class NeuronWeb
    {
        #region var

        private readonly byte _charNumber;
        private Neuron[] _neurons;

        #endregion

        #region prop

        public byte CharNumber
        {
            get { return _charNumber; }
        }

        public int StandartHeight
        {
            get { return _neurons.First().Height; }
        }

        public int StandartWidth
        {
            get { return _neurons.First().Width; }
        }

        #endregion

        #region constr

        public NeuronWeb(Languages languages)
        {
            switch (languages)
            {
                case Languages.English:
                {
                    //todo
                    break;
                }
                case Languages.Russian:
                {
                    _charNumber = 33;

                    _neurons = new Neuron[_charNumber];

                    LearnRussian();
                    break;
                }
            }
        }

        #endregion

        #region method

        /// <summary>
        /// Обучение русскомму
        /// Примечание: пока используется верхний регистр
        /// </summary>
        private void LearnRussian()
        {
            for (int i = 0; i < _charNumber; i++)
            {
                _neurons[i] = new Neuron();
                _neurons[i].Output = 0;

                // пробегаемся по алфавиту
                _neurons[i].Name = ('A' + i).ToString();
                _neurons[i].TeachNeuron(Image.FromFile($@"russian/{_neurons[i].Name}.png"));
            }
        }

        #endregion
    }
}