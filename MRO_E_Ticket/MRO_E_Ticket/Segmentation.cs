using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Model;
using MRO_E_Ticket.Enum;
using MRO_E_Ticket.Domain;
using System.Drawing;

namespace MRO_E_Ticket
{
    public class Segmentation
    {
        private MRO_E_Ticket.Domain.ImageConverter imageConverter;
        private TransformationForTheHistogram transform = new TransformationForTheHistogram();
        private List<ParametersForGistogram> full = new List<ParametersForGistogram>();
        private List<ParametersForGistogram> parametersList = new List<ParametersForGistogram>();

        private int[,] imageArray;

        public Segmentation(int[,] array, List<ParametersForGistogram> list)
        {
            imageArray = array;
            parametersList = list;
        }

        public int[,] RemoveUpAndDownElementImage(List<ParametersForGistogram> list, int[,] array)
        {
            //max sum black pixel
            int maxCountBlackPixel = list.Max(x => x.TheТumberOfPixels);
            //limit height histogram
            int LimitsImageHeigth = parametersList.Count / 2;
            int paramsForRemovingUp = IndexMaxValueHistogram(parametersList, maxCountBlackPixel, LimitsImageHeigth);
            var resultArrayAfterRemoving = ArrayAfterCleanUP(array, paramsForRemovingUp);
            //revers list for removing down
            var listParamsRevers = parametersList.Reverse<ParametersForGistogram>().ToList();
            int paramsForRemovingDown = IndexMaxValueHistogram(listParamsRevers, maxCountBlackPixel, LimitsImageHeigth);
            var resultArrayAfterAllRemoving = ArrayAfterCleanUDown(resultArrayAfterRemoving, paramsForRemovingDown);
            imageArray = resultArrayAfterAllRemoving;
            return resultArrayAfterAllRemoving;
        }

        //receiving the end of the maximum value of the index histograms
        private int IndexMaxValueHistogram(List<ParametersForGistogram> parametersList, int maxValueHostrogramm, int searchLimit)
        {
            int step = 0;
            int valueIndex = 0;
            foreach (var item in parametersList)
            {
                step++;
                if (item.TheТumberOfPixels >= maxValueHostrogramm / 2 && step <= searchLimit)
                {
                    valueIndex = step;
                }

            }
            return valueIndex;
        }

        //removing unnecessary information from the top
        private int[,] ArrayAfterCleanUP(int[,] array, int indexMaxValueHistogram)
        {
            int widthArray = array.GetLength(0);
            int heigthArray = array.GetLength(1);
            int newHeigth = heigthArray - indexMaxValueHistogram;
            int[,] bufferArray = new int[widthArray, newHeigth];
            for (int i = 0; i < widthArray; i++)
            {
                for (int j = indexMaxValueHistogram; j < heigthArray; j++)
                {
                    bufferArray[i, j - indexMaxValueHistogram] = array[i, j];
                }
            }
            return bufferArray;
        }

        //removing unnecessary information from the down
        private int[,] ArrayAfterCleanUDown(int[,] array, int indexMaxValueHistogram)
        {
            int widthArray = array.GetLength(0);
            int heigthArray = array.GetLength(1);
            int[,] bufferArray = new int[widthArray, heigthArray - indexMaxValueHistogram];

            for (int i = 0; i < widthArray; i++)
            {
                for (int j = 0; j < heigthArray - indexMaxValueHistogram; j++)
                {
                    bufferArray[i, j] = array[i, j];
                }
            }
            return bufferArray;
        }

