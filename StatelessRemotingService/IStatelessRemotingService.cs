using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatelessRemotingService
{
    public interface IStatelessRemotingService : IService
    {
        Task<List<int>> CalcFibSequence(int number);
    }
}
