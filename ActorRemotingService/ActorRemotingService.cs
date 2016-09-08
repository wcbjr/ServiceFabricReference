using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;
using ActorRemotingService.Interfaces;
using ServiceFabricMocks;
using FibonacciSeq;

namespace ActorRemotingService
{

    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    public class ActorRemotingService : MockableActor, IActorRemotingService
    {
        public ActorRemotingService(){}

        public ActorRemotingService(IActorStateManager stateManager)
        {
            base.StateManager = stateManager;
        }

        public async Task<List<int>> CalcFibSequence(int number)
        {
            IFibSeq fibSequence = new FibSeq();
            var myQueue = await this.StateManager.GetOrAddStateAsync("myState",new List<int>());

            List<int> sequence = fibSequence.CalcSequence(number);
            foreach (var i in sequence)
            {
                myQueue.Add(i);
            }
            return myQueue;
        }
    }
}
