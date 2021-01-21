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
            //Pump p = new Pump("Centrifugal", 1.0, 0.9,"Carbon steel");  //testefff
            //double c = p.custo() * 607.5 / 397;

            //Heatexchanger ht = new Heatexchanger("Floating head", 405, 0.9, "CS-shell/CS-tube");
            //double c = ht.custo() * 607.5 / 397;

            Vessels vessels = new Vessels(1.13, 19.8, "Vertical", "Carbon steel", 0, 0.75); // pressão em N/m2 - Temp em Celsius !!!!!
            double v = vessels.custo() * 607.5 / 397;


            Tray tray = new Tray(1.13, 27, "Sieve", "Carbon steel");
            double t = tray.custoprato() * 582.0 / 397;

            double soma = t + v;
        }
    }
}
