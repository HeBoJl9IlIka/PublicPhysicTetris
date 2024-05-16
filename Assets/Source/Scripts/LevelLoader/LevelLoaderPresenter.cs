using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PhysicalTetris.Presenter
{
    public class LevelLoaderPresenter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _numberTargetScene;

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_numberTargetScene);
        }
    }
}
