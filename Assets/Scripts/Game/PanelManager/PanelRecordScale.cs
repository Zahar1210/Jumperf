using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PanelRecordScale : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private SaveInfo save;
    [FormerlySerializedAs("point")] [SerializeField] private ScoreManager score;
    
    public void GetCurrentScale()
    {
        text.text = (score.point > save.record) ? score.point.ToString() : save.record.ToString();
    }
}