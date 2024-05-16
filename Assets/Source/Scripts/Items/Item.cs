using UnityEngine;

namespace PhysicalTetris.Model
{
    public class Item
    {
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }
        public Config.Skin Name { get; private set; }
        public Config.SkinType Type { get; private set; }
        public Config.TypeCurrency TypeCurrency { get; private set; }

        public Item(Sprite icon, int price, Config.Skin name, Config.SkinType type, Config.TypeCurrency typeCurrency)
        {
            Icon = icon;
            Price = price;
            Name = name;
            Type = type;
            TypeCurrency = typeCurrency;
        }
    }
}
