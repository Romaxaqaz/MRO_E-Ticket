using PerceptronLib.Model;
using System;
using System.Collections.Generic;

namespace PerceptronLib.Concrete
{
    [Serializable]
    public class Addressable
    {
        
        private int output;
        private int sum;
        private int threshold = 1;
        private int ajLength = 0;
        private int[,] ArrayAjElemenst;
        private List<Sensors> listSensor;
        private List<Addressable> addressableList = new List<Addressable>();

        public IEnumerable<Addressable> AddressableResult { get { return addressableList; } }
        public int Threshold { get { return threshold; } set { threshold = value; } }
        public int Output { get { return output; } }
        public int Sum { get { return sum; } }

        #region Addresable operations

        public Addressable(List<Sensors> list, int[,] arrayPersep)
        {
            listSensor = list;
            ArrayAjElemenst = arrayPersep;
            ajLength = arrayPersep.GetLength(1);
        }

        public void SumAndElelments()
        {
            int i = 0;
            for (i = 0; i < ajLength; i++)
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

        private Addressable(int sum, int output)
        {
            this.sum = sum;
            this.output = output;
        }

        #endregion
    }
}
