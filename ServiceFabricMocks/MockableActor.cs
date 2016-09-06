namespace ServiceFabricMocks
{
    using Microsoft.ServiceFabric.Actors.Runtime;

    public abstract class MockableActor : Actor
    {
        private IActorStateManager stateManager;

        public new IActorStateManager StateManager
        {
            get
            {
                return this.stateManager ?? base.StateManager;
            }

            set
            {
                this.stateManager = value;
            }
        }
    }
}
