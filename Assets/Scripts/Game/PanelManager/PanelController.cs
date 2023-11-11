using System;
using UnityEngine;


public class PanelController : MonoBehaviour
{
    [SerializeField] private Animator panelAnimation;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private PanelCurrentScale panelCurrent;
    [SerializeField] private PanelRecordScale panelRecord;
    [SerializeField] private GameObject stopPlayButton;
    [SerializeField] private GameObject backGroundPanel;
    [SerializeField] private GameObject buttonContinue;
    [SerializeField] private GameObject buttonRestart;
    [SerializeField] private GameObject closeButton;
    public bool IsActive { get; private set; } //если аактивен - true ,а если нет - false

    private void Awake()
    {
        IsActive = gameObject.activeSelf;
    }

    private void Start()
    {
        panelAnimation = GetComponent<Animator>();
    }

    public void EnablePanel()
    {
        if (!IsActive)
        {
            SetOpenPanel();
            EnableButton(!player.IsDead);
            panelAnimation.SetBool("isPanel", true);
        }
        else
            panelAnimation.SetBool("isPanel", false);
    }

    private void SetClosePanel()
    {
        gameObject.SetActive(false);
        stopPlayButton.SetActive(true);
        backGroundPanel.SetActive(false);
        Time.timeScale = 1;
        IsActive = false;
    }

    private void SetOpenPanel()
    {
        gameObject.SetActive(true);
        stopPlayButton.SetActive(false);
        backGroundPanel.SetActive(true);
        Time.timeScale = 0;
        IsActive = true;
        panelRecord.GetCurrentScale();
        panelCurrent.GetCurrentScale();
    }

    private void EnableButton(bool isButton)
    {
        closeButton.gameObject.SetActive(isButton);
        buttonContinue.gameObject.SetActive(isButton);
        buttonRestart.gameObject.SetActive(!isButton);
    }
}