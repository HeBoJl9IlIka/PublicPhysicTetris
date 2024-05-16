using PhysicalTetris.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class Warehouse : IUpdatable
    {
        private Item[] _items;
        private CellItemsFactory _shopItemsFactory;
        private RectTransform _containerItems;
        private Vector2 _firstPosition;
        private int _lengthRow;
        private List<CellItem> _shopItems;

        public Config.SkinType SkinType { get; private set; }
        public bool IsEnabled { get; private set; }

        public event Action<Item> Selected;

        public Warehouse(Item[] items, Config.SkinType skinType, CellItemsFactory shopItemsFactory, RectTransform containerItems, Vector2 firstPosition, int lengthRow)
        {
            _items = items;
            SkinType = skinType;
            _shopItemsFactory = shopItemsFactory;
            _containerItems = containerItems;
            _firstPosition = firstPosition;
            _lengthRow = lengthRow;
            _shopItems = new List<CellItem>();

            ArrangeCells();
        }

        public void Enable()
        {
            foreach (var shopItem in _shopItems)
                shopItem.Selected += onSelected;
        }

        public void Disable()
        {
            foreach (var shopItem in _shopItems)
                shopItem.Selected -= onSelected;
        }

        public void Update(float tick)
        {
        }

        public void BlockItem(Item item)
        {
            foreach (var shopItem in _shopItems)
            {
                if (shopItem.Item == item)
                    shopItem.Block();
            }
        }

        private void ArrangeCells()
        {
            float stepHorizontal = _firstPosition.x;
            float stepVertical = _firstPosition.y;

            for (int i = 1; i < _items.Length; i++)
            {
                if (_items[i - 1].Type == SkinType)
                {
                    CellItem shopItems = _shopItemsFactory.Create(_items[i - 1], new Vector2(stepHorizontal, stepVertical), _containerItems);
                    _shopItems.Add(shopItems);
                    stepHorizontal += Config.ShopCellStep;

                    if (i % _lengthRow == 0)
                    {
                        stepHorizontal = _firstPosition.x;
                        stepVertical -= Config.ShopCellStep;
                    }
                }
            }

            _containerItems.sizeDelta = new Vector2(_containerItems.sizeDelta.x, Mathf.Abs(stepVertical) + _shopItemsFactory.GetHeight() / 2);
        }

        private void onSelected(Item item) => Selected.Invoke(item);
    }
}
