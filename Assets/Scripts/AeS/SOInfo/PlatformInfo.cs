using UnityEngine;

[CreateAssetMenu(fileName = "PlatformInfo", menuName = "Info/Platform")]
public class PlatformInfo : ScriptableObject
{
    [SerializeField] private PlatformTypes platformType;
    [SerializeField] private float chance;
    public PlatformTypes PlatformType => platformType;
    public float Chance => chance;
}