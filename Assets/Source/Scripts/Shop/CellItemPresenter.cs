using PhysicalTetris.Model;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhysicalTetris.Presenter
{
    public class CellItemPresenter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _block;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;

        private CellItem _model;

        public void Init(CellItem item)
        {
            _model = item;
            _icon.sprite = _model.Item.Icon;
            _name.text = _model.Item.Name.ToString();
            enabled = true;
        }

        private void OnEnable()
        {
            _model.Blocked += OnBlocked;
        }

        private void OnDisable()
        {
            _model.Blocked -= OnBlocked;
        }

        public void OnPointerClick(PointerEventData eventData) => _model.SelectItem();

        private void OnBlocked() => _block.SetActive(true);
    }
}