using System;

namespace Views
{
    public interface IMenuButtonView : IButtonView
    {
        public event Action OthersOpened;
        public event Action OfOthersGetOut;
    }
}