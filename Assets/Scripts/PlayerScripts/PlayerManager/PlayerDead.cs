using Cinemachine;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;

    public void DieFromFall()
    {
        camera.Follow = null;
    }
}