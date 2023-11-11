using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioInfo[] gameAudio;

    public AudioInfo[] playerAudio;

    public static AudioController Instance { get; private set; }//пока так (звуки я начал делать и не закончил)  :)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }
}