using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum State
{
    TITLE,
    START,
    PLAY,
    PAUSE,
    GAME_OVER
}
public class GameManager : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] GameObject TitleUI;
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] TMP_Text GameTimeUI;
    [SerializeField] TMP_Text GameOverScoreUI;

    [Header("Variables")]
    [SerializeField] FloatVariable GameTimeCounter;
    [SerializeField] IntVariable Score;

    [Header("Events")]
    [SerializeField] IntEvent OnAddScore;
    [SerializeField] IntEvent OnScoreMult;
    [SerializeField] VoidEvent OnLoss;

    [Header("Misc")]
    [SerializeField] IntVariable multiplier;
    [SerializeField] int scoreMultiplier;
    [SerializeField] Dropper Dropper;
    private State state = State.TITLE;

    private void Start()
    {
        OnAddScore.Subscribe(AddScore);
        OnLoss.Subscribe(Death);
    }
    private void Update()
    {

        switch (state)
        {
            case State.TITLE:
                TitleUI.active = true;
                GameOverUI.active = false;
                GameUI.active = false;
                Dropper.inputEnabled = false;
                break;
            case State.START:
                TitleUI.active = false;
                GameUI.active = true;
                Dropper.inputEnabled = true;
                gametime = 0f;
                state = State.PLAY;
                break;
            case State.PLAY:
                gametime += Time.deltaTime;
                break;
            case State.PAUSE:
                break;
            case State.GAME_OVER:
                state = State.TITLE;
                Dropper.inputEnabled = false;
                break;
        }
    }

    public int score
    {
        get
        {
            return Score.value;
        }
        set
        {
            Score.value = value;
            ScoreUI.text = "Score: " + Score.value.ToString("00000");
        }
    }

    public float gametime
    {
        get
        {
            return GameTimeCounter.value;
        }
        set
        {
            GameTimeCounter.value = value;
            int minutes = Mathf.FloorToInt(GameTimeCounter / 60f);
            int seconds = Mathf.FloorToInt(GameTimeCounter % 60f);
            GameTimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void OnGameStart()
    {
        state = State.START;
    }
    public void OnGameQuit()
    {
        Application.Quit();
    }

    public void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGamePost()
    {

    }

    public void Death()
    {
        state = State.GAME_OVER;
    }

    public void AddScore(int amount)
    {
        score = score + (amount * multiplier);
    }

    public void ScoreMult(int amount)
    {
        scoreMultiplier = amount;
    }
}