using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Infrastructure.AddresablessProvider
{
    public class AddressablesProvider : IResourcesProvider
    {
        public async UniTask<TTarget> LoadAsset<TTarget>(string path)
        {
            var resource = Addressables.LoadAssetAsync<TTarget>(path);
            
            await resource.Task;
            
            return resource.Result;
        }
    }
}