        //remove informations lines (vertical)
        public int[,] SelectionOfAreas()
        {
            bool startCount = true;
            int step = 0;
            int startposition = 0;
            int endposition = 0;
            var resList = transform.Parameters(imageArray);

            foreach (var item in resList)
            {
                if (item.TheТumberOfPixels != 0)
                {
                    if (startCount == true)
                    {
                        startposition = step;
                        startCount = false;
                    }
                    else
                    {
                        endposition = step;
                    }

                }
                if (item.TheТumberOfPixels == 0)
                {
                    full.Add(new ParametersForGistogram(item.TheТumberOfPixels, startposition, endposition));
                    startCount = true;
                    startposition = 0;
                    endposition = 0;
                }
                step++;
            }
            var ara = full.Max(x => x.WidthPixels);
            int[,] bufferArray = new int[imageArray.GetLength(0), ara];
            foreach (var item in full)
            {
                if (item.WidthPixels == ara)
                {
                    int jOne = item.StartPositionPixel;
                    int jTwo = item.EndPositionPixel;

                    for (int i = 0; i < imageArray.GetLength(0); i++)
                    {
                        for (int j = jOne; j < imageArray.GetLength(1); j++)
                        {
                            if (j < jTwo)
                            {
                                bufferArray[i, j - jOne] = imageArray[i, j];
                            }
                        }

                    }
                }
            }
            return bufferArray;
        }

        //remove informations lines (horizontal) and remove border
        public int[,] SelectionOfAreasInHorizontalImage(List<ParametersForGistogram> list, int[,] array)
        {
            bool startCount = true;
            int step = 0;
            int startposition = 0;
            int endposition = 0;
            var resList = list;

            foreach (var item in resList)
            {
                if (item.TheТumberOfPixels != 0)
                {
                    if (startCount == true)
                    {
                        startposition = step;
                        startCount = false;
                    }
                    else
                    {
                        endposition = step;
                    }

                }
                if (item.TheТumberOfPixels == 0)
                {
                    full.Add(new ParametersForGistogram(item.TheТumberOfPixels, startposition, endposition));
                    startCount = true;
                    startposition = 0;
                    endposition = 0;
                }
                step++;
            }
            int border = 5;
            var arrayWidth = full.Max(x => x.WidthPixels);
            int[,] bufferArray = new int[arrayWidth - (border * 2), array.GetLength(1) - (border * 2)];

            foreach (var item in full)
            {
                if (item.WidthPixels == arrayWidth)
                {
                    //start and end posotion
                    int jOne = item.StartPositionPixel;
                    int jTwo = item.EndPositionPixel - border;

                    for (int i = jOne + border; i < array.GetLength(0) - border; i++)
                    {
                        for (int j = border; j < array.GetLength(1) - border; j++)
                        {
                            if (i < jTwo)
                            {
                                bufferArray[i - (jOne + border), j - border] = array[i, j];
                            }
                        }

                    }
                }
            }
            return bufferArray;
        }

        //get image numbers
        public List<ImageCollection> GetCollectionofImage(List<ParametersForGistogram> list, int[,] array)
        {
            List<ImageCollection> collection = new List<ImageCollection>();
            List<ParametersForGistogram> paramsForImage = new List<ParametersForGistogram>();
            bool startCount = true;
            int step = 0;
            int startposition = 0;
            int endposition = 0;
            var resList = list;

            foreach (var item in resList)
            {
                if (item.TheТumberOfPixels != 0)
                {
                    if (startCount == true)
                    {
                        startposition = step;
                        startCount = false;
                    }
                    else
                    {
                        endposition = step;
                    }
                }
                if (item.TheТumberOfPixels == 0)
                {
                    paramsForImage.Add(new ParametersForGistogram(item.TheТumberOfPixels, startposition, endposition));
                    startCount = true;
                    startposition = 0;
                    endposition = 0;
                }
                step++;
            }

            int numberName = 0;
            int[,] bufferArray;

            foreach (var item in paramsForImage)
            {
                bufferArray = null;
                if (item.WidthPixels != 0)
                {
                    imageConverter = new MRO_E_Ticket.Domain.ImageConverter();
                    int jOne = item.StartPositionPixel;
                    int jTwo = item.EndPositionPixel;
                    bufferArray = new int[item.WidthPixels, array.GetLength(1)];
                    for (int i = jOne; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < bufferArray.GetLength(1); j++)
                        {
                            if (i < jTwo)
                            {
                                bufferArray[i - jOne, j] = array[i, j];
                            }
                        }
                    }
                    numberName++;
                    collection.Add(new ImageCollection(numberName.ToString(), imageConverter.CreateBitmap(bufferArray)));
                }
            }
            return collection;
        }
    }
}
