using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Enum;
using MRO_E_Ticket.BitmapLib;
using MRO_E_Ticket.Model;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MRO_E_Ticket.Domain
{
    public class ImageConverter
    {
        #region Constant For The Equation
        private readonly double x1 = 0.299;
        private readonly double x2 = 0.587;
        private readonly double x3 = 0.114;
        #endregion
        private Segmentation segment = new Segmentation(null, null);
        private TransformationForTheHistogram transformation = new TransformationForTheHistogram();
        private readonly string TransferToGrayscaleProvess = "Transfer To Grayscale Image";
        private readonly string BinarizationThresholdMethod = "Binarization Image";
        private int binarizationThreshold = 160;
        private int HeigthBarcode = 110;

        public int BinarizationThreshold { get { return binarizationThreshold; } set { binarizationThreshold = value; } }

        #region EventSetting
        public delegate void dlgProgress(int value, int maxValue, string processName);
        public event dlgProgress Progress;
        #endregion

        #region Transfer To Grayscale
        //tranfer to grayscale and return bitmap
        public Bitmap TransferToGrayscaleGetBitmap(Bitmap bitmap)
        {
            FastBitmap fastBitmap = new FastBitmap(bitmap);
            fastBitmap.LockImage();
            int sizeWidth = bitmap.Width;
            int sizeHeigh = bitmap.Height;
            int[,] ArrayForImage = new int[sizeWidth, sizeHeigh];
            for (int i = 0; i < sizeWidth; i++)
            {
                for (int j = 0; j < sizeHeigh; j++)
                {
                    Color oldPixel = fastBitmap.GetPixel(i, j);
                    ArrayForImage[i, j] = GrayscalePixel(
                        oldPixel.R,
                        oldPixel.G,
                        oldPixel.B);
                }
                if (Progress != null)
                {
                    Progress(i, sizeWidth, TransferToGrayscaleProvess);
                }
            }
            fastBitmap.UnlockImage();
            return CreateBitmapGray(ArrayForImage);
        }
        //tranfer to grayscale and return array
        public int[,] TransferToGrayscaleGetArray(Bitmap bitmap)
        {
            FastBitmap fastBitmap = new FastBitmap(bitmap);
            fastBitmap.LockImage();
            int sizeWidth = bitmap.Width;
            int sizeHeigh = bitmap.Height;
            int[,] ArrayForImage = new int[sizeWidth, sizeHeigh];
            for (int i = 0; i < sizeWidth; i++)
            {
                for (int j = 0; j < sizeHeigh; j++)
                {
                    ArrayForImage[i, j] = GrayscalePixel(
                       fastBitmap.GetPixel(i, j).R,
                        fastBitmap.GetPixel(i, j).G,
                        fastBitmap.GetPixel(i, j).B);
                }
            }
            fastBitmap.UnlockImage();
            return ArrayForImage;
        }

        private int GrayscalePixel(int R, int G, int B)
        {
            double Y = x1 * R + x2 * G + x3 * B;
            return (int)Y;
        }
        #endregion

        #region Binarization
        //binarization and return array
        public int[,] BinarizationThresholdMethodGetArray(Bitmap bitmap)
        {
            FastBitmap fastBitmap = new FastBitmap(bitmap);
            fastBitmap.LockImage();
            int sizeWidth = bitmap.Width;
            int sizeHeigh = bitmap.Height;
            int[,] ArrayForBinarizationImage = new int[sizeWidth, sizeHeigh];
            for (int i = 0; i < sizeWidth; i++)
            {
                for (int j = 0; j < sizeHeigh; j++)
                {
                    ArrayForBinarizationImage[i, j] = ResultPixelColorAfterBinarization(fastBitmap.GetPixel(i, j).R);
                }
            }
            fastBitmap.UnlockImage();
            return ArrayForBinarizationImage;
        }
        //binarization and return Bitmap
        public Bitmap BinarizationThresholdMethodGetBitmap(Bitmap bitmap)
        {
            FastBitmap fastBitmap = new FastBitmap(bitmap);
            fastBitmap.LockImage();
            int sizeWidth = bitmap.Width;
            int sizeHeigh = bitmap.Height;
            int[,] ArrayForBinarizationImage = new int[sizeWidth, sizeHeigh];
            for (int i = 0; i < sizeWidth; i++)
            {
                for (int j = 0; j < sizeHeigh; j++)
                {
                    ArrayForBinarizationImage[i, j] = ResultPixelColorAfterBinarization(fastBitmap.GetPixel(i, j).R);
                }
                if (Progress != null)
                {
                    Progress(i, bitmap.Width, BinarizationThresholdMethod);
                }
            }
            fastBitmap.UnlockImage();
            return CreateBitmap(ArrayForBinarizationImage);
        }

        private byte ResultPixelColorAfterBinarization(int R)
        {
            byte resultColor = 0;
            if (R <= binarizationThreshold)
            {
                resultColor = (byte)BinarizationColorPixel.Black;
            }
            else
            {
                resultColor = (byte)BinarizationColorPixel.White;
            }
            return resultColor;
        }
        #endregion

        #region Create Bitmap
        public Bitmap CreateBitmap(int[,] arrayImage)
        {
            
            int widthImage = arrayImage.GetLength(0);
            int heigthImage = arrayImage.GetLength(1);
            Bitmap halfBitmap = new Bitmap(widthImage, heigthImage);
            FastBitmap fastBitmap = new FastBitmap(halfBitmap);
            fastBitmap.LockImage();
            int ScalePixel = 0;
            for (int i = 0; i < widthImage; i++)
            {
                for (int j = 0; j < heigthImage; j++)
                {
                    ScalePixel = arrayImage[i, j];
                    //verification value pixel for set color
                    if (ScalePixel == 1) { ScalePixel = 255; }
                    fastBitmap.SetPixel(i, j, Color.FromArgb(ScalePixel, ScalePixel, ScalePixel));
                }
            }
            fastBitmap.UnlockImage();

            return halfBitmap;
        }
        //create gray image
        public Bitmap CreateBitmapGray(int[,] arrayImage)
        {
            int widthImage = arrayImage.GetLength(0);
            int heigthImage = arrayImage.GetLength(1);
            Bitmap halfBitmap = new Bitmap(widthImage, heigthImage);
            FastBitmap fastBitmap = new FastBitmap(halfBitmap);
            fastBitmap.LockImage();
            int ScalePixel = 0;
            for (int i = 0; i < widthImage; i++)
            {
                for (int j = 0; j < heigthImage; j++)
                {
                    ScalePixel = arrayImage[i, j];
                    fastBitmap.SetPixel(i, j, Color.FromArgb(ScalePixel, ScalePixel, ScalePixel, ScalePixel));
                }
            }
            fastBitmap.UnlockImage();
            return halfBitmap;
        }
        #endregion

        #region Image Array
        //return matrix image
        public int[,] GetImageArray(Bitmap bitmap)
        {
            FastBitmap fastBitmap = new FastBitmap(bitmap);
            fastBitmap.LockImage();
            int[,] ArrayForBinarizationImage = new int[bitmap.Width, bitmap.Height];
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    Color oldPixel = fastBitmap.GetPixel(i, j);
                    ArrayForBinarizationImage[i, j] = ColorPixel(
                        oldPixel.A,
                        oldPixel.R,
                        oldPixel.G,
                        oldPixel.B);
                }
            }
            fastBitmap.UnlockImage();
            return ArrayForBinarizationImage;
        }
        //chek pixel value
        private int ColorPixel(int a, int r, int g, int b)
        {
            int result = 0;
            if (r == 255 && g == 255 &&
                b == 255 && a == 255)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region ImageRotation
        public double GetAngleImage(Bitmap bmp)
        {
            List<ParametersForGistogram> paramsList = new List<ParametersForGistogram>();
            int topDelete = 0;
            int buttomDelete = bmp.Height / 2;
            int startBarcode = 0;
            int endBarcode = 0;
            int widthFirstLines = 0;

            int[,] imageArray = GetImageArray(bmp);
            int[,] newImageArray = new int[imageArray.GetLength(0), imageArray.GetLength(1) - (topDelete + buttomDelete)];
            //create new array which remove top page
            for (int i = 0; i < imageArray.GetLength(0); i++)
            {
                for (int j = topDelete; j < imageArray.GetLength(1) - buttomDelete; j++)
                {
                    newImageArray[i, j - topDelete] = imageArray[i, j];
                }
            }
            var CountPixelinEachRowList = transformation.Parameters(newImageArray);
            var paramsSegmentList = segment.ReturnParamsList(CountPixelinEachRowList);
            int maxWidth = 0;
            try
            {
                //search barcode
                maxWidth = paramsSegmentList.Max(x => x.WidthPixels);
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show("Что-то не так. Попробуйте уменьшить порог бинаризации.");
                return 0;
            }

            //set start and end position barcode
            foreach (var item in paramsSegmentList)
            {
                if (item.WidthPixels == maxWidth)
                {
                    startBarcode = item.StartPositionPixel + topDelete;
                    endBarcode = item.EndPositionPixel + topDelete;
                }
            }
            int[,] newImageArrayNEW = new int[imageArray.GetLength(0), maxWidth];
            for (int i = 0; i < imageArray.GetLength(0); i++)
            {
                for (int j = startBarcode; j < endBarcode; j++)
                {
                    newImageArrayNEW[i, j - startBarcode] = imageArray[i, j];
                }
            }

            var paramsForHistogrammNewImage = transformation.HorizontalImageGetParameters(newImageArrayNEW);
            var miniArray = segment.SelectionOfAreasInHorizontalImage(paramsForHistogrammNewImage, newImageArrayNEW, 0);

            ImageFormat format = ImageFormat.Bmp;
            var bit = CreateBitmap(miniArray);

            bit.Save("test2" + ".bmp", format);

            int startJ = StartJPosition(miniArray);
            startJ = startJ - 1;
            bool minus = false;

            //
            int height = 0;
            for (int i = 3; i < miniArray.GetLength(0); i++)
            {
                if (startJ > 0)
                {
                    if (miniArray[i, startJ] == 1 && miniArray[i + 1, startJ] == 0)
                    {
                        height++;
                        startJ--;
                    }
                }
            }
            if (height < 1)
            {
                height = 0;
                if (startJ < 0) { startJ = 0; }
                for (int i = 0; i < miniArray.GetLength(0); i++)
                {
                    if (miniArray[i, startJ] == 1 && miniArray[i + 1, startJ] == 1)
                    {
                        if (miniArray[i, startJ + 1] == 0)
                        {
                            height++;
                            startJ++;
                        }
                    }
                }
                minus = true;
            }
            var angle = 90 - (Math.Atan(miniArray.GetLength(0) / Math.Abs(height + 3)) * (180 / Math.PI));
            if(angle > 3) { angle = 0; MessageBox.Show("Что-то не так. Попробуйте увеличить порог бинаризации."); }
            if(minus)
            {
                angle = angle * -1;
            }
            return angle;
        }


        private int StartJPosition(int[,] array)
        {
            int startJ = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        startJ = j;
                        break;
                    }
                }
            }
            return startJ;
        }

        private int StartUpPixels(int[,] imageArray, int startJposition)
        {
            int x = 0;
            for (int i = 0; i < imageArray.GetLength(0) / 2; i++)
            {
                if (imageArray[i, startJposition + 2] == 0)
                {
                    x = i;
                    break;
                }
            }
            return x;
        }

        private int[] GetTheFirstBlackPosition2(int[,] array, int jStartBarCode, int jEndBarCode)
        {
            int[] resultPosition = new int[2];
            int oldI = array.GetLength(0) - 1;
            int oldJ = array.GetLength(1) - 1;
            int counterRepeatI = 0;
            bool counterRepeat = true;
            //If a very large steering angle

            //going from top to bottom and and 
            //if the value is less than it was before, the reserve position
            for (int j = jStartBarCode; j < jEndBarCode; j++)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (array[i, j] == 0)
                    {
                        if (i < oldI && counterRepeat)
                        {
                            oldI = i;
                            oldJ = j;
                            counterRepeatI = 0;
                            break;
                        }
                        if (i == oldI)
                        {
                            counterRepeatI++;
                        }
                        if (counterRepeatI > 5)
                        {
                            counterRepeat = false;
                        }
                    }
                }
            }
            // +1 to allow a black pixel
            resultPosition[0] = oldI;
            resultPosition[1] = oldJ + 1;
            return resultPosition;
        }

        private int GeRightDistanceToThePexel(int[,] imageArray, int startFirstPixelX, int startPixelY, int maxHeigthBarCode = 105)
        {
            int counterPixelDistance = 0;
            if (imageArray[startFirstPixelX + 1, startPixelY - maxHeigthBarCode] == 1)
            {
                while (imageArray[startFirstPixelX, startPixelY - maxHeigthBarCode] != 0)
                {
                    if (startFirstPixelX < imageArray.GetLength(0))
                    {
                        counterPixelDistance++;
                        startFirstPixelX++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //если справа черный пиксель, пока не белый считаем
            else
            {
                while (imageArray[startFirstPixelX, startPixelY - maxHeigthBarCode] != 1)
                {
                    counterPixelDistance++;
                    startFirstPixelX++;
                }
                counterPixelDistance--;
            }
            return counterPixelDistance;
        }

        private int GeLeftDistanceToThePexel(int[,] imageArray, int startFirstPixelX, int startPixelY, int maxHeigthBarCode = 105)
        {
            int counterPixelDistance = 0;

            if (imageArray[startFirstPixelX - 1, startPixelY - maxHeigthBarCode] == 1)
            {
                while (imageArray[startFirstPixelX, startPixelY - maxHeigthBarCode] != 0)
                {
                    if (startFirstPixelX > 0)
                    {
                        startFirstPixelX--;
                        counterPixelDistance++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //если справа черный пиксель, пока не белый считаем
            else
            {
                while (imageArray[startFirstPixelX, startPixelY - maxHeigthBarCode] != 1)
                {
                    counterPixelDistance++;
                    startFirstPixelX--;
                }
                counterPixelDistance--;
            }
            return counterPixelDistance;
        }

        private int[] GetTheFirstBlackPosition(int[,] array, int jStartBarCode, int jEndBarCode)
        {
            int[] resultPosition = new int[2];
            int oldI = array.GetLength(0) - 1;
            int oldJ = array.GetLength(1) - 1;
            int counterRepeatI = 0;
            bool counterRepeat = true;
            //If a very large steering angle

            //going from top to bottom and and 
            //if the value is less than it was before, the reserve position
            for (int j = jEndBarCode; j > jStartBarCode; j--)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (array[i, j] == 0)
                    {
                        if (i < oldI && counterRepeat)
                        {
                            oldI = i;
                            oldJ = j;
                            counterRepeatI = 0;
                            break;
                        }
                        if (i == oldI)
                        {
                            counterRepeatI++;
                        }
                        if (counterRepeatI > 9)
                        {
                            counterRepeat = false;
                        }
                    }
                }
            }
            // +1 to allow a black pixel
            resultPosition[0] = oldI + 1;
            resultPosition[1] = oldJ + 1;
            return resultPosition;
        }

        private int GetCounVerticlaBlackPixel(int[,] array, int startFirstPixelX, int startPixelY)
        {
            int resultCounter = 0;
            for (int j = startPixelY; j > startPixelY - 120; j--)
            {
                if (array[startFirstPixelX, j] == 0)
                {
                    resultCounter++;
                }
            }
            return resultCounter;
        }
        #endregion

    }
}

