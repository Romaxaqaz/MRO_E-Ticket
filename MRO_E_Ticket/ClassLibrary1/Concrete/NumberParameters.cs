using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    [Serializable]
    public class NumberParameters
    {
        public string Name { get; set; }
        public int[] list { get; set; }

        public NumberParameters(string name, int[] array)
        {
            Name = name;
            list = array;
        }
    }
}
