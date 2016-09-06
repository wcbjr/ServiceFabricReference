using System;
using NUnit.Framework;
using System.Fabric;
using System.Collections.Generic;
using ServiceFabricMocks;
using StatefulRemotingService;

namespace RemotingTests
{

    using StatefulRemotingService = StatefulRemotingService.StatefulRemotingService;

    [TestFixture]
    public class StatefulTest
    {
        [TestCase()]
        public void StatefulRemotingTest()
        {
            ICodePackageActivationContext packageContext = new MockCodePackageActivationContext(
                "fabric:/ServiceFabricReference",
                "StatefulRemotingService",
                "code",
                "1.0.0",
                Guid.NewGuid().ToString(),
                @"C:\Log",
                @"C:\Temp",
                @"C:\Work",
                "ServiceManifest",
                "1.0.0"
                );
            StatefulServiceContext context = new StatefulServiceContext(
                new NodeContext("Node0", new NodeId(0, 1), 0, "NodeType1", "http://localhost"), 
                packageContext,
                "StatefulRemotingService",
                new Uri("fabric:/ServiceFabricReference/StatefulRemotingService"),
                null,
                new Guid(),
                long.MaxValue
                );
            MockReliableStateManager stateManager = new MockReliableStateManager();
            IStatefulRemotingService testClient = new StatefulRemotingService(context, stateManager);

            List<int> expected = new List<int>() { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            CollectionAssert.IsSubsetOf(testClient.CalcFibSequence(5).Result, expected);

        }
    }
}
