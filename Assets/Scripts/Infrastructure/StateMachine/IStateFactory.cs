using Infrastructure.States;

namespace Infrastructure.StateMachine
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : IExitableState;
    }
}