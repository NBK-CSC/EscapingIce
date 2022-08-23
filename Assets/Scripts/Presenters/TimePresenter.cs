using UnityEngine;
using Views;

namespace Presenters
{
    public class TimePresenter
    {
        private IGameButtonView _gameButtonView;

        public TimePresenter(IGameButtonView gameButtonView)
        {
            _gameButtonView = gameButtonView;
        }

        public void Enable()
        {
            _gameButtonView.Paused += Stop;
            _gameButtonView.Played += Resume;
            _gameButtonView.Exited += Resume;
        }

        public void Disable()
        {
            _gameButtonView.Paused -= Stop;
            _gameButtonView.Played -= Resume;
            _gameButtonView.Exited -= Resume;
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