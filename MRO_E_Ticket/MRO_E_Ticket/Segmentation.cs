using System.Collections.Generic;
using System.Linq;
using MRO_E_Ticket.Model;
using MRO_E_Ticket.Enum;
using MRO_E_Ticket.Domain;
using System.Windows.Forms;

namespace MRO_E_Ticket
{
    public class Segmentation
    {
        private MRO_E_Ticket.Domain.ImageConverter imageConverter;
        private TransformationForTheHistogram transform = new TransformationForTheHistogram();
        private List<ParametersForGistogram> full = new List<ParametersForGistogram>();
        private List<ParametersForGistogram> parametersList = new List<ParametersForGistogram>();
        private readonly int SizeNumberImage = 80;
        private int[,] imageArray;

        public Segmentation(int[,] array, List<ParametersForGistogram> list)
        {
            imageArray = array;
            parametersList = list;
        }
        //
        public int[,] RemoveUpAndDownElementImage(List<ParametersForGistogram> list, int[,] array)
        {
            //max sum black pixel
            int maxCountBlackPixel = list.Max(x => x.TheТumberOfPixels);
             if(maxCountBlackPixel< 1000)
            {
                maxCountBlackPixel = 1000;
            }
            
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
            var resList = transform.Parameters(imageArray);
            full = ReturnParamsList(resList);
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
        public int[,] SelectionOfAreasInHorizontalImage(List<ParametersForGistogram> list, int[,] array, int border=4)
        {
            full = ReturnParamsList(list);
            int arrayWidth = 0;
            try
            {
               arrayWidth = full.Max(x => x.WidthPixels);
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show("Что-то не так. Попробуйте изменить порог бинаризации");
                return null;
            }
            int[,] bufferArray = new int[arrayWidth - (border * 2) + 1, array.GetLength(1) - (border * 2)];

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
            //It takes into account the latest pixel
            int additionalPixel = 2;
            int[,] cleanArray = RemoveBorder(array);
            paramsForImage = ReturnParamsList(list);

            int numberName = 0;
            int[,] bufferArray;

            foreach (var item in paramsForImage)
            {
                bufferArray = null;
                //check only the black band
                if (item.WidthPixels > 0)
                {
                    imageConverter = new MRO_E_Ticket.Domain.ImageConverter();
                    int jOne = item.StartPositionPixel;
                    int jTwo = item.EndPositionPixel + additionalPixel;
                    bufferArray = new int[item.WidthPixels + additionalPixel, cleanArray.GetLength(1)];

                    for (int i = jOne; i < cleanArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < cleanArray.GetLength(1); j++)
                        {
                            if (i < jTwo)
                            {
                                bufferArray[i - jOne, j] = cleanArray[i, j];
                            }
                        }
                    }
                    //create matrix equal size 
                    var extensionMatrix = ExtensionMatrix(bufferArray);
                    //for different name
                    numberName++;
                    collection.Add(new ImageCollection(numberName.ToString(), imageConverter.CreateBitmap(extensionMatrix)));
                }
            }
            return collection;
        }
        //return params image for segmentation
        public List<ParametersForGistogram> ReturnParamsList(List<ParametersForGistogram> initialList)
        {
            List<ParametersForGistogram> obtained = new List<ParametersForGistogram>();
            //start counting
            bool startCount = true;
            //counter
            int step = 0;
            //start black pixel position
            int startposition = 0;
            //end black pixel position
            int endposition = 0;

            foreach (var item in initialList)
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
                    obtained.Add(new ParametersForGistogram(item.TheТumberOfPixels, startposition, endposition));
                    startCount = true;
                    startposition = 0;
                    endposition = 0;
                }
                step++;
            }
            return obtained;
        }
        //fill array image white color
        private int[,] FillArray()
        {
            int[,] arrayInput = new int[SizeNumberImage, SizeNumberImage];
            for (int i = 0; i < arrayInput.GetLength(0); i++)
            {
                for (int j = 0; j < arrayInput.GetLength(1); j++)
                {
                    arrayInput[i, j] = (byte)BinarizationColorPixel.White;
                }
            }
            return arrayInput;
        }
        //extension array
        public int[,] ExtensionMatrix(int[,] miniArray, int Size = 80)
        {
            int[,] maxArray = new int[Size, Size];
            //required matrix size
            int widthMaxyArray = Size;
            int heigthMaxyiArray = Size;
            if (miniArray.GetLength(0) <= Size)
            {
                int widthMiniArray = miniArray.GetLength(0);
                int heigthMiniArray = miniArray.GetLength(1);
                //count cycle start
                int startLeftCycle = widthMaxyArray / 2 - widthMiniArray / 2;
                int startUpCycle = heigthMaxyiArray / 2 - heigthMiniArray / 2;

                int[,] arrayInput = new int[maxArray.GetLength(0), maxArray.GetLength(1)];
                //fill array white color
                arrayInput = FillArray();

                for (int i = startLeftCycle; i < widthMaxyArray - startLeftCycle; i++)
                {
                    for (int j = startUpCycle; j < heigthMiniArray; j++)
                    {
                        arrayInput[i, j] = miniArray[i - startLeftCycle, j - 1];
                    }
                }
                maxArray = arrayInput;
            }
            return maxArray;
        }

        public int[,] RemoveBorder(int[,] array)
        {
            int[,] newArray = null;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j <= 4)
                    {
                        array[i, j] = 255;
                    }
                    if (j >= array.GetLength(1) - 4)
                    {
                        array[i, j] = 255;
                    }
                    if (i <= 1)
                    {
                        array[i, j] = 255;
                    }
                    if (i >= array.GetLength(0) - 1)
                    {
                        array[i, j] = 255;
                    }

                }
            }
            if (array.GetLength(0) > 50)
            {
                newArray = new int[array.GetLength(0), array.GetLength(1) - 1];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1) - 1; j++)
                    {
                        newArray[i, j] = array[i, j];
                    }
                }
            }


            return newArray;
        }
    }
}
