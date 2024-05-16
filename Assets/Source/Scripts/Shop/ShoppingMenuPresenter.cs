using PhysicalTetris.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhysicalTetris.Presenter
{
    public class ShoppingMenuPresenter : MonoBehaviour
    {
        [SerializeField] private ShoppingMenu _shoppingMenu;
        [SerializeField] private GameObject _cancelMenu;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private GameObject _container;

        public void Init(ShoppingMenu shoppingMenu)
        {
            _shoppingMenu = shoppingMenu;
            enabled = true;
        }

        private void OnEnable()
        {
            _shoppingMenu.Showed += OnShowed;
            _shoppingMenu.Closed += OnClosed;
            _buttonBuy.onClick.AddListener(OnBuying);
        }

        private void OnDisable()
        {
            _shoppingMenu.Showed -= OnShowed;
            _shoppingMenu.Closed += OnClosed;
            _buttonBuy.onClick.RemoveListener(OnBuying);
        }

        public void ShowCancelMenu()
        {
            _cancelMenu.SetActive(true);
            Invoke(nameof(HideCancelMenu), 1f);
        }

        private void HideCancelMenu()
        {
            _cancelMenu.SetActive(false);
        }

        private void OnShowed(Item item)
        {
            _container.SetActive(true);
            _icon.sprite = item.Icon;
            _name.text = item.Name.ToString();
            _price.text = item.Price.ToString();
        }

        private void OnBuying() => _shoppingMenu.Buy();

        private void OnClosed()
        {
            _container.SetActive(false);
        }
    }
}
