using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JatoServices.Models
{
    public interface IOperation
    {
        OperationOutput<int> Do(OperationInput<int> input);
        OperationOutput<long> Do(OperationInput<long> input);
        OperationOutput<decimal> Do(OperationInput<decimal> input);
    }
}
