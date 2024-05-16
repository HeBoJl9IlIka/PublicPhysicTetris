using PhysicalTetris.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhysicalTetris.Presenter
{
    public class GameTypeQualifierPresenter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Config.MapName _mapName;
        [SerializeField] private Config.GameType _gameType;

        public void OnPointerClick(PointerEventData eventData)
        {
            DataTransmitter.SetGameType(_gameType);
            DataTransmitter.SetMapName(_mapName);
        }
    }
}
