using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPlatformRight;
    [SerializeField] private GameObject wallPlatformLeft;
    [SerializeField] private MainData mainData;

    public void GetSpawn()
    {
        SpawnWall(new Vector3(mainData.LeftBound, 0, 10), true);
        SpawnWall(new Vector3(mainData.RightBound, 0, 10), false);
    }

    private void SpawnWall(Vector3 position, bool isLeft)
    {
        (isLeft ? wallPlatformLeft : wallPlatformRight).transform.position = position;
    }
}