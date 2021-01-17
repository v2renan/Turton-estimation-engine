using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public class Heatexchanger:Fatores
    {

        public double custoheatex;
        public string type;
        public double pres, area;
        public List<double> B = new List<double>(2);
        public List<double> L = new List<double>(3);



        public double custo()
        {
            if ( type == "Double pipe" | type == "Multiple pipes")
            {
                B.Add(1.74); B.Add(1.55);
            }
            else
            {
                B.Add(1.63); B.Add(1.66);
            }

            

            setFp(pres, "Heat exchanger", type);
            L = fCusto("Heat exchanger", type);
            double Fp = getFp();
            custoheatex = Math.Pow(10, ((L[0] + L[1] * Math.Log10(area) + L[2] * Math.Pow(Math.Log10(area), 2)))) * (B[0] + B[1] * Fp);
            return custoheatex;
        }

        public Heatexchanger(string type, double area, double pres )
        {
            this.type = type;
            this.area = area;
            this.pres = pres;
        }

    }
}
