using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Data/Enemy", fileName = "EnemyData")]
    public class EnemyData : SerializedScriptableObject
    {
        public int HP;
    }
}