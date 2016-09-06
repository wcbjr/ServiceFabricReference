using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSeq
{
    public class FibSeq : IFibSeq
    {
        public List<int> CalcSequence(int number)
        {
            List<int> sequence = new List<int>();
            int[] values = {0, 0};
            int sum = 0;
            for (int i = 0; i < number; i++)
            {
                if (values[0] == 0 && values[1] == 0)
                {
                    values[0] = 1;
                    sequence.Add(values[0]);
                    continue;
                }

                sum = values[0] + values[1];
                sequence.Add(sum);
                values[1] = values[0];
                values[0] = sum;
            }
            return sequence;
        }

    }
}
