using PerceptronLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLib.PerceptronArray;
namespace PerceptronLib.Concrete
{
    public class Addressable
    {
        private List<Sensors> listSensor;
        private List<Addressable> addressableList = new List<Addressable>();
        private int output;
        private int sum;
        private int threshold = 1;
        private int id = 0;
        private int[,] ArrayAjElemenst = new int[ParamsPerceptron.Sensors, ParamsPerceptron.AJElement];
        public int Output { get { return output; } }
        public int Sum { get { return sum; } }
        public int Threshold { get { return threshold; } set { threshold = value; } }

        public Addressable()
        {
            this.id = 0;
        }
        public Addressable(int sum, int output)
        {
            this.sum = sum;
            this.output = output;
        }

        public IEnumerable<Addressable> AddressableResult { get { return addressableList; } }

        public void SumAndElelments()
        {
            int i = 0;
            for (i = 0; i < ParamsPerceptron.AJElement; i++)
            {
                SumAElement(i);
            }
        }

        private void SumAElement(int i)
        {
            int resultSum = 0;

            foreach (var item in listSensor)
            {
                resultSum = resultSum + (item.Value * ArrayAjElemenst[item.ID, i]);
            }
            sum = resultSum;
            output = (sum >= Threshold) ? 1 : 0;
            addressableList.Add(new Addressable(sum, output));
        }

        public void AddParams(List<Sensors> list, int[,] mainArray)
        {
            var listSensorBuuf = list;
            var ArrayAjElemenstBuuf = mainArray;
            listSensor = listSensorBuuf;
            ArrayAjElemenst = ArrayAjElemenstBuuf;
        }
    }
}
