using BreakStates;
using Views;

namespace Models
{
    public class Breaker
    {
        private Ice _ice;
        private IView _view;

        public Breaker(Ice ice, IView view)
        {
            _ice = ice;
            _view = view;
        }

        public void Enable()
        {
            _view.Broken += Break;
        }

        public void Disable()
        {
            _view.Broken -= Break;
        }
        
        private void Break()
        {
            _ice.Break(BreakState.SelfBreak);
        }
    }
}