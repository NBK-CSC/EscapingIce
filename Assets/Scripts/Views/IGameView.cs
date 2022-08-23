using System;

namespace Views
{
    public interface IGameView
    {
        public event Action GameOver;
    }
}