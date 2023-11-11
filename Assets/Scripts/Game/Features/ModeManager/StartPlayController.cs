using UnityEngine;

public class StartPlayController : MonoBehaviour
{
    [SerializeField] private StartPlatform startPlatform;
    [SerializeField] private GameObject panelGameMode;
    [SerializeField] private PlayModeController playMode;
    [SerializeField] private GameObject scaleText;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playMode.IsStart)
        {
            playMode.OnButtonClick(2);
        }
    }

    public void StartPlay()
    {
        Time.timeScale = 1;
        scaleText.gameObject.SetActive(false);
        panelGameMode.SetActive(true);
        startPlatform.isStart = true;
        playMode.IsStart = false;
    }
}