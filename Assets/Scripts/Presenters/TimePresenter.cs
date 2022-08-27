using UnityEngine;
using Views;
using Views.Game;

namespace Presenters
{
    public class TimePresenter
    {
        private IGameButtonView _gameButtonView;
        private IGameView _gameView;

        public TimePresenter(IGameButtonView gameButtonView, IGameView gameView)
        {
            _gameButtonView = gameButtonView;
            _gameView = gameView;
        }

        public void Enable()
        {
            _gameButtonView.Paused += Stop;
            _gameButtonView.Played += Resume;
            _gameButtonView.Exited += Resume;
            _gameButtonView.Reloaded += Resume;
            _gameView.GameOver += Stop;
        }

        public void Disable()
        {
            _gameButtonView.Paused -= Stop;
            _gameButtonView.Played -= Resume;
            _gameButtonView.Exited -= Resume;
            _gameButtonView.Reloaded -= Resume;
            _gameView.GameOver += Stop;
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