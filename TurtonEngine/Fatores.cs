using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public abstract class Fatores
    {

        #region Atributos de pressão

        private List<double> Factp = new List<double>(3);
        private double Fp;
        private double VesFp;
        public double stress;
        public double dens;
        public double esp;
        

        #endregion

                
        #region Fatores de Pressão
        public double getFp()
        {
            return Fp;
        }
        public void setFp(double pressao, string equip, string type)
        {

            switch (equip)
            {
                case "Pump":
                    if (pressao <= 10)
                    {
                        Factp.Add(0); Factp.Add(0); Factp.Add(0);
                        Fp = Math.Pow(10, (Factp[0] + Factp[1]*Math.Log10(pressao) + Factp[2]*Math.Pow(Math.Log10(pressao),2)));
                    }
                    else if (pressao <= 100)
                    {
                        switch (type)
                        {
                            case "Centrifugal":
                                Factp.Add(-0.3935); Factp.Add(0.3957); Factp.Add(-0.0026);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                                break;
                            case "Reciprocating":
                                Factp.Add(-0.245382); Factp.Add(0.259016); Factp.Add(-0.01363);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                                break;
                            case "Positive displacement":
                                Factp.Add(-0.245382); Factp.Add(0.259016); Factp.Add(-0.01363);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                                break;

                        }
                    }
                    break;

                case "Heat exchanger":
                    switch (type)
                    {
                        case "Bayonet":
                        case "Fixed tube sheet":
                        case "Floating head":
                        case "Kettle reboiler":
                        case "U-tube":
                            if (pressao < 5)
                            {
                                Factp.Add(0); Factp.Add(0); Factp.Add(0);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                            }
                            else if (pressao < 140 | pressao > 5)
                            {
                                Factp.Add(0.03881); Factp.Add(-0.11272); Factp.Add(0.08183);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                            }

                            break;
                        case "Double pipe":
                        case "Multiple pipes":
                            if (pressao < 40)
                            {
                                Factp.Add(0); Factp.Add(0); Factp.Add(0);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                            }
                            else if (pressao < 100 | pressao > 40)
                            {
                                Factp.Add(-0.6072); Factp.Add(-0.9120); Factp.Add(0.3327);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                            }
                            else if (pressao < 300 | pressao > 100)
                            {
                                Factp.Add(13.1467); Factp.Add(-12.6574); Factp.Add(3.0705);
                                Fp = Math.Pow(10, (Factp[0] + Factp[1] * Math.Log10(pressao) + Factp[2] * Math.Pow(Math.Log10(pressao), 2)));
                            }

                            break;
                    }
                
                    break;
                



            }
        }

        #region  Cálculo do stress 
        private double calculoStress(string material, double Temperatura)
        {
            

            switch (material)
            {
                case "Carbono steel":

                    if (Temperatura > 482.2 && Temperatura < 0) // Temperatura em graus Celsius
                    {
                        Console.WriteLine("Temperatura acima dos limites para o material!");
                        break;
                    }
                    else if (Temperatura <= 260) // Temperatura em graus Celsius
                    {
                        this.stress = 12.9 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura <= 371.1) // Temperatura em graus Celsius
                    {
                        this.stress = 11.5 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura < 482.2) // Temperatura em graus Celsius
                    {
                        this.stress = 5.9 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }

                    break;

                case "ss 304":

                    if (Temperatura > 815.5 && Temperatura < 0) // Temperatura em graus Celsius
                    {
                        Console.WriteLine("Temperatura acima dos limites para o material!");
                        break;
                    }
                    else if (Temperatura <= 38) // Temperatura em graus Celsius
                    {
                        this.stress = 20 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura <= 149) // Temperatura em graus Celsius
                    {
                        this.stress = 15 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura <= 260) // Temperatura em graus Celsius
                    {
                        this.stress = 12.9 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura <= 371.1) // Temperatura em graus Celsius
                    {
                        this.stress = 11.7 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }
                    else if (Temperatura < 482.2) // Temperatura em graus Celsius
                    {
                        this.stress = 10.8 * 6894760; // conversão de ksi para N/m²
                        return stress;
                    }

                    break;
                    
            }
            return stress;

        }

        #endregion

        #region  Densidade
        private void Densidade(string material)
        {
            
            switch (material)
            {
                case "Carbon steel":
                    dens = 7850; // kg/m³
                    break;
                case "ss 304":
                    dens = 8000; // kg/m³
                    break;
            }
        }
        #endregion

        #region Cálculo da espessura
        private double calculoEspessura(double diam, double pressao,string material, double Temperatura,string pos)
        {
            calculoStress(material,Temperatura);
            if (pos == "Vertical")
            {
                double esp1 = (pressao * diam) / ((2 * stress * 1) - (1.2 * pressao)); // Equação 14.13 Towler
                esp1 = Math.Round(esp1, 2); // espessura em mm

                double esp2 = (pressao * diam) / ((4 * stress * 1) - (0.8 * pressao)); // Equação 14.14 Towler
                esp2 = Math.Round(esp2, 2); // espessura em mm

                if (esp1 > esp2)
                {
                    return esp = esp1;
                }
                else
                {
                    return esp = esp2;
                }
            }
            else
            {
                double esp1 = (pressao * diam) / ((2 * stress * 1) - (1.2 * pressao)); // Equação 14.13 Towler
                esp1 = Math.Round(esp1, 3); // espessura em mm

                double esp2 = (pressao * diam) / ((4 * stress * 1) - (0.8 * pressao)); // Equação 14.14 Towler
                esp2 = Math.Round(esp2, 3); // espessura em mm

                if (esp1 > esp2)
                {
                   return esp = esp1;
                }
                else
                {
                    return esp = esp2;
                }
            }



        }
        #endregion

        public double getvesselFp()
        {
            return VesFp;
        }
        public double setFpVessel(double diam, double pressao, string material, double Temperatura, string pos)
        {
            calculoEspessura(diam,  pressao,  material,  Temperatura,  pos);  calculoStress( material,  Temperatura);
            if (esp < 0.0063 && pressao > -0.5)
            {
                VesFp = 1;
            }
            else if ( esp > 0.0063 && pressao > -0.5)
            {
                double aux1 = ((pressao + 1) * diam) / ((2 * stress * 0.9) - 1.2 * (pressao - 1));
                VesFp = (aux1 + 0.00315) / 0.0063;
            }
            else if (pressao < -0.5)
            {
                VesFp = 1.25;
            }
            return VesFp;
        }

        #endregion

        #region Atributos de custo
        public List<double> K = new List<double>(3);
        public List<double> fCusto(string eq, string type)
        #endregion


        #region Fatores de custo


        {
            switch (eq)
            {
                case "Pump":

                    switch (type)
                    {
                        case "Reciprocating":
                            K.Add(3.8696); K.Add(0.3161); K.Add(0.1220);
                            break;
                        case "Positive displacement":
                            K.Add(3.4771); K.Add(0.1350); K.Add(0.1438);
                            break;
                        case "Centrifugal":
                            K.Add(3.3892); K.Add(0.0536); K.Add(0.1538);
                            break;
                    }

                    break;
                case "Heat exchanger":
                    switch (type)
                    {
                        case "Bayonet":
                            K.Add(4.2768); K.Add(-0.0495); K.Add(0.1431);
                            break;
                        case "Fixed tube sheet":
                            K.Add(4.3247); K.Add(-0.3030); K.Add(0.1634);
                            break;
                        case "Floating head":
                            K.Add(4.8306); K.Add(-0.8509); K.Add(0.3187);
                            break;
                        case "Kettle reboiler":
                            K.Add(4.4646); K.Add(-0.5277); K.Add(0.3955);
                            break;
                        case "U-tube":
                            K.Add(4.1884); K.Add(-0.2503); K.Add(0.1974);
                            break;
                        case "Double pipe":
                            K.Add(3.3444); K.Add(0.2745); K.Add(-0.0472);
                            break;
                        case "Multiple pipes":
                            K.Add(2.7652); K.Add(0.7282); K.Add(0.0783);
                            break;
                    }
                    break;
                case "Vessel":
                    switch (type)
                    {
                        case "Horizontal":
                            K.Add(3.5565); K.Add(0.3776); K.Add(0.0905);
                            break;
                        case "Vertical":
                            K.Add(3.4974); K.Add(0.4485); K.Add(0.1074);
                            break;
                    }
                    break;

                case "Tray":
                    switch (type)
                    {
                        case "Sieve":
                            K.Add(2.9949); K.Add(0.4465); K.Add(0.3961);
                            break;
                        case "Valve":
                            K.Add(3.3322); K.Add(0.4838); K.Add(0.3434);
                            break;
                        case "Deminister":
                            K.Add(2.2353); K.Add(0.4838); K.Add(0.3434);
                            break;

                    }

                    break;
            }


            return K;
        }


        #endregion


        #region Fatores para pratos de coluna

        public int nump;
        public double Fq;
        public double Fbm;
        public string mat;


        public double getFq()
        {
            return Fq;
        }
        public double getFbm()
        {
            return Fbm;
        }
        public void setFq(int nump)
        {
            if (nump < 20)
            {
                var aux = 0.4771 + 0.08516 * Math.Log10(nump) - 0.3473 * (Math.Pow(Math.Log10(nump), 2));
                Fq = Math.Pow(10, aux);
            }
            else
            {
                Fq = 1;
            }
                
        }
        public void setFbm(string mat,string type)
        {
            if (type == "Sieve" | type == "Valve")
            {
                switch (mat)
                {
                    case "Carbon Steel":
                        Fbm = 1;
                        break;

                    case "ss 304":
                        Fbm = 1.8;
                        break;
                }
            }
            else
            {
                
               Fq = 1.0;
                       
                
            }


        }
        #endregion

        #region Atributos de materiais
        public double Fm;
        #endregion

        #region Fatores de custo
        public double getFm()
        {

            return Fm;
        }
        public void setFm(string eq, string type, string material)
        
        {
            switch (eq)
            {
                case "Pump":

                    switch (type)
                    {
                        case "Reciprocating":
                            if(material == "Cast iron")
                            {
                                Fm = 1;
                            }
                            else if (material == "Carbon steel")
                            {
                                Fm = 1.4;
                            }
                            else
                            {
                                Fm = 2.4;
                            }
                            break;
                        case "Positive displacement":
                            if (material == "Cast iron")
                            {
                                Fm = 1;
                            }
                            else if (material == "Carbon steel")
                            {
                                Fm = 1.4;
                            }
                            else
                            {
                                Fm = 2.7;
                            }
                            break;
                        case "Centrifugal":
                            if (material == "Cast iron")
                            {
                                Fm = 1;
                            }
                            else if (material == "Carbon steel")
                            {
                                Fm = 1.55;
                            }
                            else
                            {
                                Fm = 2.28;
                            }
                            break;
                    }

                    break;
                case "Heat exchanger":
                    switch (type)
                    {
                        case "Bayonet":                                         
                        case "Kettle reboiler":                          
                        case "U-tube":
                            if (material == "Cu-shell/Cu-tube")
                            {
                                Fm = 1.65;
                            }
                            else if (material == "CS-shell/SS-tube")
                            {
                                Fm = 1.8;
                            }
                            else
                            {
                                Fm = 2.7;
                            }
                          
                            break;
                        case "Fixed tube sheet":
                        case "Floating head":
                        case "Double pipe":
                        case "Multiple pipes":
                            if (material == "CS-shell/CS-tube")
                            {
                                Fm = 1;
                            }
                            else
                            {
                                Fm = 1.4;
                            }
                            break;
                    }
                    break;
                case "Vessel":
                    switch (type)
                    {
                        case "Horizontal":
                        case "Vertical":
                            if (material == "Carbon steel")
                            {
                                Fm = 1;

                            }
                            else
                            {
                                Fm = 3.15;
                            }
                            break;
                    }
                    break;
                                    
            }


            
        }


        #endregion


    }

}