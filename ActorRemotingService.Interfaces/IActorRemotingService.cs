using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace ActorRemotingService.Interfaces
{

    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IActorRemotingService : IActor
    {
        Task<List<int>> CalcFibSequence(int number);
    }
}
