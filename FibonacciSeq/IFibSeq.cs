using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSeq
{
    public interface IFibSeq
    {
        List<int> CalcSequence(int number);
    }
}
