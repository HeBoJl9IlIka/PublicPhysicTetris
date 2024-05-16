using UnityEngine;
using UnityEngine.EventSystems;

namespace PhysicalTetris.UI
{
    public class TransitionMenuPresenter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _link;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_parent == null)
                return;

            if (_link == null)
                return;

            _parent.SetActive(false);
            _link.SetActive(true);
        }
    }
}
