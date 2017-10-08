using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpMatrices.Types
{
    public class Fraccion
    {
        private int _num, _denom;
        public int num
        {
            get
            {
                return _num;
            }
        }
        public int denom
        {
            get
            {
                return _denom;
            }
        }

        public Fraccion()
        {
            _num = 1;
            _denom = 1;
        }
        public bool setFrac(int inNum, int inDenom)
        {
            if (inDenom == 0)
                return false;
            _num = inNum;
            _denom = inDenom;
            if (_denom < 0)
            {
                _denom *= -1;
                _num *= -1;
            }
            return true;
        }
        public static Fraccion operator *(Fraccion operador1, Fraccion operador2)
        {
            Fraccion result = new Fraccion();
            result._num = operador1._num * operador2._num;
            result._denom = operador1._denom * operador2._denom;
            result.simplificar();
            return result;
        }
        public static Fraccion operator /(Fraccion operador1, Fraccion operador2)
        {
            Fraccion result = new Fraccion();
            result._num = operador1._num * operador2._denom;
            result._denom = operador1._denom * operador2._num;
            result.simplificar();
            return result;
        }
        public static Fraccion operator +(Fraccion operador1, Fraccion operador2)
        {
            Fraccion result = new Fraccion();
            int num1, num2;
            int denomCom = operador1._denom * operador2._denom;
            num1 = (denomCom / operador1._denom) * operador1._num;
            num2 = (denomCom / operador2._denom) * operador2._num;
            result._num=num1 + num2;
            result._denom = denomCom;
            result.simplificar();
            return result;
        }
        public static Fraccion operator -(Fraccion operador1, Fraccion operador2)
        {
            Fraccion result = new Fraccion();
            int num1, num2;
            int denomCom = operador1._denom * operador2._denom;
            num1 = (denomCom / operador1._denom) * operador1._num;
            num2 = (denomCom / operador2._denom) * operador2._num;
            result._num = num1 - num2;
            result._denom = denomCom;
            result.simplificar();
            return result;
        }
        public void simplificar()
        {
            int result = 1;
            int aux = (_denom<_num)? _num:_denom;
            do
            {
                result++;
                while (((this._denom % result) == 0) && ((this._num % result) == 0))
                {
                    this.setFrac(this._num / result, this._denom / result);
                }
            } while (result<aux);
        }
    }
}
