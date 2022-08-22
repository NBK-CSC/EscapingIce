using System;

namespace Views
{
    public interface IGameView : IView
    {
        public event Action Broken;
        public event Action Paused;
    }
}