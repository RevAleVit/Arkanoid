using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    [Header("UI screens")]
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;

    [Space]
    [Header("Gameplay UI values")]
    [SerializeField] Text pointsText;
    [SerializeField] Text timerText;

    [Space]
    [Header("GameOver UI values")]
    [SerializeField] Text resultPointsText;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Call pause in gameplay when back button was pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {            
            OnApplicationPause(true);
        }
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause && gameplayUI.activeSelf)
        {
            Time.timeScale = 0;
            gameplayUI.SetActive(false);
            pauseUI.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gameplayUI.SetActive(true);
    }


    public void Play()
    {
        Time.timeScale = 1;
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
    }

    public void GameOver(bool isWin)
    {
        Time.timeScale = 0;
        resultPointsText.text = pointsText.text;

        gameplayUI.SetActive(false);
        gameOverUI.SetActive(true);
        winScreen.SetActive(isWin);
        loseScreen.SetActive(!isWin);
    }

    public void RefreshPoints(int pointsCount)
    {
        pointsText.text = pointsCount.ToString();
    }

    public void RefreshTimer(float time)
    {
        //Check for timer < 0
        time = time < 0 ? 0 : time;        
        timerText.text = time.ToString("00.0");
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
