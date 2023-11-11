using UnityEngine;

public class MainData : MonoBehaviour
{
    [SerializeField] private WallSpawner wallSpawner;
    [SerializeField] private float spawnStabilizer;
    public float LeftBound;
    public float RightBound;
    public float TopBound;
    public float BottomBound;

    public float LeftBoundModified;
    public float RightBoundModified;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        Vector3 screenLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        Vector3 screenRight = _camera.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        Vector3 screenTop = _camera.ViewportToWorldPoint(new Vector3(0.5f, 1, 0));
        Vector3 screenBottom = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));

        LeftBound = screenLeft.x;
        RightBound = screenRight.x;

        LeftBoundModified = screenLeft.x + spawnStabilizer;
        RightBoundModified = screenRight.x - spawnStabilizer;

        TopBound = screenTop.y;
        BottomBound = screenBottom.y;
        wallSpawner.GetSpawn();
    } //получение границ экрана
}