using System;

namespace PhysicalTetris.Model
{
    public class Shop : IUpdatable
    {
        private readonly Warehouse _warehouse;
        private Item _selectedItem;
        private Inventory _inventory;
        private Wallet _wallet;
        private ShoppingMenu _shoppingMenu;

        public bool IsEnabled { get; private set; }

        public event Action BuyingCanceled;
        public event Action Buyed;

        public Shop(Warehouse warehouse, Inventory inventory, Wallet wallet, ShoppingMenu shoppingMenu)
        {
            _warehouse = warehouse;
            _inventory = inventory;
            _wallet = wallet;
            _shoppingMenu = shoppingMenu;
        }

        public void Enable()
        {
            _warehouse.Enable();

            _warehouse.Selected += OnSelected;
            _shoppingMenu.Buying += OnBuying;
        }

        public void Disable()
        {
            _warehouse.Disable();

            _warehouse.Selected -= OnSelected;
            _shoppingMenu.Buying -= OnBuying;
        }

        public void Update(float tick)
        {
        }

        private void OnSelected(Item item)
        {
            _shoppingMenu.Show(item);
            _selectedItem = item;
        }

        private void OnBuying(Item item)
        {
            if (_selectedItem != item)
                return;

            if (_inventory.HasInInventory(item) == false)
            {
                if (_wallet.TryBuy(item.Price))
                {
                    _inventory.AddItem(item);
                    _shoppingMenu.Close();
                    _warehouse.BlockItem(item);
                    Buyed?.Invoke();
                }
                else
                {
                    _shoppingMenu.Cancel();
                    BuyingCanceled?.Invoke();
                }
            }
        }
    }
}
