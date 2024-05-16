using System;

namespace PhysicalTetris.Model
{
    public class ShoppingMenu
    {
        private Item _item;

        public event Action<Item> Showed;
        public event Action<Item> Buying;
        public event Action Canceled;
        public event Action Closed;

        public void Show(Item item)
        {
            _item = item;
            Showed?.Invoke(_item);
        }

        public void Buy() => Buying?.Invoke(_item);

        public void Cancel() => Canceled?.Invoke();

        public void Close() => Closed?.Invoke();
    }
}
