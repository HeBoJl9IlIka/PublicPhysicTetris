using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(RectTransform))]
    public class ContainerResetter : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnDisable()
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, 0);
        }
    }
}
