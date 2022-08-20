using System;

namespace Views
{
    public interface IView
    {
        public event Action Broken;
        public event Action Paused;
        public event Action Resumed;
        public event Action SettingsOpened;
        public event Action OfSettingsGetOut;
        public event Action OfSceneGetOut;
    }
}