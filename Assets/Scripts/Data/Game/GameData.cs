using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Game
{
    [CreateAssetMenu(fileName = "Data/GameData", menuName = "GameData")]
    public class GameData : ScriptableObject
    {
        public AssetReferenceGameObject GameViewPrefab;
    }
}