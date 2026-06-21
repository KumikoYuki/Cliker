using Cysharp.Threading.Tasks;
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
            var instance = (await _gameRules.Game.GameViewPrefab.InstantiateAsync()).GetComponent<GameView>();            
        }
        public void Exit() { }
    }
}