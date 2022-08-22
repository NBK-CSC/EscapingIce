using UnityEngine;
using Views;

namespace Presenters
{
    public class TimePresenter
    {
        private IGameView _gameView;

        public TimePresenter(IGameView gameView)
        {
            _gameView = gameView;
        }

        public void Enable()
        {
            _gameView.Paused += Stop;
            _gameView.Played += Resume;
            _gameView.Exited += Resume;
        }

        public void Disable()
        {
            _gameView.Paused -= Stop;
            _gameView.Played -= Resume;
            _gameView.Exited -= Resume;
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