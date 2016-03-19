using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JatoServices.Abstract;
using JatoServices.Concrete;
using JatoServices.Common;

namespace JatoServices.Models
{
    public class UserOperationRepository : IUserOperationRepository
    {
        private static JATODBEntities _jatodb = new JATODBEntities();
        private static MongoDBEntities _Mongodb;
        public string Add(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Sum, number1, number2);
        }


        public string Sub(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Sub, number1, number2);
        }

        public string Multiply(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Multiply, number1, number2);
        }

        public string Divide(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Divide, number1, number2);
        }
        private static string MathOperation(Operations.Operation operation, string number1, string number2)
        {

            double num;
            decimal dcml;
            string returnString = "";
            switch (operation)
            {
                case Operations.Operation.Sum:

                    if (double.TryParse(number1, out num))
                    {
                        DoubleOperationProvider op = new DoubleOperationProvider();
                        double returnValue = op.Sum((Convert.ToDouble(number1)), Convert.ToDouble(number2));
                        returnString = returnValue.ToString();
                    }
                    else if (Decimal.TryParse(number1, out dcml))
                    {

                        DecimalOperationProvider op = new DecimalOperationProvider();
                        decimal returnValue = op.Sum((Convert.ToDecimal(number1)), Convert.ToDecimal(number2));
                        returnString = returnValue.ToString();
                    }
                    else
                    {

                        IntOperationProvider op = new IntOperationProvider();
                        decimal returnValue = op.Sum((Convert.ToInt32(number1)), Convert.ToInt32(number2));
                        returnString = returnValue.ToString();
                    }
                    break;


                case Operations.Operation.Sub:
                    if (double.TryParse(number1, out num))
                    {
                        DoubleOperationProvider op = new DoubleOperationProvider();
                        double returnValue = op.Sub((Convert.ToDouble(number1)), Convert.ToDouble(number2));
                        returnString = returnValue.ToString();

                    }
                    else if (Decimal.TryParse(number1, out dcml))
                    {

                        DecimalOperationProvider op = new DecimalOperationProvider();
                        decimal returnValue = op.Sub((Convert.ToDecimal(number1)), Convert.ToDecimal(number2));
                        returnString = returnValue.ToString();
                    }
                    else
                    {

                        IntOperationProvider op = new IntOperationProvider();
                        decimal returnValue = op.Sub((Convert.ToInt32(number1)), Convert.ToInt32(number2));
                        returnString = returnValue.ToString();
                    } break;

                case Operations.Operation.Multiply:
                    if (double.TryParse(number1, out num))
                    {
                        DoubleOperationProvider op = new DoubleOperationProvider();
                        double returnValue = op.Multiply((Convert.ToDouble(number1)), Convert.ToDouble(number2));
                        returnString = returnValue.ToString();

                    }
                    else if (decimal.TryParse(number1, out dcml))
                    {
                        DecimalOperationProvider op = new DecimalOperationProvider();
                        decimal returnValue = op.Multiply((Convert.ToDecimal(number1)), Convert.ToDecimal(number2));
                        returnString = returnValue.ToString();
                    }
                    else
                    {
                        IntOperationProvider op = new IntOperationProvider();
                        decimal returnValue = op.Multiply((Convert.ToInt32(number1)), Convert.ToInt32(number2));
                        returnString = returnValue.ToString();
                    }
                    break;
                case Operations.Operation.Divide:
                    if (double.TryParse(number1, out num))
                    {
                        DoubleOperationProvider op = new DoubleOperationProvider();
                        double returnValue = op.Divide((Convert.ToDouble(number1)), Convert.ToDouble(number2));
                        returnString = returnValue.ToString();

                    }
                    else if (decimal.TryParse(number1, out dcml))
                    {
                        DecimalOperationProvider op = new DecimalOperationProvider();
                        decimal returnValue = op.Divide((Convert.ToDecimal(number1)), Convert.ToDecimal(number2));
                        returnString = returnValue.ToString();
                    }
                    else
                    {
                        IntOperationProvider op = new IntOperationProvider();
                        decimal returnValue = op.Divide((Convert.ToInt32(number1)), Convert.ToInt32(number2));
                        returnString = returnValue.ToString();
                    }
                    break;



            }
            return returnString;
        }


        public void InsertOperations(UserOperations opr)
        {
            _Mongodb = new MongoDBEntities();
            try
            {
                _jatodb.UserOperations.Add(opr);
                _jatodb.SaveChanges();
                _Mongodb.CreateUserOperaions(opr);


            }
            catch (Exception)
            {

                throw null;
            }
        }
    }
}