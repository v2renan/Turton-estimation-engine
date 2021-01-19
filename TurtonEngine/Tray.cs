using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public class Tray:Fatores
    {
        public int num;
        public double diam,custop;
        public string type,mat;
        public List<double> L = new List<double>(3);


        public double custoprato()
        {
            setFbm(mat, type);
            setFq(num);
            Fq = getFq();
            Fbm = getFm();
            L = fCusto("Tray", type);
            double area = (Math.PI * Math.Pow(diam, 2) )/ 4;
            return custop = Math.Pow(10, ((L[0] + L[1] * Math.Log10(area) + L[2] * Math.Pow(Math.Log10(area), 2)))) * num * Fq * Fbm;

        }





        public Tray(double Diametro, int numeropratos, string Tipo, string material)
        {
            this.num = numeropratos;
            this.diam = Diametro;
            this.type = Tipo;
            this.mat = material;

        }
    }
}
