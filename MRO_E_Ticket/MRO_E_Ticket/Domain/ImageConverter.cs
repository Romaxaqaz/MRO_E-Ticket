using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Enum;
using MRO_E_Ticket.BitmapLib;
namespace MRO_E_Ticket.Domain
{
    public class ImageConverter
    {
        #region Constant For The Equation
        private readonly double x1 = 0.299;
        private readonly double x2 = 0.587;
        private readonly double x3 = 0.114;
        #endregion

        private readonly string TransferToGrayscaleProvess = "Transfer To Grayscale Image";
        private readonly string BinarizationThresholdMethod = "Binarization Image";
        private int sizeHeigh = 0;
        private int sizeWidth = 0;
        private int binarizationThreshold = 120;

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
            int[,] ArrayForImage = new int[bitmap.Width, bitmap.Height];
            sizeWidth = bitmap.Width;
            sizeHeigh = bitmap.Height;
            int progressValue = 0;
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    Color oldPixel = fastBitmap.GetPixel(i, j);
                    ArrayForImage[i, j] = GrayscalePixel(
                        oldPixel.R,
                        oldPixel.G,
                        oldPixel.B);
                }
                progressValue++;
                if (Progress != null)
                {
                    Progress(progressValue, bitmap.Width, TransferToGrayscaleProvess);
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
            int[,] ArrayForImage = new int[bitmap.Width, bitmap.Height];
            sizeWidth = bitmap.Width;
            sizeHeigh = bitmap.Height;
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
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
            int[,] ArrayForBinarizationImage = new int[bitmap.Width, bitmap.Height];
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
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
            int[,] ArrayForBinarizationImage = new int[bitmap.Width, bitmap.Height];
            int progressValue = 0;
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    ArrayForBinarizationImage[i, j] = ResultPixelColorAfterBinarization(fastBitmap.GetPixel(i, j).R);
                }
                progressValue++;
                if (Progress != null)
                {
                    Progress(progressValue, bitmap.Width, BinarizationThresholdMethod);
                }
            }
            fastBitmap.UnlockImage();
            return CreateBitmap(ArrayForBinarizationImage);
        }

        private byte ResultPixelColorAfterBinarization(int R)
        {
            byte resultColor = 0;
            if (R <= 120)
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
            Bitmap halfBitmap = new Bitmap(sizeWidth, sizeHeigh);
            FastBitmap fastBitmap = new FastBitmap(halfBitmap);
            fastBitmap.LockImage();
            int ScalePixel = 0;
            for (int i = 0; i < (sizeWidth); i++)
            {
                for (int j = 0; j < (sizeHeigh); j++)
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
            return ArrayForBinarizationImage;
        }
        //chek pixel value
        private int ColorPixel(int a, int r, int g, int b)
        {
            int result = 0;
            if (r == 255 &&
                g == 255 &&
                b == 255 &&
                a == 255)
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


    }
}

