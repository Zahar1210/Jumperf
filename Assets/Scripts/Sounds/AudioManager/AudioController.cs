using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioInfo[] audios;
    [SerializeField] private AudioSource _audio;
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

    public void PlayAudio(string name)
    {
        foreach (var audio in audios) {
            
            if (audio.Name == name) {
                this._audio.PlayOneShot(audio.AudioClip);
            }
        }
    }

    public void StopAudio()
    {
        _audio.Stop();
    }
}