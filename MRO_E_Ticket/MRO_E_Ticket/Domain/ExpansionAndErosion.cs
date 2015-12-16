using MRO_E_Ticket.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRO_E_Ticket.Domain
{
    public static class ExpansionAndErosion
    {
        private static ImageConverter imageConverter = new ImageConverter();
        private static Segmentation segmentation = new Segmentation(null, null);

        private static int[,] mask = new int[3, 3]
        {
            {1,1,1},
            {1,1,1},
            {1,1,1}
        };

        public static int[,] Mask { get { return mask; } set { mask = value; } }
        //expansion method
        public static int[,] Expansion(int[,] mask, int[,] extendedImage, int extension = 1)
        {
            var height = extendedImage.GetLength(0) - (2 * extension);
            var width = extendedImage.GetLength(1) - (2 * extension);
            var erodeImage = new int[height, width];
            bool flag = false;

            for (int i = extension; i < height + extension; i++)
            {
                for (int j = extension; j < width + extension; j++)
                {
                    if (extendedImage[i, j] == 1)
                    {
                        flag = false;
                        erodeImage[i - extension, j - extension] = 1;

                        for (int j1 = j - extension, j2 = 0, k1 = 0; k1 < 2 * extension + 1; j1++, j2++, k1++)
                        {
                            for (int i1 = i - extension, i2 = 0, k = 0; k < 2 * extension + 1; i1++, i2++, k++)
                            {
                                if (mask[i2, j2] == 1)
                                {
                                    if ((extendedImage[i1, j1] != mask[i2, j2]))
                                    {
                                        erodeImage[i - extension, j - extension] = 0;
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (flag)
                                break;
                        }
                    }
                    else
                    {
                        erodeImage[i - extension, j - extension] = 0;
                    }
                }
            }
            return erodeImage;
        }
        //erosion method
        public static int[,] Erosion(int[,] mask, int[,] extendedImage, int extension = 1)
        {
            var height = extendedImage.GetLength(0) - (2 * extension);
            var width = extendedImage.GetLength(1) - (2 * extension);
            var dilateImage = new int[height, width];
            bool flag = false;

            for (int i = extension; i < height + extension; i++)
            {
                for (int j = extension; j < width + extension; j++)
                {
                    if (extendedImage[i, j] == 0)
                    {
                        flag = false;
                        dilateImage[i - extension, j - extension] = 0;

                        for (int j1 = j - extension, j2 = 0, k1 = 0; k1 < 2 * extension + 1; j1++, j2++, k1++)
                        {
                            for (int i1 = i - extension, i2 = 0, k = 0; k < 2 * extension + 1; i1++, i2++, k++)
                            {
                                if (mask[i2, j2] == 1)
                                {
                                    if ((extendedImage[i1, j1] == mask[i2, j2]))
                                    {
                                        dilateImage[i - extension, j - extension] = 1;
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            if (flag)
                                break;
                        }
                    }
                    else
                    {
                        dilateImage[i - extension, j - extension] = 1;
                    }
                }
            }
            return dilateImage;
        }
        //get collection expansion image
        public static List<ImageCollection> GetResultImageAfterExpansion(List<ImageCollection> numbetImageList, string nameImage = "EeOrEr")
        {
            var resultImageList = new List<ImageCollection>();
            int numberName = 0;
            foreach (var item in numbetImageList)
            {
                var array = imageConverter.GetImageArray(item.bitmap);
                var expansionArray = segmentation.ExtensionMatrix(Expansion(Mask, array));
                numberName++;
                resultImageList.Add(new ImageCollection(numberName.ToString() + nameImage, imageConverter.CreateBitmap(expansionArray)));
            }
            return resultImageList;
        }
        //get collection erosion image
        public static List<ImageCollection> GetResultImageAfterErosion(List<ImageCollection> numbetImageList, string nameImage = "EeOrEr")
        {
            var resultImageList = new List<ImageCollection>();
            int numberName = 0;
            foreach (var item in numbetImageList)
            {
                var array = imageConverter.GetImageArray(item.bitmap);
                var erosionArray = segmentation.ExtensionMatrix(Erosion(Mask, array));
                numberName++;
                resultImageList.Add(new ImageCollection(numberName.ToString() + nameImage, imageConverter.CreateBitmap(erosionArray)));
            }
            return resultImageList;
        }

        public static Bitmap GetResultImageAfterErosion(Bitmap numbetImageList)
        {
            var array = imageConverter.GetImageArray(numbetImageList);
            var erosionArray = segmentation.ExtensionMatrix(Erosion(Mask, array));
            var image = imageConverter.CreateBitmap(erosionArray);
            return image;
        }
    }
}
