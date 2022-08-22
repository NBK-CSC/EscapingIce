using System;

namespace Views
{
    public interface IView
    {
        public event Action Played;
        public event Action SettingsOpened;
        public event Action OfSettingsGetOut;
        public event Action Exited;
    }
}