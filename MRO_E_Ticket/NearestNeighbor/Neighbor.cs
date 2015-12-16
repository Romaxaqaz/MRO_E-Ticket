using ClassLibrary1.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestNeighbor
{
    [Serializable]
    public class Neighbor
    {
        private Dictionary<string, Bitmap> bitMapList;
        private List<ClassObjectParams> paramlsObjectList = new List<ClassObjectParams>();
        private List<ClassValue> classValue = new List<ClassValue>();
        private Dictionary<string, Bitmap> dictionaryElement = new Dictionary<string, Bitmap>();
        private Dictionary<string, double> dictionaryElementValue = new Dictionary<string, double>();

        public Neighbor()
        {

        }

        public Neighbor(Dictionary<string, Bitmap> list)
        {
            bitMapList = list;
            foreach (var item in bitMapList)
            {
                if (item.Key.Contains("null"))
                {
                    LearnNeighbor("0", item.Value);
                }
                if (item.Key.Contains("one"))
                {
                    LearnNeighbor("1", item.Value);
                }
                if (item.Key.Contains("two"))
                {
                    LearnNeighbor("2", item.Value);
                }
                if (item.Key.Contains("three"))
                {
                    LearnNeighbor("3", item.Value);
                }
                if (item.Key.Contains("four"))
                {
                    LearnNeighbor("4", item.Value);
                }
                if (item.Key.Contains("five"))
                {
                    LearnNeighbor("5", item.Value);
                }
                if (item.Key.Contains("six"))
                {
                    LearnNeighbor("6", item.Value);
                }
                if (item.Key.Contains("seven"))
                {
                    LearnNeighbor("7", item.Value);
                }
                if (item.Key.Contains("eight"))
                {
                    LearnNeighbor("8", item.Value);
                }
                if (item.Key.Contains("nine"))
                {
                    LearnNeighbor("9", item.Value);
                }
            }
        }

        public void LearnNeighbor(string className, Bitmap bit)
        {
            paramlsObjectList.Add(new ClassObjectParams { ClassName = className, bitmap = bit });
        }

        public string NameClass(Bitmap bit)
        {
            paramlsObjectList.Add(new ClassObjectParams { ClassName = "", bitmap = bit });
            foreach (var item in paramlsObjectList)
            {
                classValue.Add( new ClassValue { ClassName = item.ClassName, Value = ValueImage(item.bitmap, paramlsObjectList.Last().bitmap) });
            }
            var min = classValue.Min(x => x.Value);
            var minNoLast = classValue.Where(y => y.Value != min).Min(a => a.Value);
            paramlsObjectList.Remove(paramlsObjectList.Last());
            string result = classValue.Where(y => y.Value == minNoLast).Select(a => a.ClassName).FirstOrDefault().ToString();
            classValue.Clear();
            return result;
        }

        private double ValueImage(Bitmap bmp, Bitmap lastBit)
        {
            double r = 0;
            for (byte i = 0; i < bmp.Height; i++)
                for (byte j = 0; j < bmp.Width; j++)
                    r += Math.Pow(lastBit.GetPixel(i, j).R - bmp.GetPixel(i, j).R, 2);
            return Math.Pow(r, 0.5);
        }

    }
}
