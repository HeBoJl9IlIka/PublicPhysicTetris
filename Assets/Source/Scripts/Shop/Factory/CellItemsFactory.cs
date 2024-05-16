using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using System;
using UnityEngine;

namespace PhysicalTetris.Factory
{
    public class CellItemsFactory : MonoBehaviour
    {
        [SerializeField] private CellItemPresenter _cellItemTemplate;

        public CellItem Create(Item item, Vector2 position, Transform container)
        {
            CellItem cellItem = new CellItem(item);
            CellItemPresenter newCellItemPresenter = Instantiate(_cellItemTemplate, container);

            if (newCellItemPresenter.TryGetComponent(out RectTransform rectTransform))
                rectTransform.anchoredPosition = position;

            newCellItemPresenter.Init(cellItem);

            return cellItem;
        }

        public float GetHeight()
        {
            RectTransform rectTransform;

            if (_cellItemTemplate.TryGetComponent(out rectTransform) == false)
                throw new ArgumentNullException(nameof(rectTransform));

            return rectTransform.sizeDelta.y;
        }
    }
}
