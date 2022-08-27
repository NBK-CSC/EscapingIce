using System;
using Counters;

namespace Views.Game
{
    public class GameView : IGameView
    {
        private CounterAttempts _counterAttempts;
        
        public event Action GameOver;

        public GameView(CounterAttempts counterAttempts)
        {
            _counterAttempts = counterAttempts;
        }

        public void Enable()
        {
            _counterAttempts.AttemptsOver += EndGame;
        }

        public void Disable()
        {
            _counterAttempts.AttemptsOver -= EndGame;
        }

        private void EndGame()
        {
            GameOver?.Invoke();
        }
    }
}