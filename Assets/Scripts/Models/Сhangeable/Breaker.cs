using Views;
using Views.Game;

namespace Models.Сhangeable
{
    public class Breaker
    {
        private Ice _ice;
        private IGameButtonView _gameButtonView;

        public Breaker(Ice ice, IGameButtonView gameButtonView)
        {
            _ice = ice;
            _gameButtonView = gameButtonView;
        }

        public void Enable()
        {
            _gameButtonView.Broken += Break;
        }

        public void Disable()
        {
            _gameButtonView.Broken -= Break;
        }
        
        private void Break()
        {
            _ice.Break(BreakState.SelfBreak);
        }
    }
}