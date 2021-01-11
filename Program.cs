using System;
using System.Collections.Generic;
using System.Linq;

namespace VRRN
{
    class Program
    {
        static void Main(string[] args)
        {
            double K = 0.14;
            int[] V1V1 = { -100000, 50000, 100000, 200000 };
            int[] V2V1 = V1V1;
            int[] V1V2 = { 0, 0, 0, 0 };
            int[] V2V2 = { 22000, 22000, 22000, 22000 };
            double[] pT = new double [4];
            pT[0] = K;
            pT[1] = K + 0.16;
            pT[2] = K + 0.2;
            pT[3] = (0.64 - 3 *K);
            for(int i =0;i<4;i++)
            {
                double InputValue;
                InputValue = pT[i];
                InputValue = Math.Round(InputValue, 2);
                pT[i] = InputValue;
            }

            double[] E1 = { 1, 0.1, 0, 0 };
            double[] E2 = { 0, 0.9, 1, 0 };
            double[] E3 = { 0, 0, 0, 1 };
            double[] pE = new double[3];

            for (int i = 0; i < 3 ; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = pT[j] * E1[j];
                        pE[0] +=a;                       
                    }     
                }

                if(i == 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double b = pT[j] * E2[j];
                        pE[1] +=b;
                    }                 
                }

                if(i == 2)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double c = pT[j] * E3[j];
                        pE[2] +=c;                       
                    }                                  
                }              
            }
            for (int i = 0; i < 3; i++)
            {
                double InputValue;
                InputValue = pE[i];
                InputValue = Math.Round(InputValue, 2);
                pE[i] = InputValue;
            }
            double[] pET1 = new double[4];
            double[] pET2 = new double[4];
            double[] pET3 = new double[4];

            for(int i = 0; i < 4; i++)
            {
                pET1[i] = (pT[i] * E1[i]) / pE[0];
                pET2[i] = (pT[i] * E2[i]) / pE[1];
                pET3[i] = (pT[i] * E3[i]) / pE[2];
            }

            double[] step4 = new double[6];
            double[] step3 = new double[3];
            double step2V1 = 0;
            
            for(int i = 0; i < 6; i++)
            {
                if(i == 0)
                {
                    for(int j =0; j < 4; j++)
                    {
                        double a = V1V1[j] * pET1[j];
                        step4[i] += a;
                    }                   
                }
                if (i == 2)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V1V1[j] * pET2[j];
                        step4[i] += a;
                    }
                }
                if (i == 4)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V1V1[j] * pET3[j];
                        step4[i] += a;
                    }
                }
                if (i == 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V1V2[j] * pET1[j];
                        step4[i] += a;
                    }
                }
                if (i == 3)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V1V2[j] * pET2[j];
                        step4[i] += a;
                    }
                }
                if (i == 5)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V1V2[j] * pET3[j];
                        step4[i] += a;
                    }
                }
            }

            for(int i = 0; i < 3; i++)
            {
                if(i == 0)
                {
                    step3[i] = Math.Max(step4[0], step4[1]);
                }
                if (i == 1)
                {
                    step3[i] = Math.Max(step4[2], step4[3]);
                }
                if (i == 2)
                {
                    step3[i] = Math.Max(step4[4], step4[5]);
                }
            }

            for(int i = 0; i < 3; i++)
            {
                double a = step3[i] * pE[i];
                step2V1 += a;
            }

            step2V1 -= 5000;

            double[] step4V2 = new double[2];

            for(int i = 0; i <2; i++)
            {
                if (i == 0)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        double a = V2V1[j] * pT[j];
                        step4V2[i] += a;
                    }
                }
                if (i == 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        double a = V2V2[j] * pT[j];
                        step4V2[i] += a;
                    }
                }
            }
            double step3V2 = Math.Max(step4V2[0], step4V2[1]);
            double step2V2 = step3V2;
            Console.WriteLine(step2V1);
            Console.WriteLine(step2V2);
            if(step2V1 > step2V2)
            {
                Console.WriteLine("Optimal strategy is  V1.");
            }
            else if(step2V2> step2V1)
            {
                Console.WriteLine("Optimal strategy is  V2");
            }
            Console.ReadLine();
        }
    }
}
