// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace ServiceFabricMocks
{
    using System;
    using System.Collections.Concurrent;

    using Microsoft.ServiceFabric.Services.Client;
    using Microsoft.ServiceFabric.Services.Communication.Client;
    using Microsoft.ServiceFabric.Services.Remoting;
    using Microsoft.ServiceFabric.Services.Remoting.Client;

    /// <summary>
    /// Wrapper class for the static ServiceProxy.
    /// </summary>
    public class MockServiceProxyFactory : IServiceProxyFactory
    {
        private ConcurrentDictionary<Uri, IService> mockServiceLookupTable = new ConcurrentDictionary<Uri, IService>();

        public TServiceInterface CreateServiceProxy<TServiceInterface>(Uri serviceUri, ServicePartitionKey partitionKey = null, TargetReplicaSelector targetReplicaSelector = TargetReplicaSelector.Default, string listenerName = null) where TServiceInterface : IService
        {
            MockServiceProxy serviceProxy = new MockServiceProxy();
            
            serviceProxy.Supports<TServiceInterface>((mockUri) => this.mockServiceLookupTable[serviceUri]);

            return serviceProxy.Create<TServiceInterface>(serviceUri, partitionKey, targetReplicaSelector, listenerName);
            
        }

        public void AssociateMockServiceAndName(Uri mockServiceUri, IService mockService)
        {
            this.mockServiceLookupTable.AddOrUpdate(mockServiceUri, mockService, (uri, service) => mockService);
        }
    }
}