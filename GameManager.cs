using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;
    public GameObject timerTextObject;
    public GameObject mainMenuButtonObject;
    public GameObject cameraControlButtons;

    public Text escapeMessageText;
    public float escapeDelay = 3f;
    public Text timerText;
    public Button gameplayButton;
    public Button instructionsButton;
    public Button backButton;

    public float totalTime = 60f;
    private float currentTime;
    private bool timerRunning = false;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();

        // Panel states
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        HideGameplayUI();

        // Button listeners
        gameplayButton.onClick.AddListener(StartGame);
        instructionsButton.onClick.AddListener(ShowInstructions);
        backButton.onClick.AddListener(HideInstructions);
    }

    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f) currentTime = 0f;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        ShowGameplayUI();
        timerRunning = true;
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        HideGameplayUI();
        timerRunning = false;
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    void ShowGameplayUI()
    {
        timerTextObject.SetActive(true);
        mainMenuButtonObject.SetActive(true);
        cameraControlButtons.SetActive(true);
    }

    void HideGameplayUI()
    {
        timerTextObject.SetActive(false);
        mainMenuButtonObject.SetActive(false);
        cameraControlButtons.SetActive(false);
    }
    public void PlayerEscaped()
    {
        StartCoroutine(HandlePlayerEscape());
    }

    private IEnumerator HandlePlayerEscape()
    {
        // Show message
        escapeMessageText.gameObject.SetActive(true);
        escapeMessageText.text = "The player escaped successfully";

        // Wait for 3 seconds
        yield return new WaitForSeconds(escapeDelay);

        // Hide message
        escapeMessageText.gameObject.SetActive(false);

        // Stop and reset timer
        timerRunning = false;
        currentTime = totalTime;
        UpdateTimerDisplay();

        // Show main menu
        ShowMainMenu();
    }

}
