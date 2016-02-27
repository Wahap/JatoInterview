using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JatoServices.Concrete
{
    public abstract class OperationProvider<T>
    {
        public abstract T Sum(T number1, T number2);
        public abstract T Sub(T number1, T number2);
        public abstract T Multiply(T number1, T number2);
        public abstract T Divide(T number1, T number2);
    }

    public class DoubleOperationProvider : OperationProvider<double>
    {

        public override double Sum(double number1, double number2)
        {
            return number1 + number2;
        }

        public override double Sub(double number1, double number2)
        {
            return number1 - number2;
        }

        public override double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public override double Divide(double number1, double number2)
        {
            return number1 / number2;
        }
    }
    public  class IntOperationProvider : OperationProvider<int>
    {
        public override int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public override int Sub(int number1, int number2)
        {
            return number1 - number2;
        }

        public override int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public override int Divide(int number1, int number2)
        {
            return number1 / number2;
        }
    }
    public class DecimalOperationProvider : OperationProvider<decimal>
    {
      

        public override decimal Sum(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public override decimal Sub(decimal number1, decimal number2)
        {
            return number1 - number2;
        }

        public override decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        public override decimal Divide(decimal number1, decimal number2)
        {
            return number1 / number2;
        }
    }
}