using UnityEngine;
using Views;

namespace Presenters
{
    public class TimePresenter
    {
        private IView _view;

        public TimePresenter(IView view)
        {
            _view = view;
        }

        public void Enable()
        {
            _view.Paused += Stop;
            _view.Resumed += Resume;
        }

        public void Disable()
        {
            _view.Paused -= Stop;
            _view.Resumed -= Resume;
        }

        private void Stop()
        {
            Time.timeScale = 0f;
        }

        private void Resume()
        {
            Time.timeScale = 1f;
        }
    }
}