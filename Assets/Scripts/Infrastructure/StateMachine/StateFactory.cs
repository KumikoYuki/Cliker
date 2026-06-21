using Infrastructure.States;

namespace Infrastructure.StateMachine
{
    public sealed class StateFactory : IStateFactory
    {
        private readonly IDependencyContainer _dependencyContainer;

        public StateFactory(IDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }
        
        public TState Create<TState>() where TState : IExitableState
        {
            return _dependencyContainer.Resolve<TState>();
        }
    }
}