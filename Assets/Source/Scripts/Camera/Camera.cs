using DG.Tweening;

namespace PhysicalTetris.Model
{
    public class Camera
    {
        private readonly UnityEngine.Camera _camera;

        public Camera(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public void MoveVertical(float heightLastFigure)
        {
            float maxHeight = heightLastFigure;

            if (_camera.transform.position.y < maxHeight)
                _camera.transform.DOMoveY(maxHeight + Config.CameraOffsetPosition, Config.CameraMoveDuration);
        }

        public void ZoomOut(float maxHeight)
        {
            if (_camera.orthographicSize < maxHeight)
            {
                if (_camera.orthographicSize < maxHeight / Config.CameraZoomOutCoefficient)
                    _camera.DOOrthoSize(maxHeight / Config.CameraZoomOutCoefficient, Config.CameraMoveDuration);

                _camera.transform.DOMoveY(maxHeight / 2, Config.CameraMoveDuration);
            }
        }
    }
}
