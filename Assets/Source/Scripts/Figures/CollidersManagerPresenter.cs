using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollidersManagerPresenter : MonoBehaviour
    {
        private BoxCollider2D[] _boxsColliders2D;

        private void Awake()
        {
            _boxsColliders2D = GetComponents<BoxCollider2D>();
        }

        private void OnEnable()
        {
            CompressColliders();
        }

        private void OnDisable()
        {
            DecompressColliders();
        }

        private void CompressColliders()
        {
            foreach (var collider in _boxsColliders2D)
                collider.size = new Vector2(collider.size.x - Config.FigureColliderCompression, collider.size.y - Config.FigureColliderCompression);
        }

        private void DecompressColliders()
        {
            foreach (var collider in _boxsColliders2D)
                collider.size = new Vector2(collider.size.x + Config.FigureColliderCompression, collider.size.y + Config.FigureColliderCompression);
        }
    }
}
