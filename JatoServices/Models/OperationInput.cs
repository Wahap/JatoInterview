using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JatoServices.Models
{
    public class OperationInput<T>
    {
        public T Num1 { get; set; }
        public T Num2 { get; set; }
    }
}
