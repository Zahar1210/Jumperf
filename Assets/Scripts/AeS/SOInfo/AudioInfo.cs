using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "Info/Audio")]
public class AudioInfo : ScriptableObject
{
    public string Name;

    public AudioClip AudioClip;
    
    [Range(0f, 1f)]
    public float Value;
}
