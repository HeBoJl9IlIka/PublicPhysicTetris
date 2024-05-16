using System;

namespace PhysicalTetris.Model
{
    public class CellItem
    {
        private bool _isBlocked;

        public Item Item { get; private set; }

        public event Action<Item> Selected;
        public event Action Blocked;

        public CellItem(Item item)
        {
            Item = item;
        }

        public void SelectItem()
        {
            if (_isBlocked)
                return;

            Selected?.Invoke(Item);
        }

        public void Block()
        {
            _isBlocked = true;
            Blocked?.Invoke();
        }
    }
}
