using Infrastructure.StateMachine;
using Infrastructure.States;

namespace Infrastructure
{
    public sealed class ProjectContext
    {
        public readonly IDependencyContainer DependencyContainer;
        public readonly IStateMachine GameStateMachine;
        public readonly GameRules GameRules;

        public ProjectContext(IDependencyContainer dependencyContainer, IStateMachine gameStateMachine)
        {
            DependencyContainer = dependencyContainer;
            GameStateMachine = gameStateMachine;
            GameRules = new GameRules();
        }
    }
}