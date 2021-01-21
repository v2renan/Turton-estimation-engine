using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public class Pump:Fatores
    {
        public double custopump;
        public string type, mat;
        public double pres, pot;
        public List<double> B = new List<double>(2);
        public List<double> L = new List<double>(3);



        public double custo()
        {
            B.Add(1.89); B.Add(1.35);

            setFm("Pump", type, mat);
            double Fmat = getFm();
            setFp(pres, "Pump", type);
            L = fCusto("Pump", type);
            double Fp = getFp();
            custopump = Math.Pow(10,((L[0] + L[1] * Math.Log10(pot) + L[2] * Math.Pow(Math.Log10(pot), 2)))) * (B[0] + B[1] * Fp*Fmat);
            return custopump;
        }


        public Pump(string type, double pot, double pres, string material)
        {
            this.type = type;
            this.pot = pot;
            this.pres = pres;
            this.mat = material;
        }
    }
}
