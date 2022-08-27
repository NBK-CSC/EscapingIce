using System;

namespace Views.Menu
{
    public interface IMenuButtonView : IButtonView
    {
        public event Action OthersOpened;
        public event Action OfOthersGetOut;
    }
}