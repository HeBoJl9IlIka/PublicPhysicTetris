using PhysicalTetris.Creator;
using PhysicalTetris.Factory;
using PhysicalTetris.Model;
using UnityEngine;

[RequireComponent(typeof(ItemsFactory))]
[RequireComponent(typeof(CellItemsFactory))]
public class InventoryCompositeRoot : MonoBehaviour
{
    [SerializeField] private RectTransform _firstPosition;
    [SerializeField] private RectTransform _containerItems;
    [SerializeField] private ItemsFactory _itemsFactory;
    [SerializeField] private CellItemsFactory _cellItemsFactory;

    private Inventory _inventory;

    public RectTransform FirstPosition => _firstPosition;
    public RectTransform ContainerItems => _containerItems;
    public ItemsFactory ItemsFactory => _itemsFactory;
    public CellItemsFactory CellItemsFactory => _cellItemsFactory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        enabled = true;
    }

    public void Compose()
    {
        ItemCreator itemCreator = new ItemCreator();
        _itemsFactory.Init(itemCreator);
        Item[] items = _itemsFactory.Create();
    }
}
