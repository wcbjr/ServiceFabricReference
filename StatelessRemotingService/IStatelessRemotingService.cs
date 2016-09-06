using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessRemotingService
{
    public interface IStatelessRemotingService : IService
    {
        Task<List<int>> CalcFibSequence(int number);
    }
}
