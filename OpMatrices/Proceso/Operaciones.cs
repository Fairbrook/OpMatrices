using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpMatrices.Types;

namespace OpMatrices.Proceso
{
    public class Operaciones
    {
        static public Matriz<int> suma(Matriz<int> a, Matriz<int> b)
        {
            if (a.Nfilas != b.Nfilas || a.NColum != b.NColum) throw new System.FormatException();
            Matriz<int> result = new Matriz<int>();
            int[,] frac = new int[a.Nfilas, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = a.getItem(i, j) + b.getItem(i, j);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<double> suma(Matriz<double> a, Matriz<double> b)
        {
            if (a.Nfilas != b.Nfilas || a.NColum != b.NColum) throw new System.FormatException();
            Matriz<double> result = new Matriz<double>();
            double[,] frac = new double[a.Nfilas, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = a.getItem(i, j) + b.getItem(i, j);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<int> resta(Matriz<int> a, Matriz<int> b)
        {
            if (a.Nfilas != b.Nfilas || a.NColum != b.NColum) throw new System.FormatException();
            Matriz<int> result = new Matriz<int>();
            int[,] frac = new int[a.Nfilas, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = a.getItem(i, j) - b.getItem(i, j);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<double> resta(Matriz<double> a, Matriz<double> b)
        {
            if (a.Nfilas != b.Nfilas || a.NColum != b.NColum) throw new System.FormatException();
            Matriz<double> result = new Matriz<double>();
            double[,] frac = new double[a.Nfilas, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = a.getItem(i, j) - b.getItem(i, j);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<int> mult(Matriz<int> a, Matriz<int> b)
        {
            if (a.NColum != b.Nfilas) throw new System.FormatException();
            Matriz<int> result = new Matriz<int>();
            int[,] frac = new int[a.Nfilas, b.NColum];

            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < b.NColum; j++)
                {
                    frac[i, j] = new int();
                    frac[i, j] = 0;
                }
            }

            for (int x = 0; x < a.Nfilas; x++)
            {
                for (int y = 0; y < b.NColum; y++)
                {
                    for (int z = 0; z < a.NColum; z++)
                    {
                        frac[x, y] += a.getItem(x, z) * b.getItem(z, y);
                    }
                }
            }
            result.setMatriz(a.Nfilas, b.NColum, frac);
            return result;
        }
        static public Matriz<double> mult(Matriz<double> a, Matriz<double> b)
        {
            if (a.NColum != b.Nfilas) throw new System.FormatException();
            Matriz<double> result = new Matriz<double>();
            double[,] frac = new double[a.Nfilas, b.NColum];

            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < b.NColum; j++)
                {
                    frac[i, j] = new int();
                    frac[i, j] = 0;
                }
            }

            for (int x = 0; x < a.Nfilas; x++)
            {
                for (int y = 0; y < b.NColum; y++)
                {
                    for (int z = 0; z < a.NColum; z++)
                    {
                        frac[x, y] += a.getItem(x, z) * b.getItem(z, y);
                    }
                }
            }
            result.setMatriz(a.Nfilas, b.NColum, frac);
            return result;
        }
        static public Matriz<Fraccion> inver(Matriz<Fraccion> a)
        {
            if (a.NColum != a.Nfilas) throw new System.FormatException();
            int y = 1;
            Matriz<Fraccion> result = new Matriz<Fraccion>();
            Fraccion aux = new Fraccion();
            Fraccion aux1 = new Fraccion();
            Fraccion[,] frac = new Fraccion[a.NColum, a.NColum];
            
            //Hacer la matriz auxiliar 1 y 0
            for (int i = 0; i < a.NColum; i++)
            {
                for (int j = 0; j < a.Nfilas; j++)
                {
                    if (j == i)
                    {
                        frac[i, j] = new Fraccion();
                        frac[i, j].setFrac(1, 1);
                    }
                    else
                    {
                        frac[i, j] = new Fraccion();
                        frac[i, j].setFrac(0, 1);
                    }
                }
            }

            //For principal del proceso. Volver a la matriz original igual a la auxiliar
            for (int i = 0; i < a.NColum; i++)
            {
                //Convertir el número correspondiente en 1
                //En caso de que no sea 0
                if (a.getItem(i, i).num != 0)
                {
                    aux.setFrac(a.getItem(i, i).denom, a.getItem(i, i).num);
                    for (int x = 0; x < a.NColum; x++)
                    {
                        a.setItem(i, x, aux * a.getItem(i, x));
                        frac[i, x] *= aux;
                    }
                }
                //Si es 0 se busca cambiar las filas
                else
                {
                    while (a.getItem(i, i).num == 0)
                    {
                        //Si ninguna fila tiene un número diferente de 0 en esa posición se lanza una excepción
                        if (y >= a.Nfilas) throw new System.Exception();
                        if (y != i)
                        {
                            for (int x = 0; x < a.NColum; x++)
                            {
                                aux = a.getItem(i, x);
                                a.setItem(i, x, a.getItem(y, x));
                                a.setItem(y, x, aux);
                                aux1 = frac[i, x];
                                frac[i, x] = frac[y, x];
                                frac[y, x] = aux1;
                            }
                        }
                        y++;
                    }
                    //Una vez cambiada la fila se vuelve un 1 el número correscondiente (i,i)
                    aux = new Fraccion();
                    aux.setFrac(a.getItem(i, i).denom, a.getItem(i, i).num);
                    for (int x = 0; x < a.NColum; x++)
                    {
                        a.setItem(i, x, aux * a.getItem(i, x));
                        frac[i, x] *= aux;
                    }
                }

                //Volver el resto de los elementos de la columna i 0
                for (int j = 0; j < a.NColum; j++)
                {
                    if (j != i && a.getItem(j, i).num != 0)
                    {
                        aux1 = a.getItem(j, i);
                        for (int x = 0; x < a.NColum; x++)
                        {
                            aux = a.getItem(i, x) * aux1;
                            a.setItem(j, x, a.getItem(j, x) - aux);
                        }
                        for (int x = 0; x < a.NColum; x++)
                        {
                            aux = frac[i, x] * aux1;
                            frac[j, x] -= aux;
                        }
                    }
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<Fraccion> MtrzIntToFrac(Matriz<int> a)
        {
            Matriz<Fraccion> result = new Matriz<Fraccion>();
            Fraccion[,] frac = new Fraccion[a.NColum, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = new Fraccion();
                    frac[i, j].setFrac(a.getItem(i, j), 1);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
        static public Matriz<double> MtrzFracToDouble(Matriz<Fraccion> a)
        {
            Matriz<double> result = new Matriz<double>();
            double[,] frac = new double[a.Nfilas, a.NColum];
            for (int i = 0; i < a.Nfilas; i++)
            {
                for (int j = 0; j < a.NColum; j++)
                {
                    frac[i, j] = Convert.ToDouble(a.getItem(i, j).num) / Convert.ToDouble( a.getItem(i, j).denom);
                }
            }
            result.setMatriz(a.Nfilas, a.NColum, frac);
            return result;
        }
    }
}
