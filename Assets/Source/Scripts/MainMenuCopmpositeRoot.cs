using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using UnityEngine;

public class MainMenuCopmpositeRoot : MonoBehaviour
{
    [SerializeField] private WalletPresnter[] _walletsPresnters;
    [SerializeField] private ShopCompositeRoot[] _shopsCompositesRoots;
    [SerializeField] private InventoryCompositeRoot _inventoryCompositeRoot;

    private Wallet _wallet;
    private Inventory _inventory;

    private void Awake()
    {
        Item[] items = new Item[0];

        _wallet = new Wallet(100000);
        _inventory = new Inventory(items, _inventoryCompositeRoot.ContainerItems, _inventoryCompositeRoot.CellItemsFactory, _inventoryCompositeRoot.FirstPosition.position, Config.ShopAmountCellsInRow);
        _inventoryCompositeRoot.Init(_inventory);

        foreach (var shopCompositeRoot in _shopsCompositesRoots)
        {
            shopCompositeRoot.Init(_wallet, _inventory);
            shopCompositeRoot.Compose();
        }

        foreach (var walletPresnter in _walletsPresnters)
            walletPresnter.Init(_wallet);

        _inventoryCompositeRoot.Compose();
    }
}
