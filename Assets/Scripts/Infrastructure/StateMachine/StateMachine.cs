using Infrastructure.Engine;
using Infrastructure.States;

namespace Infrastructure.StateMachine
{
    public class StateMachine : IStateMachine, ITickable
    {
        private readonly IStateFactory _stateFactory;
       
        private IExitableState _currentState;

        public StateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        public void Tick()
        {
            if (_currentState is ITickable tickable)
            {
                tickable.Tick();
            }
        }

        public void Enter<TState>() where TState : IEnterableState
        {
            var state = ChangeState<IEnterableState, TState>();
            
            state.Enter();
        }
        
        public void Enter<TState, TParam>(TParam param) where TState : IEnterableState<TParam>
        {
            var state = ChangeState<IEnterableState<TParam>, TState>();
            
            state.Enter(param);
        } 
        
        public void Enter<TState, TParam1, TParam2>(TParam1 param1,TParam2 param2) where TState : IEnterableState<TParam1, TParam2>
        {
            var state = ChangeState<IEnterableState<TParam1, TParam2>, TState>();
           
            state.Enter(param1, param2);
        }
        
        private TResult ChangeState<TResult, TState>() 
            where TState : IExitableState 
            where TResult : class, IExitableState
        {
            var newState = _stateFactory.Create<TState>() as TResult;
            
            _currentState?.Exit();
            _currentState = newState;
            
            return newState;
        }
    }
}