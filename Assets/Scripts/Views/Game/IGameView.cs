using System;

namespace Views.Game
{
    public interface IGameView
    {
        public event Action GameOver;
    }
}