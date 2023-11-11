using UnityEngine;

public class FPSUnlocker : MonoBehaviour
{
    [SerializeField] private int _targetFPS;
    [SerializeField] [Range(0,2)] public int _vSyncCount;

    private void Start()
    {
        UpdateSettings();
    }	
    
    private void OnValidate()
    {
        UpdateSettings();
    }

    private void UpdateSettings()
    {
        QualitySettings.vSyncCount = _vSyncCount;
        Application.targetFrameRate = _targetFPS;
    }
}
