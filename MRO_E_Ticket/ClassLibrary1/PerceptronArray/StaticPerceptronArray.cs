using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLib.PerceptronArray;

namespace PerceptronLib.PerceptronArray
{
    public static class StaticPerceptronArray
    {
        private static int sensorCount = ParamsPerceptron.Sensors;
        private static int aj = ParamsPerceptron.AJElement;

        public static int SensorCount { get { return sensorCount; } set { sensorCount = value; } }
        public static int AjCount { get { return aj; } set { aj = value; } }

        private static Random random;
        public static int[,] GetArrayPerceprton()
        {
            int[,] resultArray = new int[SensorCount, AjCount];
            random = new Random();
            for (int i = 0; i < SensorCount; i++)
            {
                resultArray[i, random.Next(0, AjCount)] = GetRandom(random.Next(1, 3));
            }
            return resultArray;
        }

        private static int GetRandom(int basicRandom)
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
