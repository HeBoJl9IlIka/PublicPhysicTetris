using DG.Tweening;
using PhysicalTetris.Model;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhysicalTetris.UI.Animation
{
    public class LevelButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TMP_Text[] _exceptionTexts;
        [SerializeField] private Image _backgroundScore;
        [SerializeField] private Color _targetColor;
        [SerializeField] private Color _defaultColor;

        private TMP_Text[] _scores;
        private Tween[] _scoreTweens;
        private Tween _backgroundTween;
        private Vector2 _defaultSize;

        private void Awake()
        {
            _defaultSize = _backgroundScore.rectTransform.sizeDelta;
            _scores = GetComponentsInChildren<TMP_Text>();
            _scoreTweens = new Tween[_scores.Length];

            foreach (var score in _scores)
                score.color = _defaultColor;

            foreach (var text in _exceptionTexts)
                text.color = _targetColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _backgroundTween.Pause();
            _backgroundTween = _backgroundScore.rectTransform.DOSizeDelta(new Vector2(2000, 500), 0.5f);

            for (int i = 0; i < _scores.Length; i++)
                _scoreTweens[i] = _scores[i].DOColor(_targetColor, 0.5f).SetDelay(0.3f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _backgroundTween.Pause();
            _backgroundTween = _backgroundScore.rectTransform.DOSizeDelta(_defaultSize, 0.7f);

            foreach (var tween in _scoreTweens)
                tween.Pause();

            foreach (var score in _scores)
                score.color = _defaultColor;

            foreach (var text in _exceptionTexts)
                text.color = _targetColor;
        }
    }
}
