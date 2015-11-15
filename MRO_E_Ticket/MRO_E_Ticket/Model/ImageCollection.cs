using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRO_E_Ticket.Model
{
    public class ImageCollection
    {
        public string Name { get; set; }
        public Bitmap bitmap;

        public ImageCollection(string name, Bitmap bit)
        {
            Name = name;
            bitmap = bit;
        }
    }
}
