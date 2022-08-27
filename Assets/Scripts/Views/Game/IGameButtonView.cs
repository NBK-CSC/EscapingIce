using System;

namespace Views.Game
{
    public interface IGameButtonView : IButtonView
    {
        public event Action Broken;
        public event Action Paused;
        public event Action Reloaded;
    }
}