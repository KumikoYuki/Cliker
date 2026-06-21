using Infrastructure.StateMachine;

namespace Infrastructure
{
    public sealed class ProjectContext
    {
        public readonly IDependencyContainer DependencyContainer;
        public readonly IStateMachine GameStateMachine;

        public ProjectContext(IDependencyContainer dependencyContainer, IStateMachine gameStateMachine)
        {
            DependencyContainer = dependencyContainer;
            GameStateMachine = gameStateMachine;
        }
    }
}