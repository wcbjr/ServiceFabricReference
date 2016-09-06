using System;
using System.Collections.Generic;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Actors.Client;
using StatelessRemotingService;
using StatefulRemotingService;
using ActorRemotingService.Interfaces;

namespace RemotingClient
{
    using Microsoft.ServiceFabric.Actors;

    class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;

            while (isContinue)
            {
                Console.Write("Enter A (stateless), B (stateful), or C (actor): ");
                string input = Console.ReadLine().ToUpper();
                Console.WriteLine();
                Console.Write("Enter the number to calculate of the Fibonacci sequence: ");
                int number = int.Parse(Console.ReadLine());

                List<int> fibSequence = new List<int>();
                switch (input)
                {
                    case "A":
                        {
                            IStatelessRemotingService client = ServiceProxy.Create<IStatelessRemotingService>(new Uri("fabric:/ServiceFabricReference/StatelessRemotingService"));
                            fibSequence = client.CalcFibSequence(number).Result;
                            break;
                        }
                    case "B":
                        {
                            ServicePartitionKey partitionKey = new ServicePartitionKey(0);
                            Uri serviceName = new Uri("fabric:/ServiceFabricReference/StatefulRemotingService");
                            IStatefulRemotingService client = ServiceProxy.Create<IStatefulRemotingService>(serviceName, 
                                partitionKey);
                            fibSequence = client.CalcFibSequence(number).Result;
                            break;
                        }
                    case "C":
                        {
                            var actorProxy = ActorProxy.Create<IActorRemotingService>(ActorId.CreateRandom(), 
                                "fabric:/ServiceFabricReference");
                            fibSequence = actorProxy.CalcFibSequence(number).Result;
                            break;
                        }
                }

                Console.WriteLine();
                Console.WriteLine("Enter (Y) to continue and (N) to stop: ");
                foreach (var i in fibSequence)
                {
                    Console.WriteLine(i);
                }

                string userInput = string.Empty;
                while (userInput != "y" && userInput != "n")
                {
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "n")
                        isContinue = false;
                }
                Console.WriteLine();
            }
        }
    }
}
