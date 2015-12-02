using PerceptronLib.Concrete;
using PerceptronLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ClassLibrary1.Concrete;
using ClassLibrary1.Enum;
using PerceptronLib;

namespace PerceptronLib
{
    [Serializable]
    public class Perceptron
    {
        private int sensorCount = 0;
        private int ajCount = 0;
        private string ImagePath = string.Empty;
        private int[,] ArrayPerceprton = null;
        private List<Sensors> SensorList;
        private Addressable addressable;
        private List<Addressable> addressableList;
        private ConvertImageToSensorList convertimageToListSensors = new ConvertImageToSensorList();
        private Random random = new Random((int)DateTime.Now.Ticks);
        private Dictionary<ClassName, int[]> dictionaryLambdaElement = new Dictionary<ClassName, int[]>();
        private Dictionary<ClassName, int> sumLambdaElement = new Dictionary<ClassName, int>();
        

        public int Sensors { get { return sensorCount; } }
        public int AjElements { get { return ajCount; } }

        #region LambdaArray
        private int[] OneLabdaArray;
        private int[] TwoLabdaArray;
        private int[] ThreeLabdaArray;
        private int[] FourLabdaArray;
        private int[] FiveLabdaArray;
        private int[] SixLabdaArray;
        private int[] SevenLabdaArray;
        private int[] EightLabdaArray;
        private int[] NineLabdaArray;
        private int[] NullLabdaArray;
        #endregion

        #region Initialize Lambda array
        public Perceptron(int sensors, int ajElements)
        {
            sensorCount = sensors;
            ajCount = ajElements;
            var percepArray = new PerceptronArray(sensorCount, ajElements);
            ArrayPerceprton = percepArray.GetArrayPerceprton();

            OneLabdaArray = new int[ajCount];
            TwoLabdaArray = new int[ajCount];
            ThreeLabdaArray = new int[ajCount];
            FourLabdaArray = new int[ajCount];
            FiveLabdaArray = new int[ajCount];
            SixLabdaArray = new int[ajCount];
            SevenLabdaArray = new int[ajCount];
            EightLabdaArray = new int[ajCount];
            NineLabdaArray = new int[ajCount];
            NullLabdaArray = new int[ajCount];
            //dictionary class name and array lambdaz
        }
        #endregion

        #region Learning Perseptron
        //learning perseptron
        public void LearningPerseptron(string filePath, string name)
        {
            ImagePath = filePath;
            Bitmap bmp = new Bitmap(filePath);
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var adList = addressable.AddressableResult.ToList();
            if (filePath.Contains("null"))
            {
                NullLabdaArray = LearArrayElemntSolve(NullLabdaArray, adList);
            }
            if (filePath.Contains("one"))
            {
                OneLabdaArray = LearArrayElemntSolve(OneLabdaArray, adList);
            }
            if (filePath.Contains("two"))
            {
                TwoLabdaArray = LearArrayElemntSolve(TwoLabdaArray, adList);
            }
            if (filePath.Contains("three"))
            {
                ThreeLabdaArray = LearArrayElemntSolve(ThreeLabdaArray, adList);
            }
            if (filePath.Contains("four"))
            {
                FourLabdaArray = LearArrayElemntSolve(FourLabdaArray, adList);
            }
            if (filePath.Contains("five"))
            {
                FiveLabdaArray = LearArrayElemntSolve(FiveLabdaArray, adList);
            }
            if (filePath.Contains("six"))
            {
                SixLabdaArray = LearArrayElemntSolve(SixLabdaArray, adList);
            }
            if (filePath.Contains("seven"))
            {
                SevenLabdaArray = LearArrayElemntSolve(SevenLabdaArray, adList);
            }
            if (filePath.Contains("eight"))
            {
                EightLabdaArray = LearArrayElemntSolve(EightLabdaArray, adList);
            }
            if (filePath.Contains("nine"))
            {
                NineLabdaArray = LearArrayElemntSolve(NineLabdaArray, adList);
            }

        }

        public void EndLearning()
        {
            dictionaryLambdaElement.Add(ClassName.Null, NullLabdaArray);
            dictionaryLambdaElement.Add(ClassName.One, OneLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Two, TwoLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Three, ThreeLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Four, FourLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Five, FiveLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Six, SixLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Seven, SevenLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Eight, EightLabdaArray);
            dictionaryLambdaElement.Add(ClassName.Nine, NineLabdaArray);
        }
        //get name class image
        public string InputsImageForPerseptron(string filePath)
        {
            ImagePath = filePath;
            Bitmap bmp = new Bitmap(filePath);
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var asd = addressable.AddressableResult.ToList();
            addressableList = asd;
            return GetClassManeImage();
        }
        //learning process
        private int[] LearArrayElemntSolve(int[] array, List<Addressable> list)
        {
            for (int i = 0; i < ajCount; i++)
            {
                if (list[i].Output == 1)
                {
                    array[i]++;
                }
                else
                {
                    array[i]--;
                }
            }
            return array;
        }

        private int[] AtoYelements(int[] array)
        {
            int[] bufferArray = new int[ajCount];
            for (int i = 0; i < ajCount; i++)
            {
                bufferArray[i] = array[i] * addressableList[i].Output;
            }
            return bufferArray;
        }

        private int SumArrayElement(int[] array)
        {
            int resiltSum = 0;
            for (int i = 0; i < ajCount; i++)
            {
                resiltSum = resiltSum + array[i];
            }
            return resiltSum;
        }

        #endregion

        public string GetClassManeImage()
        {
            //clear dictionary sum lambda
            sumLambdaElement.Clear();
            string name = string.Empty;
            foreach (var item in dictionaryLambdaElement)
            {
                int x = SumArrayElement(AtoYelements(item.Value));
                sumLambdaElement.Add(item.Key, x);
            }
            //get max sum in arrays
            var max = sumLambdaElement.Max(x => x.Value);
            //get class name when max value
            string classname = sumLambdaElement.FirstOrDefault(x => x.Value == max).Key.ToString();
            return classname;
        }
    }
}
