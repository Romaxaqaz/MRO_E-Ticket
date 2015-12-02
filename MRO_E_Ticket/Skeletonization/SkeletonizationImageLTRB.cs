using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Domain;

namespace Skeletonization
{
    public class SkeletonizationImageLTRB
    {
        private MRO_E_Ticket.Domain.ImageConverter imageConverter = new MRO_E_Ticket.Domain.ImageConverter();

        int[,] resitlArray;

        public Bitmap SkeletizationRun(Bitmap bitmap)
        {
            var imageArray = imageConverter.GetImageArray(bitmap);
            resitlArray = imageArray;

            for (int i = 0; i < 3; i++)
            {
                LeftStep();
            }
            return imageConverter.CreateBitmap(resitlArray);
        }

        private void LeftStep()
        {
            for (int i = 0; i < resitlArray.GetLength(0); i++)
            {
                for (int j = 0; j < resitlArray.GetLength(1); j++)
                {
                    if (resitlArray[i, j] == 1)
                    {
                        if (resitlArray[i, j+1] == 0)
                        {
                            resitlArray[i, j] = 0;
                        }

                    }
                }
            }
        }

        private bool TopStep(int[,] array)
        {
            bool result = true;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[j + 1, i] == 1 && array[j, i] == 0)
                    {
                        if (array[j + 2, i] == 1)
                        {
                            array[j + 1, i] = 0;
                        }
                    }
                }
            }
            return result;
        }
    }
}
