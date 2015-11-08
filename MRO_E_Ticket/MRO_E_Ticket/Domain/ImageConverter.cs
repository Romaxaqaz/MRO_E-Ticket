using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Enum;
namespace MRO_E_Ticket.Domain
{
    public class ImageConverter
    {
        private readonly double x1 = 0.299;
        private readonly double x2 = 0.587;
        private readonly double x3 = 0.114;

        private readonly byte BinColorWhite = 255;
        private readonly byte BinColorBlack = 0;

        private int sizeHeigh = 0;
        private int sizeWidth = 0;
        private int binarizationThreshold = 120;

        public int BinarizationThreshold { get { return binarizationThreshold; } set { binarizationThreshold = value; } }

        #region Transfer To Grayscale
        public Bitmap TransferToGrayscaleGetBitmap(Bitmap bitmap)
        {
            int[,] bufferArray = new int[bitmap.Width, bitmap.Height];
            sizeWidth = bitmap.Width;
            sizeHeigh = bitmap.Height;
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    bufferArray[i, j] = GrayscalePixel(
                        bitmap.GetPixel(i, j).R,
                        bitmap.GetPixel(i, j).G,
                        bitmap.GetPixel(i, j).B);
                }
            }
            return CreateBitmapGray(bufferArray);
        }

        public int[,] TransferToGrayscaleGetArray(Bitmap bitmap)
        {
            int[,] bufferArray = new int[bitmap.Width, bitmap.Height];
            sizeWidth = bitmap.Width;
            sizeHeigh = bitmap.Height;
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    bufferArray[i, j] = GrayscalePixel(
                        bitmap.GetPixel(i, j).R,
                        bitmap.GetPixel(i, j).G,
                        bitmap.GetPixel(i, j).B);
                }
            }
            return bufferArray;
        }

        private int GrayscalePixel(int R, int G, int B)
        {
            double Y = x1 * R + x2 * G + x3 * B;
            return (int)Y;
        }
        #endregion

        #region Binarization
        public int[,] BinarizationThresholdMethodGetArray(Bitmap bitmap)
        {
            int[,] bufferArray = new int[bitmap.Width, bitmap.Height];
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    bufferArray[i, j] = ResultPixelColorAfterBinarization(bitmap.GetPixel(i, j).R,
                                                                          bitmap.GetPixel(i, j).G,
                                                                          bitmap.GetPixel(i, j).B);
                }
            }
            return bufferArray;
        }

        public Bitmap BinarizationThresholdMethodGetBitmap(Bitmap bitmap)
        {
            int[,] bufferArray = new int[bitmap.Width, bitmap.Height];
            for (int i = 0; i < (bitmap.Width); i++)
            {
                for (int j = 0; j < (bitmap.Height); j++)
                {
                    bufferArray[i, j] = ResultPixelColorAfterBinarization(bitmap.GetPixel(i, j).R,
                                                                          bitmap.GetPixel(i, j).G,
                                                                          bitmap.GetPixel(i, j).B);
                }
            }
            return CreateBitmap(bufferArray);
        }

        private byte ResultPixelColorAfterBinarization(int R, int G, int B)
        {
            byte resultColor = 0;
            if (R <= 120 || G <= 120 || B <= 120)
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

        public Bitmap CreateBitmap(int[,] arrayImage)
        {
            Bitmap halfBitmap = new Bitmap(sizeWidth, sizeHeigh);
            int ScalePixel = 0;
            for (int i = 0; i < (sizeWidth); i++)
            {
                for (int j = 0; j < (sizeHeigh); j++)
                {
                    ScalePixel = arrayImage[i, j];
                    halfBitmap.SetPixel(i, j, Color.FromArgb(ScalePixel, ScalePixel, ScalePixel));
                }
            }
            return halfBitmap;
        }

        public Bitmap CreateBitmapGray(int[,] arrayImage)
        {
            Bitmap halfBitmap = new Bitmap(sizeWidth, sizeHeigh);
            int ScalePixel = 0;
            for (int i = 0; i < (sizeWidth); i++)
            {
                for (int j = 0; j < (sizeHeigh); j++)
                {
                    ScalePixel = arrayImage[i, j];
                    halfBitmap.SetPixel(i, j, Color.FromArgb(ScalePixel,ScalePixel, ScalePixel, ScalePixel));
                }
            }
            return halfBitmap;
        }


    }
}

