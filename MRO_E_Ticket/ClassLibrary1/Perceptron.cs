using PerceptronLib.Concrete;
using PerceptronLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLib
{
    public class Perceptron
    {
        private static readonly int SensorCount = ParamsPerceptron.Sensors;
        private static readonly int AjCount = ParamsPerceptron.AJElement;
        private string ImagePath = string.Empty;
        private Random random = new Random((int)DateTime.Now.Ticks);
        private List<Sensors> SensorList;
        private Addressable addressable;
        private List<Addressable> addressableList;
        private ConvertImageToSensorList convertimageToListSensors = new ConvertImageToSensorList();
        private Dictionary<string, int[]> dictionaryLambdaElement = new Dictionary<string, int[]>();
        private int[,] ArrayPerceprton = ParamsPerceptron.StaticPerceptronArray;
        private int[] ImageArray = new int[SensorCount];
        private int[] AlambdaElelment = new int[AjCount];
        private int[] BlambdaElelment = new int[AjCount];
        private int[] ClambdaElelment = new int[AjCount];

        public void OpenImage(string filePath)
        {
            ImagePath = filePath;
            Bitmap bmp = new Bitmap(filePath);
            SensorList = new List<Sensors>();    
            //получаем список сенсоров
            SensorList = convertimageToListSensors.GetSensorList(bmp);
            //формируем главную матрицу персептрона
            GenerateAddresable();
        }

        private void GenerateAddresable()
        {
            addressable = new Addressable();
            //передаем спискок сенсоров и матрицу персептрона
            addressable.AddParams(SensorList, ArrayPerceprton);
            //производим расчета
            addressable.SumAndElelments();
            //получаем результат
            var asd = addressable.AddressableResult.ToList();
            addressableList = asd;
        }
    }
}
