using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtonEngine
{
    public abstract class Fatores
    {

        #region Fatores de pressão

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
                        case "Byonet":
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
                                Factp.Add(-0.03881); Factp.Add(-0.11272); Factp.Add(0.08183);
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
        public double setfpVessel(double diam, double pressao, string material, double Temperatura, string pos)
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


        #region Fatores de custo

        public List<double> K = new List<double>(3);
        public List<double> fCusto(string eq, string type)
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
            }


            return K;
        }


        #endregion

    }

}