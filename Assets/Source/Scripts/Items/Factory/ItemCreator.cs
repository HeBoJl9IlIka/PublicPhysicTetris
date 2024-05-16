using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using UnityEngine;

namespace PhysicalTetris.Creator
{
    public class ItemCreator
    {
        public Item Create(ItemPresenter itemPresenter)
        {
            Sprite icon = itemPresenter.Icon;
            int price = itemPresenter.Price;
            Config.Skin name = itemPresenter.Name;
            Config.SkinType type = itemPresenter.Type;
            Config.TypeCurrency typeCurrency = itemPresenter.TypeCurrency;

            return new Item(icon, price, name, type, typeCurrency);
        }
    }
}
