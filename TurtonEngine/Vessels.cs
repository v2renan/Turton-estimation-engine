using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public class Vessels:Fatores
    {

        public double custoVaso;
        public string pos,mat;
        public double pres, diam,comprimento,temp;
        public List<double> B = new List<double>(2);
        public List<double> L = new List<double>(3);



        public double custo()
        {
            if (pos == "Vertical")
            {
                B.Add(2.25); B.Add(1.82);
            }
            else
            {
                B.Add(1.49); B.Add(1.52);
            }
                       
            setFpVessel(diam,pres,mat,temp,pos);
            setFm("Vessel", pos, mat);
            double Fmat = getFm();
            L = fCusto("Vessel", pos);
            double Fp = getvesselFp();
            double Vol = (Math.PI*Math.Pow(diam,2)*comprimento)/ 4;
            custoVaso = Math.Pow(10, ((L[0] + L[1] * Math.Log10(Vol) + L[2] * Math.Pow(Math.Log10(Vol), 2)))) * (B[0] + B[1] * Fp*Fmat);
            return custoVaso;
        }

        public Vessels(double Diametro, double Comprimento, string Posicao, string Material, double Temperatura,double Pressao)
        {
            this.mat = Material;
            this.comprimento = Comprimento;
            this.diam = Diametro;
            this.pos = Posicao;
            this.temp = Temperatura;
            this.pres = Pressao;


        }
    }
}
