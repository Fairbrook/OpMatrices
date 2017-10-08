using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpMatrices.Types;

namespace OpMatrices.Types
{
    public class Matriz<T> where T: new()
    {
        private T[,] Arreglo;
        private int _Nfilas;
        private int _NColum;
        public int Nfilas
        {
            get{return _Nfilas;}
        }
        public int NColum
        {
            get{return _NColum;}
        }
        public bool setMatriz(int Nf, int Nc, T[,] usr)
        {
            if (Nf <= 0 || Nc <= 0) return false;
            if((Nf*Nc)!=usr.Length) return false;
            this._Nfilas = Nf;
            this._NColum = Nc;

            this.Arreglo = new T[Nf, Nc];
            for (int i = 0; i < Nf; i++)
            {
                for (int j = 0; j < Nc; j++)
                {
                    Arreglo[i, j] = usr[i, j];
                }
            }
            return true;
        }
        public bool setItem(int F, int C, T Data)
        {
            if (F < 0 || C < 0) return false;
            if (F >= Nfilas || C >= NColum) return false;
           this.Arreglo[F, C] = Data;
            return true;
        }
        public T[,] getMatriz()
        {
            return this.Arreglo;
        }
        public T getItem(int F, int C)
        {
            if (F < 0 || C < 0) throw new System.ArgumentOutOfRangeException("Negative Index");
            if (F >= Nfilas || C >= NColum) throw new System.ArgumentOutOfRangeException("Out of Range");
            return this.Arreglo[F,C];
        }
    }
}
