using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Model;
using MRO_E_Ticket.Enum;

namespace MRO_E_Ticket.Domain
{
    public class TransformationForTheHistogram
    {
        private List<ParametersForGistogram> listParameters;

        //get params for histrogramm (vertical)
        public List<ParametersForGistogram> Parameters(int[,] imageArray)
        {
            listParameters = new List<ParametersForGistogram>();
            int widthArray = imageArray.GetLength(0);
            int heigthhArray = imageArray.GetLength(1);

            int[,] simmElements = new int[widthArray, heigthhArray];
            int[] buffer = new int[heigthhArray];
            int buffeCont = 0;

            for (int i = 0; i < (heigthhArray); i++)
            {
                for (int j = 0; j < (widthArray); j++)
                {
                    if (imageArray[j, i] == (byte)BinarizationColorPixel.Black)
                    {
                        buffeCont++;
                    }
                }
                listParameters.Add(new ParametersForGistogram(buffeCont));
                buffeCont = 0;
            }
            return listParameters;
        }

        //get params for histrogramm (horizontal)
        public List<ParametersForGistogram> HorizontalImageGetParameters(int[,] imageArray)
        {
            listParameters = new List<ParametersForGistogram>();
            int widthArray = imageArray.GetLength(0);
            int heigthhArray = imageArray.GetLength(1);

            int[,] simmElements = new int[widthArray, heigthhArray];
            int[] buffer = new int[heigthhArray];
            int buffeCont = 0;

            for (int i = 0; i < (widthArray); i++)
            {
                for (int j = 0; j < (heigthhArray); j++)
                {
                    if (imageArray[i, j] == (byte)BinarizationColorPixel.Black)
                    {
                        buffeCont++;
                    }
                }
                listParameters.Add(new ParametersForGistogram(buffeCont));
                buffeCont = 0;
            }
            return listParameters;
        }


    }
}
