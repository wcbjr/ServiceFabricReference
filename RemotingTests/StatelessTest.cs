using System;
using StatelessRemotingService;
using NUnit.Framework;
using System.Collections.Generic;
using ServiceFabricMocks;
using System.Fabric;
using Microsoft.ServiceFabric.Services.Remoting.Client;


namespace RemotingTests
{
    using StatelessRemotingService = StatelessRemotingService.StatelessRemotingService;

    [TestFixture]
    public class StatelessTest
    {
        [TestCase()]
        public void StatelessRemotingTest()
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
            StatelessServiceContext context = new StatelessServiceContext(
                new NodeContext("Node0", new NodeId(0, 1), 0, "NodeType1", "http://localhost"),
                packageContext,
                "StatelessRemotingService",
                new Uri("fabric:/ServiceFabricReference/StatelessRemotingService"),
                null,
                new Guid(),
                long.MaxValue
                );
            IStatelessRemotingService testClient = new StatelessRemotingService(context);

            List<int> expected = new List<int>() {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            CollectionAssert.IsSubsetOf(testClient.CalcFibSequence(5).Result, expected);
        }
    }
}
