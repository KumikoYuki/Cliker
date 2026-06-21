namespace Infrastructure.StateMachine
{
    public interface IDependencyContainer
    {
        void Register<TType>(TType instance);
        TType Resolve<TType>();
    }
}