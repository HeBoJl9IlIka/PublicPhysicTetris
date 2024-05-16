using System;

namespace PhysicalTetris.Model
{
    public class Wallet
    {
        private int _countMoney;

        public int CountMoney => _countMoney;

        public event Action<int> Changed;

        public Wallet(int countMoney)
        {
            _countMoney = countMoney;
        }

        public bool TryBuy(int money)
        {
            if (_countMoney >= money)
            {
                _countMoney -= money;
                Changed?.Invoke(_countMoney);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
