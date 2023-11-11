using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PanelCurrentScale : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private ScoreManager scoreManager;

    public void GetCurrentScale()
    {
        text.text = scoreManager.point.ToString();
    }
}