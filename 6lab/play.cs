using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6lab
{
    class play
    {
        public int[,] field;
        int N = 0;

        public bool set(int n)
        {
            if (n<=0)
            {
                return false;
            }
            else
            {
                N = n;
                field = new int[n, n];
                return true;
            }
        }

        public bool check(int x, int y)
        {
            bool res = false;

            int minx = x - 1;
            int miny = y - 1;
            if (minx < 0) minx = 0;
            if (miny < 0) miny = 0;

            int maxx = x + 1;
            if (maxx > field.GetLength(0) - 1) maxx = field.GetLength(0) - 1;
            int maxy = y + 1;
            if (maxy > field.GetLength(1) - 1) maxy = field.GetLength(1) - 1;

            for (int i = minx; i <= maxx; i++)
            {
                for (int j = miny; j <= maxy; j++)
                {
                    if(field[i, j] == 0)
                    {
                        res = true;
                        break;
                    }
                }
                if (res == true) break;
            }


            return res;
        }


        public void mines(int n)
        {
            Random rng = new Random();

            for(int m = 0; m < n; m++)
            {
                int x = rng.Next(field.GetLength(0));
                int y = rng.Next(field.GetLength(1));

                if (field[x, y] == 9)
                {
                    m--;
                    continue;
                }
                else
                {
                    field[x, y] = 9;

                }


                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == 9)
                        {
                            if (check(i, j) == false)
                            {
                                field[x, y] = 0;
                                m--;
                                break;
                            }
                        }
                    }
                    if (field[x, y] == 0) break;
                }

            }

        }

        public void calc()
        {

            for (int i1 = 0; i1 < field.GetLength(0); i1++)
                for (int j1 = 0; j1 < field.GetLength(1); j1++)
                {
                    if (field[i1, j1] == 0)
                    {
                        int s = 0;
                       
                        int minx = i1 - 1;
                        int miny = j1 - 1;
                        if (minx < 0) minx = 0;
                        if (miny < 0) miny = 0;

                        int maxx = i1 + 1;
                        int maxy = j1 + 1;
                        if (maxx > field.GetLength(0) - 1) maxx = field.GetLength(0) - 1;
                        if (maxy > field.GetLength(1) - 1) maxy = field.GetLength(1) - 1;

                        for (int i = minx; i <= maxx; i++)
                        {
                            for (int j = miny; j <= maxy; j++)
                            {
                                if (field[i, j] == 9)
                                {
                                    s++;
                                    
                                }
                            }
                            
                        }

                        field[i1, j1] = s;

                    }
                }
        }

        public int get(int x, int y)
        {
            return field[x, y];
        }


    }
}
