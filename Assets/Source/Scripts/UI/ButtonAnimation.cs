using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhysicalTetris.UI.Animation
{
    public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _border;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Color _targetColorBackground;
        [SerializeField] private Color _targetColorBorder;
        [SerializeField] private Color _targetColorIcon;
        [SerializeField] private Color _targetColorTitle;

        private Tween _tweenBackground;
        private Tween _tweenBorder;
        private Tween _tweenIcon;
        private Tween _tweenTitle;
        private Color _defaultColorBackground;
        private Color _defaultColorBorder;
        private Color _defaultColorIcon;
        private Color _defaultColorTitle;

        private void Awake()
        {
            _defaultColorBackground = _background.color;
            _defaultColorBorder = _border.color;
            _defaultColorIcon = _icon.color;
            _defaultColorTitle = _title.color;
        }

        private void OnEnable()
        {
            _background.color = _defaultColorBackground;
            _border.color = _defaultColorBorder;
            _icon.color = _defaultColorIcon;
            _title.color = _defaultColorTitle;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tweenBackground.Pause();
            _tweenBorder.Pause();
            _tweenIcon.Pause();
            _tweenTitle.Pause();
            _tweenBackground = _background.DOColor(_targetColorBackground, 0.5f);
            _tweenBorder = _border.DOColor(_targetColorBorder, 0.5f);
            _tweenIcon = _icon.DOColor(_targetColorIcon, 0.5f);
            _tweenTitle = _title.DOColor(_targetColorTitle, 0.5f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tweenBackground.Pause();
            _tweenBorder.Pause();
            _tweenIcon.Pause();
            _tweenTitle.Pause();
            _tweenBackground = _background.DOColor(_defaultColorBackground, 0.5f);
            _tweenBorder = _border.DOColor(_defaultColorBorder, 0.5f);
            _tweenIcon = _icon.DOColor(_defaultColorIcon, 0.5f);
            _tweenTitle = _title.DOColor(_defaultColorTitle, 0.5f);
        }
    }
}
