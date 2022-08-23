using Presenters;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Counters
{
    public class CounterAttempts
    {
        private IcePresenter _icePresenter;
        private int _currentNumberAttempts=0;
        private Text _label;

        public event UnityAction AttemptsOver;
        
        public CounterAttempts (IcePresenter icePresenter,Text label, int numberAttempts)
        {
            _currentNumberAttempts = numberAttempts;
            _icePresenter = icePresenter;
            _label = label;
            PrintNumberOfAttempts(_currentNumberAttempts);
        }

        public void Enable()
        {
            _icePresenter.IceBroken += DecreaseNumberIce;
        }

        public void Disable()
        {
            _icePresenter.IceBroken -= DecreaseNumberIce;
        }

        private void DecreaseNumberIce()
        {
            _currentNumberAttempts -= 1;
            if (_currentNumberAttempts <= 0)
                AttemptsOver?.Invoke();
            PrintNumberOfAttempts(_currentNumberAttempts);
        }
        
        private void PrintNumberOfAttempts(int number)
        {
            _label.text = $"x{number}";
        }
    }
}
