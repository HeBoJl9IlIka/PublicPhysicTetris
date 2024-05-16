using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(FigurePresenter))]
    public class SkinInstallerPresenter : MonoBehaviour
    {
        [SerializeField] private SkinPresenter[] _skinPresenters;

        private SpriteRenderer _spriteRenderer;
        private FigurePresenter _figurePresenter;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _figurePresenter = GetComponent<FigurePresenter>();

            foreach (var skin in _skinPresenters)
            {
                if (DataTransmitter.SkinsFigures == skin.SkinsFigures)
                {
                    switch (_figurePresenter.TypeFigure)
                    {
                        case Config.FigureType.I:
                            _spriteRenderer.sprite = skin.SpriteFigureI;
                            break;
                        case Config.FigureType.J:
                            _spriteRenderer.sprite = skin.SpriteFigureJ;
                            break;
                        case Config.FigureType.L:
                            _spriteRenderer.sprite = skin.SpriteFigureL;
                            break;
                        case Config.FigureType.Q:
                            _spriteRenderer.sprite = skin.SpriteFigureQ;
                            break;
                        case Config.FigureType.S:
                            _spriteRenderer.sprite = skin.SpriteFigureS;
                            break;
                        case Config.FigureType.T:
                            _spriteRenderer.sprite = skin.SpriteFigureT;
                            break;
                        case Config.FigureType.Z:
                            _spriteRenderer.sprite = skin.SpriteFigureZ;
                            break;
                    }
                }
            }
        }


    }
}
