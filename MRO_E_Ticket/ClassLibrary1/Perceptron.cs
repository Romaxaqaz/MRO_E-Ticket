using PerceptronLib.Concrete;
using PerceptronLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ClassLibrary1.Enum;

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
        public Dictionary<ClassName, int[]> dictionaryLambdaElement = new Dictionary<ClassName, int[]>();
        public Dictionary<ClassName, int[]> dictionaryLambdaElementAnswer = new Dictionary<ClassName, int[]>();
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

        private int[] OneLabdaArrayFromAnswer;
        private int[] TwoLabdaArrayFromAnswer;
        private int[] ThreeLabdaArrayFromAnswer;
        private int[] FourLabdaArrayFromAnswer;
        private int[] FiveLabdaArrayFromAnswer;
        private int[] SixLabdaArrayFromAnswer;
        private int[] SevenLabdaArrayFromAnswer;
        private int[] EightLabdaArrayFromAnswer;
        private int[] NineLabdaArrayFromAnswer;
        private int[] NullLabdaArrayFromAnswer;
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
        public void LearningPerseptron(string filePath, string name, Bitmap bit=null)
        {
            ImagePath = filePath;
            Bitmap bmp;
            if (filePath!="")
            {
                bmp = new Bitmap(filePath);
            }
            else
            {
               bmp = bit;
            }
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var adList = addressable.AddressableResult.ToList();
            if (filePath.Contains("null") || name.Contains("Null"))
            {
                NullLabdaArray = LearArrayElemntSolve(NullLabdaArray, adList);
            }
            if (filePath.Contains("one") || name.Contains("One"))
            {
                OneLabdaArray = LearArrayElemntSolve(OneLabdaArray, adList);
            }
            if (filePath.Contains("two") || name.Contains("Two"))
            {
                TwoLabdaArray = LearArrayElemntSolve(TwoLabdaArray, adList);
            }
            if (filePath.Contains("three") || name.Contains("Three"))
            {
                ThreeLabdaArray = LearArrayElemntSolve(ThreeLabdaArray, adList);
            }
            if (filePath.Contains("four") || name.Contains("Four"))
            {
                FourLabdaArray = LearArrayElemntSolve(FourLabdaArray, adList);
            }
            if (filePath.Contains("five") || name.Contains("Five"))
            {
                FiveLabdaArray = LearArrayElemntSolve(FiveLabdaArray, adList);
            }
            if (filePath.Contains("six") || name.Contains("Six"))
            {
                SixLabdaArray = LearArrayElemntSolve(SixLabdaArray, adList);
            }
            if (filePath.Contains("seven") || name.Contains("Seven"))
            {
                SevenLabdaArray = LearArrayElemntSolve(SevenLabdaArray, adList);
            }
            if (filePath.Contains("eight") || name.Contains("Eight"))
            {
                EightLabdaArray = LearArrayElemntSolve(EightLabdaArray, adList);
            }
            if (filePath.Contains("nine") || name.Contains("Nine"))
            {
                NineLabdaArray = LearArrayElemntSolve(NineLabdaArray, adList);
            }

        }

        public void LearningPerseptronFromAnswer(string filePath, string name, Bitmap bit = null)
        {
            ImagePath = filePath;
            Bitmap bmp;
            if (filePath != "")
            {
                bmp = new Bitmap(filePath);
            }
            else
            {
                bmp = bit;
            }
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var adList = addressable.AddressableResult.ToList();
            if (filePath.Contains("null") || name.Contains("Null"))
            {
                NullLabdaArrayFromAnswer = LearArrayElemntSolve(NullLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("one") || name.Contains("One"))
            {
                OneLabdaArrayFromAnswer = LearArrayElemntSolve(OneLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("two") || name.Contains("Two"))
            {
                TwoLabdaArrayFromAnswer = LearArrayElemntSolve(TwoLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("three") || name.Contains("Three"))
            {
                ThreeLabdaArrayFromAnswer = LearArrayElemntSolve(ThreeLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("four") || name.Contains("Four"))
            {
                FourLabdaArrayFromAnswer = LearArrayElemntSolve(FourLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("five") || name.Contains("Five"))
            {
                FiveLabdaArrayFromAnswer = LearArrayElemntSolve(FiveLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("six") || name.Contains("Six"))
            {
                SixLabdaArrayFromAnswer = LearArrayElemntSolve(SixLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("seven") || name.Contains("Seven"))
            {
                SevenLabdaArrayFromAnswer = LearArrayElemntSolve(SevenLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("eight") || name.Contains("Eight"))
            {
                EightLabdaArrayFromAnswer = LearArrayElemntSolve(EightLabdaArrayFromAnswer, adList);
            }
            if (filePath.Contains("nine") || name.Contains("Nine"))
            {
                NineLabdaArrayFromAnswer = LearArrayElemntSolve(NineLabdaArrayFromAnswer, adList);
            }

        }

        public void EndLearning()
        {
            dictionaryLambdaElement.Clear();
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

        public void CombineArrays()
        {
            OneLabdaArrayFromAnswer = new int[ajCount];
            TwoLabdaArrayFromAnswer = new int[ajCount];
            ThreeLabdaArrayFromAnswer = new int[ajCount];
            FourLabdaArrayFromAnswer = new int[ajCount];
            FiveLabdaArrayFromAnswer = new int[ajCount];
            SixLabdaArrayFromAnswer = new int[ajCount];
            SevenLabdaArrayFromAnswer = new int[ajCount];
            EightLabdaArrayFromAnswer = new int[ajCount];
            NineLabdaArrayFromAnswer = new int[ajCount];
            NullLabdaArrayFromAnswer = new int[ajCount];

            OneLabdaArrayFromAnswer = FillArray(OneLabdaArrayFromAnswer);
            TwoLabdaArrayFromAnswer = FillArray(TwoLabdaArrayFromAnswer);
            ThreeLabdaArrayFromAnswer = FillArray(ThreeLabdaArrayFromAnswer);
            FourLabdaArrayFromAnswer = FillArray(FourLabdaArrayFromAnswer);
            FiveLabdaArrayFromAnswer = FillArray(FiveLabdaArrayFromAnswer);
            SixLabdaArrayFromAnswer = FillArray(SixLabdaArrayFromAnswer);
            SevenLabdaArrayFromAnswer = FillArray(SevenLabdaArrayFromAnswer);
            EightLabdaArrayFromAnswer = FillArray(EightLabdaArrayFromAnswer);
            NineLabdaArrayFromAnswer = FillArray(NineLabdaArrayFromAnswer);
            NullLabdaArrayFromAnswer = FillArray(NullLabdaArrayFromAnswer);

            EndLearningFromAnswer();
        }

        public void EndLearningFromAnswer()
        {
            dictionaryLambdaElementAnswer = new Dictionary<ClassName, int[]>();
            dictionaryLambdaElementAnswer.Clear();
            dictionaryLambdaElementAnswer.Add(ClassName.Null, NullLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.One, OneLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Two, TwoLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Three, ThreeLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Four, FourLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Five, FiveLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Six, SixLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Seven, SevenLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Eight, EightLabdaArrayFromAnswer);
            dictionaryLambdaElementAnswer.Add(ClassName.Nine, NineLabdaArrayFromAnswer);
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

        public string InputsImageForPerseptron(Bitmap bmp)
        {
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

        public string InputsImageForPerseptronFromAnswer(string filePath)
        {
            ImagePath = filePath;
            Bitmap bmp = new Bitmap(filePath);
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var asd = addressable.AddressableResult.ToList();
            addressableList = asd;
            return GetClassManeImageFromAnswer();
        }

        public string InputsImageForPerseptronFromAnswer(Bitmap bit)
        {
            Bitmap bmp = bit;
            SensorList = new List<Sensors>();
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            addressable = new Addressable(SensorList, ArrayPerceprton);
            addressable.SumAndElelments();
            var asd = addressable.AddressableResult.ToList();
            addressableList = asd;
            return GetClassManeImageFromAnswer();
        }

        public string GetClassManeImageFromAnswer()
        {
            //clear dictionary sum lambda
            sumLambdaElement.Clear();
            string name = string.Empty;
            foreach (var item in dictionaryLambdaElementAnswer)
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

        private int[] FillArray(int[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = 1;
            }
            return array;
        }
        
    }
}
