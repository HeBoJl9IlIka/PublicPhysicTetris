using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class ItemPresenter : MonoBehaviour
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private Config.Skin _name;
        [SerializeField] private Config.SkinType _type;
        [SerializeField] private Config.TypeCurrency _typeCurrency;

        public Sprite Icon => _icon;
        public int Price => _price;
        public Config.Skin Name => _name;
        public Config.SkinType Type => _type;
        public Config.TypeCurrency TypeCurrency => _typeCurrency;
    }
}
