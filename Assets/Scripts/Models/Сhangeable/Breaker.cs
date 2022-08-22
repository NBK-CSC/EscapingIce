using Views;

namespace Models.Сhangeable
{
    public class Breaker
    {
        private Ice _ice;
        private IGameView _gameView;

        public Breaker(Ice ice, IGameView gameView)
        {
            _ice = ice;
            _gameView = gameView;
        }

        public void Enable()
        {
            _gameView.Broken += Break;
        }

        public void Disable()
        {
            _gameView.Broken -= Break;
        }
        
        private void Break()
        {
            _ice.Break(BreakState.SelfBreak);
        }
    }
}