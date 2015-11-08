using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Model;

namespace MRO_E_Ticket
{
    public class Segmentation
    {
        List<ParametersForGistogram> full = new List<ParametersForGistogram>();
        public int[,] Fullparameters(List<ParametersForGistogram> list, int[,] array)
        {
            int maxCountBlackPixel = list.Max(x => x.TheТumberOfPixels);
            bool startCount = true;
            bool endCount = false;
            int a = 0;
            int step = 0;
            int startposition = 0;
            int endposition = 0;
            var ar = list.ToArray();

            foreach (var item in list)
            {
                if(item.TheТumberOfPixels > maxCountBlackPixel / 2)
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                            array[i, step] = 255;
                            array[i, step] = 255;
                    }
                }
                step++;
            }
            return array;
        }
    }
}
