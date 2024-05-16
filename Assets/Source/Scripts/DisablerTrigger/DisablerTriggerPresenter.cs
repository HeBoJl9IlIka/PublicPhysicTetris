using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class DisablerTriggerPresenter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
