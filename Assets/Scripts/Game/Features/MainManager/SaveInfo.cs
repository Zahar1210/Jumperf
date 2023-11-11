using UnityEngine;
using UnityEngine.Serialization;

public class SaveInfo : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private ToggleController toggleController;
    public int record;
    public bool soundToggle;
    public bool musicToggle;


    private void Awake()
    {
        musicToggle = PlayerPrefs.GetInt("MusicToggle", 0) == 1;
        toggleController.musicToggle.isOn = musicToggle;
        soundToggle = PlayerPrefs.GetInt("SoundToggle", 0) == 1;
        toggleController.soundToggle.isOn = soundToggle;
        record = PlayerPrefs.GetInt("Record", 0);
    }

    public void Save()
    {
        SaveToggleValue(toggleController.soundToggle.isOn, "SoundToggle");
        SaveToggleValue(toggleController.musicToggle.isOn, "MusicToggle");
        SaveRecordScale();
    }

    private void SaveToggleValue(bool isOn, string isToggle)
    {
        PlayerPrefs.SetInt(isToggle, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SaveRecordScale()
    {
        if (score.point > record)
        {
            record = score.point;
            PlayerPrefs.SetInt("Record", record);
            PlayerPrefs.Save();
        }
    }
}