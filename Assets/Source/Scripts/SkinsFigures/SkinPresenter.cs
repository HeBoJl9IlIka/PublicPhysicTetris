using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class SkinPresenter : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteFigureI;
        [SerializeField] private Sprite _spriteFigureJ;
        [SerializeField] private Sprite _spriteFigureL;
        [SerializeField] private Sprite _spriteFigureQ;
        [SerializeField] private Sprite _spriteFigureS;
        [SerializeField] private Sprite _spriteFigureT;
        [SerializeField] private Sprite _spriteFigureZ;
        [SerializeField] private Config.Skin _skinsFigures;

        public Config.Skin SkinsFigures => _skinsFigures;
        public Sprite SpriteFigureI => _spriteFigureI;
        public Sprite SpriteFigureJ => _spriteFigureJ;
        public Sprite SpriteFigureL => _spriteFigureL;
        public Sprite SpriteFigureQ => _spriteFigureQ;
        public Sprite SpriteFigureS => _spriteFigureS;
        public Sprite SpriteFigureT => _spriteFigureT;
        public Sprite SpriteFigureZ => _spriteFigureZ;
    }
}
