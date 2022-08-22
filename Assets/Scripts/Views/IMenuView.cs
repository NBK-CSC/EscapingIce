using System;

namespace Views
{
    public interface IMenuView : IView
    {
        public event Action OthersOpened;
        public event Action OfOthersGetOut;
    }
}