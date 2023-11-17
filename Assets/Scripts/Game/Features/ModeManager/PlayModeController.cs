using UnityEngine;

public class PlayModeController : MonoBehaviour
{
    [SerializeField] private RestartPlayController restart;
    [SerializeField] private StartPlayController start;
    [SerializeField] private PanelController panel;
    public bool IsStart { get; set; } = true;

    public void OnButtonClick(int indexMethod)
    {
        switch (indexMethod)
        {
            case 1:
                ActivePanel();
                break;
            case 2:
                StartGame();
                break;
            case 3:
                RestartGame();
                break;
            default:
                Debug.LogError("мазафакер");
                break;
        }
    }

    public void ActivePanel()
    {
        panel.EnablePanel();
    }

    private void StartGame()
    {
        start.StartPlay();
    }

    private void RestartGame()
    {
        restart.RestartPlay();
        ActivePanel();
    }
}