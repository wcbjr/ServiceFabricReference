using System;
using NUnit.Framework;
using NSubstitute;
using System.Fabric;
using System.Collections.Generic;
using ServiceFabricMocks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using ActorRemotingService.Interfaces;

namespace RemotingTests
{
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;

    using Microsoft.ServiceFabric.Actors.Runtime;
    using Microsoft.ServiceFabric.Services.Client;
    using Microsoft.ServiceFabric.Services.Communication.Client;

    using ActorRemotingService = ActorRemotingService.ActorRemotingService;

    [TestFixture]
    public class ActorTest
    {
        [TestCase()]
        public void ActorRemotingTest()
        {
            MockActorStateManager stateManager = new MockActorStateManager();
            IActorRemotingService proxy = new ActorRemotingService(stateManager);

            List<int> expected = new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            CollectionAssert.IsSubsetOf(proxy.CalcFibSequence(7).GetAwaiter().GetResult(), expected);
        }
    }
}
