using Infrastructure.States;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IExitableState;
    }
}