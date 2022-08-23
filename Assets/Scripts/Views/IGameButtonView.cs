using System;

namespace Views
{
    public interface IGameButtonView : IButtonView
    {
        public event Action Broken;
        public event Action Paused;
    }
}