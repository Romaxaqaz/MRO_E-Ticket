using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLib.Model
{
    [Serializable]
    public class Sensors
    {
        public int Value { get; set; }
        public int ID { get; set; }

        public Sensors(int value, int id)
        {
            Value = value;
            ID = id;
        }
    }
}
