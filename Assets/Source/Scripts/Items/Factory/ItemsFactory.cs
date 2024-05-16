using PhysicalTetris.Creator;
using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using System;
using UnityEngine;

namespace PhysicalTetris.Factory
{
    public class ItemsFactory : MonoBehaviour
    {
        [SerializeField] private ItemPresenter[] _itemsTemplates;

        private ItemCreator _itemCreator;

        public int CountItems => _itemsTemplates.Length;

        public void Init(ItemCreator itemCreator)
        {
            _itemCreator = itemCreator;
            enabled = true;
        }

        public Item[] Create()
        {
            if (_itemCreator == null)
                throw new ArgumentNullException(nameof(_itemCreator));

            Item[] items = new Item[_itemsTemplates.Length];

            for (int i = 0; i < _itemsTemplates.Length; i++)
                items[i] = _itemCreator.Create(_itemsTemplates[i]);

            return items;
        }
    }
}
