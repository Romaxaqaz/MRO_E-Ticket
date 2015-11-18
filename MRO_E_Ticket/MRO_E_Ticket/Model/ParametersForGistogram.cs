using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRO_E_Ticket.Model
{
    public class ParametersForGistogram
    {
        private int theТumberOfPixels = 0;
        private int startPositionPixel = 0;
        private int endPositionPixel = 0;

        public int TheТumberOfPixels { get { return theТumberOfPixels; } set { theТumberOfPixels = value; } }
        public int StartPositionPixel { get { return startPositionPixel; } set { startPositionPixel = value; } }
        public int EndPositionPixel { get { return endPositionPixel; } set { endPositionPixel = value; } }
        public int WidthPixels { get { return endPositionPixel - startPositionPixel; } }

        public ParametersForGistogram(int numberPixels)
        {
            theТumberOfPixels = numberPixels;
        }

        public ParametersForGistogram(int numberPixels, int startP, int endP)
        {
            theТumberOfPixels = numberPixels;
            startPositionPixel = startP;
            endPositionPixel = endP;
        }
    }
}
