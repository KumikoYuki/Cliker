using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Data/Enemies", fileName = "EnemiesData")]
    public class EnemiesData : SerializedScriptableObject
    {
        public readonly AssetReferenceGameObject Prefab;
        public readonly List<EnemyData> Data = new();
    }
}