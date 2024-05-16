using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysicalTetris.Presenter
{
    public class LevelReloaderPresenter : MonoBehaviour
    {
        public void Reload()
        {
            Scene scene = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
