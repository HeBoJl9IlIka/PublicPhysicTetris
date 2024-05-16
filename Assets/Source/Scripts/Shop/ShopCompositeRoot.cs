using PhysicalTetris.Creator;
using PhysicalTetris.Factory;
using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using UnityEngine;

[RequireComponent(typeof(ItemsFactory))]
[RequireComponent(typeof(CellItemsFactory))]
public class ShopCompositeRoot : MonoBehaviour
{
    [SerializeField] private ShoppingMenuPresenter _shoppingMenuPresenter;
    [SerializeField] private Config.SkinType _skinType;
    [SerializeField] private RectTransform _firstPosition;
    [SerializeField] private RectTransform _containerItems;
    [SerializeField] private ItemsFactory _itemsFactory;
    [SerializeField] private CellItemsFactory _cellItemsFactory;

    private Shop _shop;
    private Warehouse _warehouse;
    private ShoppingMenu _shoppingMenu;
    private Wallet _wallet;
    private Inventory _inventory;

    public void Init(Wallet wallet, Inventory inventory)
    {
        _wallet = wallet;
        _inventory = inventory;
    }

    public void Compose()
    {
        _shoppingMenu = new ShoppingMenu();
        _shoppingMenuPresenter.Init(_shoppingMenu);
        ItemCreator itemCreator = new ItemCreator();
        _itemsFactory.Init(itemCreator);
        Item[] items = _itemsFactory.Create();
        _warehouse = new Warehouse(items, _skinType, _cellItemsFactory, _containerItems, _firstPosition.anchoredPosition, Config.ShopAmountCellsInRow);
        _shop = new Shop(_warehouse, _inventory, _wallet, _shoppingMenu);
        enabled = true;
    }

    private void OnEnable()
    {
        _shop.Enable();
    }

    private void OnDisable()
    {
        _shop.Disable();
    }
}
