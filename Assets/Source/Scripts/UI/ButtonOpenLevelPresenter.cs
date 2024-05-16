using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PhysicalTetris.Presenter
{
    public class ButtonOpenLevelPresenter : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private int _numberScene;

        public void OnPointerDown(PointerEventData eventData)
        {
            SceneManager.LoadScene(_numberScene);
        }
    }
}
