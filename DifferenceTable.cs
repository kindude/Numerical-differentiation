using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИМВ_4
{
    class DifferenceTable
    {


        private double h;
        private double start;
        private double stop;
        private double[,] diftable;
        private string[,] diftableChar;
        private int n, m;
        private double[,] Finale;

        public DifferenceTable()
        {
            Input();
        }

        public void Input()
        {
            Console.Write("Введите начало интервала:");
            start = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите конец интервала:");
            stop = Convert.ToDouble(Console.ReadLine());
        }

        public void Step()
        {
            h = (stop - start) / 10;
        }

        public void InitMatr()
        {
            n = 11;
            m = 12;
            diftable = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    diftable[i, j] = -3333;
                }
            }
        }
        public void FormDiffTable()
        {
            diftable[0, 0] = start;
            diftable[0, 1] = Math.Tan(Math.Pow(start, 3));
            for (int i = 1; i < n; i++)
            {

                diftable[i, 0] = diftable[i - 1, 0] + h;
                diftable[i, 1] = Math.Tan(Math.Pow(diftable[i, 0], 3));


            }
        }


        public void DisplayMatr()
        {
            diftableChar = new string[n + 1, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (diftable[i, j] == -3333)
                    {
                        int p = i + 1;
                        diftableChar[p, j] = " -----   ";
                    }
                    else
                    {
                        int p = i + 1;
                        string tmp = string.Format("{0:f6}  ", diftable[i, j]);
                        diftableChar[p, j] = tmp;
                    }
                }
            }

            diftableChar[0, 0] = "X          ";
            diftableChar[0, 1] = "Y         ";
            for (int i = 2; i < m; i++)
            {
                string tmp;
                tmp = Convert.ToString(i - 1);
                tmp = "del" + tmp + "Y     ";
                diftableChar[0, i] = tmp;
            }


            for (int i = 0; i < n + 1; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < m; j++)
                {

                    Console.Write(diftableChar[i, j]);
                }
            }
        }

        public void FillingMatrix()
        {
            int q = 1;
            for (int j = 2; j < m; j++)
            {
                for (int i = 0; i < n - q; i++)
                {

                    diftable[i, j] = diftable[i + 1, j - 1] - diftable[i, j - 1];

                }
                q++;
            }


        }


      public double FirstDerivative(double x)
      {
            double sum, pr;
            double q;
            int fact = 1;
            double result=0;
            int p = 1;
            if (x < diftable[n/2, 0])
            {
                q = ((x - diftable[0, 0]) / h);

                for (int i = 2; i < m; i++)
                {
                    sum = 0;
                    for (int j = 1; j < i; j++)
                    {
                        pr = 1;
                        for (int k = 1; k < i; k++)
                        {
                            if (k == j)
                            {
                                continue;
                            }
                            else
                            {
                                pr *= (q - k+1);
                            }
                        }
                        sum += pr;
                    }
                    fact *= (i - 1);
                    result += (diftable[0, i] / fact) * sum;
                }
            }

          if(x>diftable[n/2,0])
          {


                q = (x - diftable[n-1, 0]) / h;

                for(int i=2;i<m;i++)
                {
                    sum = 0;
                    for(int j=1;j<i;j++)
                    {
                        pr = 1;
                        for(int k=1;k<i;k++)
                        {
                            if (k == j)
                            {
                                continue;
                            }
                            else
                            {
                                pr *= (q + k-1);
                            }
                        }
                        sum += pr;
                    }

                    fact *= (i - 1);
                    result += (diftable[n-1-p,i] / fact) * sum;
                    p++;
                }

          }

          
            return ((1 / h) * result);
      }

     
        public double SecondDerivative(double x)
        {
            double result=0;
            int fact = 1;
            double sum, pr,q,sum_sum;
            int p = 1;

            if(x<diftable[n / 2, 0])
            {
                q = (x - diftable[0, 0]) / h;

                for(int i=3;i<m;i++)
                {
                    sum = 0;
                    for(int j=1;j<i;j++)
                    {
                        sum_sum = 0;
                        for(int k=1;k<i;k++)
                        {
                            pr = 1;
                            if(k==j)
                            {
                                continue;
                            }
                            else
                            {
                                for(int l=1;l<i;l++)
                                {
                                    if(l==k||l==j)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        pr *= (q - l+1);
                                    }
                                }
                            }
                            sum_sum += pr;
                        }
                        sum += sum_sum;
                    }
                    fact *= (i - 2);
                    result += ((diftable[0,i] / fact) * sum);
                }

            }

            if (x > diftable[n / 2, 0])
            {
                q = (x - diftable[n-1, 0]) / h;

                for (int i = 3; i < m; i++)
                {
                    sum = 0;
                    for (int j = 1; j < i; j++)
                    {
                        sum_sum = 0;
                        for (int k = 1; k < i; k++)
                        {
                            pr = 1;
                            if (k == j)
                            {
                                continue;
                            }
                            else
                            {
                                for (int l = 1; l < i; l++)
                                {
                                    if (l == k || l == j)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        pr *= (q + l - 1);
                                    }
                                }
                            }
                            sum_sum += pr;
                        }
                        sum += sum_sum;
                    }
                    fact *= (i - 1);
                    result += ((diftable[n - 2 - p, i] / fact) * sum);
                    p++;
                }


                
            }

          


            return ((1/(h*h))*result);
        }
        public void Printf()
        {
            Console.WriteLine("");
            Console.WriteLine("     X           f(x)        f'(x)       f'(x)н      Погрешность        f''(x)       f''(x)н         Погрешность");
            for(int i=0;i<4;i++)
            {
                Console.WriteLine("\n");
                for(int j=0;j<8;j++)
                {
                    string tmp = string.Format("{0:f6}  ", Finale[i, j]);
                    Console.Write($"  {tmp}  ");
                }
            }
        }

        public void FinalTable()
        {
            
            Finale = new double[4, 8];

            Finale[0, 0] = start;
            Finale[1, 0] = start + 0.5 * h;
            Finale[2, 0] = stop - 0.5 * h;
            Finale[3, 0] = stop;

            
            for (int i=0;i<4;i++)
            {
                Finale[i,1] = Math.Tan(Math.Pow(Finale[i, 0], 3));
                Finale[i,2] = (3 * Finale[i,0] * Finale[i,0]) / ((Math.Cos(Finale[i, 0] * Finale[i, 0] * Finale[i, 0]) * Math.Cos(Finale[i, 0] * Finale[i, 0] * Finale[i, 0])));
                Finale[i, 3] = FirstDerivative(Finale[i, 0]);
                Finale[i, 4] = Math.Abs(Finale[i, 2] - Finale[i, 3]);

                Finale[i,5] = ((18 * Math.Pow(Finale[i, 0], 4) * Math.Sin(Finale[i, 0] * Finale[i, 0] * Finale[i, 0])) / Math.Cos(Finale[i, 0] * Finale[i, 0] * Finale[i, 0])) + 6 * Finale[i, 0] / (Math.Pow(Math.Cos(Finale[i, 0] * Finale[i, 0] * Finale[i, 0]), 2));
                Finale[i, 6] = SecondDerivative(Finale[i, 0]);
                
                Finale[i,7]= Math.Abs(Finale[i, 6] - Finale[i, 5]);


            }
            


        }

    }
}



