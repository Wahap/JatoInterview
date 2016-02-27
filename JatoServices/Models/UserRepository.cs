using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using JatoServices.Common;
using JatoServices.Concrete;
using JatoServices.Common;

namespace JatoServices.Models
{

    public class UserRepository
    {

        private static JATODBEntities _jatodb = new JATODBEntities();
        private static MongoDBEntities _Mongodb = new MongoDBEntities();

        public static User GeTUser(int id)
        {
            var query = from user in _jatodb.User
                        where user.Id == id
                        select user;

            return query.SingleOrDefault();

        }

        public static bool InsertUser(User user)
        {
            try
            {
                _jatodb.User.Add(user);
                _jatodb.SaveChanges();
                _Mongodb.CreateUser(user);
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public static bool Login(string userName, string password)
        {
            var user = from usr in _jatodb.User
                       where usr.Password == password && usr.Username == userName
                       select usr;


            if (user.Count() != 0)
            {
                return true;

            }
            return false;


        }

        public static void InsertOperations(UserOperations opr)
        {
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


        public static string Add(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Sum, number1, number2);
        }

        public static string Sub(string number1, string number2)
        {
            return MathOperation(Operations.Operation.Sub, number1, number2);
        }

        public static string Multiply(string number1, string number2)
        {

            return MathOperation(Operations.Operation.Multiply, number1, number2);

        }

        public static string Divide(string number1, string number2)
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
    }
}