using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public class Maintest
    {

        static void Main(string[] args)
        {
            Pump p = new Pump("Centrifugal", 25, 2);  //teste
            double c = p.custo();
        }
    }
}
