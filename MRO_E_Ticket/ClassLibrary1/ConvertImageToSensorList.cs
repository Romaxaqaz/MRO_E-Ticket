using PerceptronLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLib.Enum;

namespace PerceptronLib
{
    public class ConvertImageToSensorList
    {
        private List<Sensors> sensorCollection = new List<Sensors>();

        public List<Sensors> GetSensorList(Bitmap bmp)
        {
            sensorCollection.Clear();
            int counterPixel = 0;
            for (int i = 0; i < (bmp.Width); i++)
            {
                for (int j = 0; j < (bmp.Height); j++)
                {
                    if (ColorPixelBlack(bmp, i, j))
                    {
                        sensorCollection.Add(new Sensors((byte)PixelColor.Black, counterPixel));
                        counterPixel++;
                    }
                    else
                    {
                        sensorCollection.Add(new Sensors((byte)PixelColor.White, counterPixel));
                        counterPixel++;
                    }
                }
            }
            return sensorCollection;
        }

        private bool ColorPixelBlack(Bitmap bmp, int i, int j)
        {
            bool result = false;
            if (bmp.GetPixel(i, j).A.ToString() == "255" &&
                bmp.GetPixel(i, j).B.ToString() == "255" &&
                bmp.GetPixel(i, j).G.ToString() == "255" &&
                bmp.GetPixel(i, j).R.ToString() == "255")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
