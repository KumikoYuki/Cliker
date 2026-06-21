using Infrastructure.Engine;
using Infrastructure.States;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine : ITickable
    {
        void Enter<TState>() where TState : IEnterableState;
        void Enter<TState, TParam>(TParam param) where TState : IEnterableState<TParam>;
        void Enter<TState, TParam1, TParam2>(TParam1 param1,TParam2 param2) where TState : IEnterableState<TParam1, TParam2>;
    }
}