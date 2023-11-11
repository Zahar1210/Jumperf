using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float duration;
    public bool isReady;

    private void Start()
    {
        StartCoroutine(LoadSlider());
    }

    private IEnumerator LoadSlider()
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float fillAmount = Mathf.Lerp(0f, 1f, currentTime / duration);
            slider.value = fillAmount;

            currentTime += Time.deltaTime;
            yield return null;
        }

        slider.value = 1f; 
        isReady = true;
    }

    public void StartCoroutine()
    {
        StartCoroutine(LoadSlider());
        isReady = false;
    }
}
