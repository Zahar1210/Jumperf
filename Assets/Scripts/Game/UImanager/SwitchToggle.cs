using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] private RectTransform handleTransform;

    private Toggle _toggle;
    
    private Vector3 _handlePos;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();

        _handlePos = handleTransform.anchoredPosition;

        _toggle.onValueChanged.AddListener(OnSwitch);
        if (_toggle.isOn)
            OnSwitch(true);
    }

    private void OnSwitch(bool on)
    {
        handleTransform.anchoredPosition = on?_handlePos * -1:_handlePos;
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}