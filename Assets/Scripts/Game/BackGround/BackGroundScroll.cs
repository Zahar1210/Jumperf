using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] float parallaxEffect;
    [SerializeField] private float _imageHeight;

    private float _startPosition;
    private float _prevCameraPositionY;

    void Start()
    {
        _startPosition = transform.position.y;
        _prevCameraPositionY = camera.transform.position.y;
    }

    void FixedUpdate()
    {
        float cameraMoveDelta = camera.transform.position.y - _prevCameraPositionY;

        if (Mathf.Abs(cameraMoveDelta) > 0.1f) 
        {
            float temp = (camera.transform.position.y * (1 - parallaxEffect));
            float distance = (camera.transform.position.y * parallaxEffect);
            transform.position = new Vector3(transform.position.x, _startPosition + distance, transform.position.z);

            if (temp > _startPosition + _imageHeight)
            {
                _startPosition += _imageHeight;
            }
            else if (temp < _startPosition - _imageHeight)
            {
                _startPosition -= _imageHeight;
            }
        }

        _prevCameraPositionY = camera.transform.position.y;
        // float temp = (camera.transform.position.y * (1 - parallaxEffect));
        // float distance = (camera.transform.position.y * parallaxEffect);
        // transform.position = new Vector3(transform.position.x, _startPosition + distance, transform.position.z);
        //
        // if (temp > _startPosition + _imageHeight) {
        //     _startPosition += _imageHeight;
        // }
        // else if (temp < _startPosition - _imageHeight) {
        //     _startPosition -= _imageHeight;
        // }
    }
}