
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioInfo[] audios;
    [SerializeField] AudioClip _bgMusic;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioSource _audioBG;
    public static AudioController Instance { get; private set; }

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
       PlayBackGroundMusic();
    }

    public void PlayBackGroundMusic()
    {
        if (!_musicToggle.isOn) {
            _audioBG.clip = _bgMusic;
            _audioBG.loop = true;
            _audioBG.Play();
        }
        else {
            _audioBG.Stop();
        }
    }

    public void PlayAudio(string name)
    {
        foreach (var audio in audios) {
            
            if (audio.Name == name && !_soundToggle.isOn) {
                _audio.PlayOneShot(audio.AudioClip);
            }
        }
    }

    public void StopAudio()
    {
        _audio.Stop();
    }
}