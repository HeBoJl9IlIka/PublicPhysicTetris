using PhysicalTetris.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class Inventory
    {
        private CellItemsFactory _cellItemsFactory;
        private RectTransform _containerItems;
        private Vector2 _firstPosition;
        private List<Item> _items;
        private int _lengthRow;
        private int _lastNumber;
        private float _lastStepHorizontal;
        private float _lastStepVertical;

        public Inventory(Item[] items, RectTransform containerItems, CellItemsFactory cellItemsFactory, Vector2 firstPosition, int lengthRow)
        {
            _items = new List<Item>();
            _containerItems = containerItems;
            _cellItemsFactory = cellItemsFactory;
            _firstPosition = firstPosition;
            _lengthRow = lengthRow;
            //LoadSkins(items);

            ArrangeCells();
        }

        public void AddItem(Item item)
        {
            if (HasInInventory(item) == false)
            {
                _items.Add(item);
            }
        }

        public bool HasInInventory(Item item)
        {
            return _items.Contains(item);
        }

        private void LoadSkins(Item[] items)
        {
            foreach (var item in items)
            {
                if (HasInInventory(item) == false)
                    _items.Add(item);
            }
        }

        private void ArrangeCells()
        {
            int i = 1;
            float stepHorizontal = _firstPosition.x;
            float stepVertical = _firstPosition.y;

            for (i = 1; i < _items.Count; i++)
            {
                _cellItemsFactory.Create(_items[i - 1], new Vector2(stepHorizontal, stepVertical), _containerItems);
                stepHorizontal += Config.ShopCellStep;

                if (i % _lengthRow == 0)
                {
                    stepHorizontal = _firstPosition.x;
                    stepVertical -= Config.ShopCellStep;
                }
            }

            _lastNumber = i;
            _lastStepHorizontal = stepHorizontal;
            _lastStepVertical = stepVertical;
            _containerItems.sizeDelta = new Vector2(_containerItems.sizeDelta.x, Mathf.Abs(stepVertical) + _cellItemsFactory.GetHeight() / 2);
        }
    }
}
