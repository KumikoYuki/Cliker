using Cysharp.Threading.Tasks;
using UnityEngine;
using View;

namespace Infrastructure.States
{
    public class PreparationGameState : IEnterableState
    {
        private readonly GameRules _gameRules;

        public PreparationGameState(GameRules gameRules)
        {
            _gameRules = gameRules;
        } 
        public async void Enter()
        {
            var gameView = (await _gameRules.Game.GameViewPrefab.InstantiateAsync()).GetComponent<GameView>();            
            var enemy = (await _gameRules.Enemies.Prefab.InstantiateAsync()).GetComponent<EnemyView>(); 
            
            gameView.Canvas.worldCamera = Camera.main;
        }
        public void Exit() { }
    }
}