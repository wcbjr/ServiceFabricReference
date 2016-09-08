using System.Collections.Generic;

namespace FibonacciSeq
{
    /// <summary>
    /// This is a Fibonacci sequence of n length
    /// </summary>
    public class FibSeq : IFibSeq
    {
        /// <summary>
        /// Generates a list of the Fibonacci sequence of n length
        /// </summary>
        /// <param name="number">The number of parameters to calucate of the sequence</param>
        /// <returns></returns>
        public List<int> CalcSequence(int number)
        {
            List<int> sequence = new List<int>();
            int[] values = {0, 0};
            for (int i = 0; i < number; i++)
            {
                if (values[0] == 0 && values[1] == 0)
                {
                    values[0] = 1;
                    sequence.Add(values[0]);
                    continue;
                }

                int sum = values[0] + values[1];
                sequence.Add(sum);
                values[1] = values[0];
                values[0] = sum;
            }
            return sequence;
        }

    }
}
