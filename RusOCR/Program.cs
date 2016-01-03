using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RusOCR
{
    class Program
    {
        static void Main(string[] args)
        {
#region TEST
            //Neuron[] neuron_web = new Neuron[32];

            //for (int i = 0; i < 32; i++)
            //{
            //    neuron_web[i] = new Neuron();
            //    //neuron_web[i].output = 0;
            //    neuron_web[i].Name = Convert.ToChar(('А' + i)).ToString();

            //    var image = Bitmap.FromFile($@"res/{neuron_web[i].Name}.png");

            //    neuron_web[i].TeachNeuron(image);
            //}

            //Neuron neuron = new Neuron();
            //neuron.Name = "А";


            //var files = Directory.GetFiles("fonts/");

            //foreach (var file in files)
            //{
            //    var image = Bitmap.FromFile($@"{file}");
            //    neuron.TeachNeuron(image);

            //}

            //neuron.PrintToPng();
#endregion

            Ocr ocr = new Ocr(Bitmap.FromFile("hello.png"));

            ocr.FindKeyA();
            //ocr.FindTextBox(Bitmap.FromFile("hello.png"));
            Console.ReadKey(true);
        }
    }
}
