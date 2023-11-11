using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPlayController : MonoBehaviour
{
    [SerializeField] private SaveInfo saveInfo;

    public void RestartPlay()
    {
        saveInfo.Save();
        ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }
}