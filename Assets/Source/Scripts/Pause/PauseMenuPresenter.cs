using UnityEngine;
using UnityEngine.UI;

namespace PhysicalTetris.Presenter
{
    public class PauseMenuPresenter : PausePresenter
    {
        [SerializeField] private Button _buttonOpen;
        [SerializeField] private Button _buttonClose;
        [SerializeField] private Button _buttonMainMenu;

        protected override void Enable()
        {
            _buttonOpen.onClick.AddListener(OnClickOpen);
            _buttonClose.onClick.AddListener(OnClickClose);
            _buttonMainMenu.onClick.AddListener(OnClickMainMenu);
        }

        protected override void Disable()
        {
            _buttonOpen.onClick.RemoveListener(OnClickOpen);
            _buttonClose.onClick.RemoveListener(OnClickClose);
            _buttonMainMenu.onClick.RemoveListener(OnClickMainMenu);
        }

        protected override void OnPlaying()
        {
            _buttonOpen.gameObject.SetActive(true);
        }

        protected override void OnStopped()
        {
            _buttonOpen.gameObject.SetActive(false);
        }

        private void OnClickOpen() => Stop();
        private void OnClickClose() => Play();
        private void OnClickMainMenu() => Play();
    }
}
