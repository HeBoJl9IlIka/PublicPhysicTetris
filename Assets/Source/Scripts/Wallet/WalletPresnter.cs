using PhysicalTetris.Model;
using TMPro;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class WalletPresnter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;

        private Wallet _wallet;

        public void Init(Wallet wallet)
        {
            _wallet = wallet;
            _value.text = _wallet.CountMoney.ToString();
            enabled = true;
        }

        private void OnEnable()
        {
            _wallet.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _wallet.Changed -= OnChanged;
        }

        private void OnChanged(int value)
        {
            _value.text = value.ToString();
        }
    }
}