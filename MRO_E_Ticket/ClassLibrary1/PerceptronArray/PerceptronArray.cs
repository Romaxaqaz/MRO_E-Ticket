using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLib
{
    [Serializable]
    public class PerceptronArray
    {
        private int sensorCount = 0;
        private int aj = 0;

        public int SensorCount { get { return sensorCount; } set { sensorCount = value; } }
        public int AjCount { get { return aj; } set { aj = value; } }

        private Random random;

        public PerceptronArray(int sensors, int ajElements)
        {
            sensorCount = sensors;
            aj = ajElements;
        }

        public int[,] GetArrayPerceprton()
        {
            int[,] resultArray = new int[sensorCount, aj];
            random = new Random();
            for (int i = 0; i < sensorCount; i++)
            {
                resultArray[i, random.Next(0, aj)] = GetRandom(random.Next(1, 3));
            }
            return resultArray;
        }

        private int GetRandom(int basicRandom)
        {
            int result = 0;
            switch (basicRandom)
            {
                case 1:
                    result = 1;
                    break;
                case 2:
                    result = -1;
                    break;
            }
            return result;
        }
    }
}
