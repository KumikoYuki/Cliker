using Cysharp.Threading.Tasks;

namespace Infrastructure.AddresablessProvider
{
    public interface IResourcesProvider
    {
        UniTask<TTarget> LoadAsset<TTarget>(string path);
    }
}