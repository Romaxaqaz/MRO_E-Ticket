using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestNeighbor
{
    [Serializable]
    public class ClassObjectParams
    {
        public string ClassName { get; set; }
        public Bitmap bitmap { get; set;}
    }
}
