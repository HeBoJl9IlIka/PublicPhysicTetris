using PhysicalTetris.Model;
using TMPro;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _time; 

        private Timer _timer;

        public void Init(Timer timer)
        {
            _timer = timer;
            enabled = true;
        }

        public void OnEnable()
        {
            _timer.TimerExpired += OnTimerExpired;
        }

        private void OnDisable()
        {
            _timer.TimerExpired -= OnTimerExpired;
        }

        private void Update()
        {
            _time.text = _timer.Time.ToString("#");
        }

        private void OnTimerExpired()
        {
            gameObject.SetActive(false);
        }
    }
}
