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
            //Pump p = new Pump("Centrifugal", 25, 2);  //testefff
            //double c = p.custo();

            //Heatexchanger ht = new Heatexchanger("Multiple pipes", 50, 20);
            //double c = ht.custo();

            //Vessels vessels = new Vessels(3, 30, "Vertical", "ss 304", 300, 2000000); // pressão em N/m2 - Temp em Celsius !!!!!
            //double v = vessels.custo();

            Tray tray = new Tray(3, 40, "Sieve", "ss 304");
            tray.custoprato();
        }
    }
}
