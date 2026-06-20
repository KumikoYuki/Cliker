namespace Infrastructure.States
{
    public interface IEnterableState : IExitableState
    {
        void Enter();

    }

    public interface IEnterableState<in TParam> : IExitableState
    {
        void Enter(TParam param);
    }

    public interface IEterableState<in TParam1, in TParam2> : IExitableState
    {
        void Enter(TParam1 param1, TParam2 param2);
    }
}