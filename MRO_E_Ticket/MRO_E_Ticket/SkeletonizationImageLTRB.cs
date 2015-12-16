using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRO_E_Ticket.Domain;

namespace MRO_E_Ticket
{
    public class SkeletonizationImageLTRB
    {
        private MRO_E_Ticket.Domain.ImageConverter imageConverter = new MRO_E_Ticket.Domain.ImageConverter();

        int[,] resitlArray;

        public Bitmap SkeletizationRun(Bitmap bitmap)
        {
            for (int i = 0; i < 5; i++)
            {
                bitmap = LRTBfour(bitmap);
            }
            return bitmap;
        }

        private Bitmap LRTBfour(Bitmap bmp)
        {
            Bitmap temp = new Bitmap(bmp);
            bool black = true;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (bmp.GetPixel(j, i).R == 0 && black)
                    {
                        black = false;
                        bool f = Four(bmp, j, i);
                        bool s = Syna(bmp, j, i);
                        if (f && s)
                        {
                            temp.SetPixel(j, i, Color.White);
                        }
                    }
                    if (bmp.GetPixel(j, i).R == 255 && black == false)
                    {
                        black = true;
                    }
                }
            }
            black = true;
            bmp = new Bitmap(temp);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = bmp.Width - 1; j >= 0; j--)
                {
                    if (bmp.GetPixel(j, i).R == 0 && black)
                    {
                        black = false;
                        bool f = Four(bmp, j, i);
                        bool s = Syna(bmp, j, i);
                        if (f && s)
                        {
                            temp.SetPixel(j, i, Color.White);
                        }
                    }
                    if (bmp.GetPixel(j, i).R == 255 && black == false)
                    {
                        black = true;
                    }
                }
            }
            black = true;
            bmp = new Bitmap(temp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (bmp.GetPixel(i, j).R == 0 && black)
                    {
                        black = false;
                        bool f = Four(bmp, i, j);
                        bool s = Syna(bmp, i, j);
                        if (f && s)
                        {
                            temp.SetPixel(i, j, Color.White);
                        }
                    }
                    if (bmp.GetPixel(i, j).R == 255 && black == false)
                    {
                        black = true;
                    }
                }
            }
            black = true;
            bmp = new Bitmap(temp);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = bmp.Height - 1; j >= 0; j--)
                {
                    if (bmp.GetPixel(i, j).R == 0 && black)
                    {
                        black = false;
                        bool f = Four(bmp, i, j);
                        bool s = Syna(bmp, i, j);
                        if (f && s)
                        {
                            temp.SetPixel(i, j, Color.White);
                        }
                    }
                    if (bmp.GetPixel(i, j).R == 255 && black == false)
                    {
                        black = true;
                    }
                }
            }
            return temp;
        }
        private bool Four(Bitmap bmp, int j, int i)
        {
            if (bmp.GetPixel(j - 1, i).R == 0 &
            bmp.GetPixel(j + 1, i).R == 0 &
            bmp.GetPixel(j, i - 1).R == 255 &
            bmp.GetPixel(j, i + 1).R == 255)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 0 &
            bmp.GetPixel(j, i + 1).R == 0 &
            bmp.GetPixel(j - 1, i).R == 255 &
            bmp.GetPixel(j + 1, i).R == 255)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 0 &
            bmp.GetPixel(j, i + 1).R == 255 &
            bmp.GetPixel(j - 1, i).R == 255 &
            bmp.GetPixel(j + 1, i).R == 255)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 255 &
            bmp.GetPixel(j, i + 1).R == 0 &
            bmp.GetPixel(j - 1, i).R == 255 &
            bmp.GetPixel(j + 1, i).R == 255)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 255 &
            bmp.GetPixel(j, i + 1).R == 255 &
            bmp.GetPixel(j - 1, i).R == 0 &
            bmp.GetPixel(j + 1, i).R == 255)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 255 &
            bmp.GetPixel(j, i + 1).R == 255 &
            bmp.GetPixel(j - 1, i).R == 255&
            bmp.GetPixel(j + 1, i).R == 0)
                return false;
            if (bmp.GetPixel(j, i - 1).R == 255 &
            bmp.GetPixel(j, i + 1).R == 255 &
            bmp.GetPixel(j - 1, i).R == 255 &
            bmp.GetPixel(j + 1, i).R == 255)
                return false;
            return true;
        }
        private bool Syna(Bitmap bmp, int j, int i)
        {
            List<byte> syna = new List<byte>();
            bool aone = true, yes = true;
            int cur = 0;
            syna.Add(bmp.GetPixel(j - 1, i - 1).R);
            syna.Add(bmp.GetPixel(j, i - 1).R);
            syna.Add(bmp.GetPixel(j + 1, i - 1).R);
            syna.Add(bmp.GetPixel(j + 1, i).R);
            syna.Add(bmp.GetPixel(j + 1, i + 1).R);
            syna.Add(bmp.GetPixel(j, i + 1).R);
            syna.Add(bmp.GetPixel(j - 1, i + 1).R);
            syna.Add(bmp.GetPixel(j - 1, i).R);
            for (int k = 0; k < syna.Count; k++)
            {
                if (syna[k] == 0 & yes)
                {
                    cur++;
                    yes = false;
                }
                if (syna[k] == 255)
                {
                    yes = true;
                }
            }
            if (syna[0] == 0 & syna[syna.Count - 1] == 0)
            {
                cur--;
            }
            if (syna[1] == 0 & syna[3] == 0 & syna[2] == 255)
            {
                cur--;
            }
            if (syna[3] == 0 & syna[5] == 0 & syna[4] == 255)
            {
                cur--;
            }
            if (syna[5] == 0 & syna[7] == 0 & syna[6] == 255)
            {
                cur--;
            }
            if (syna[1] == 0 & syna[7] == 0 & syna[0] == 255)
            {
                cur--;
            }
            if (cur > 1)
            {
                aone = false;
            }
            return aone;
        }
    }
}
