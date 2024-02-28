using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] TMP_Text GameTimeUI;

    [Header("Variables")]
    [SerializeField] FloatVariable GameTimeCounter;
    [SerializeField] IntVariable Score;

    [Header("Events")]
    [SerializeField] IntEvent OnAddScore;
    [SerializeField] IntEvent OnScoreMult;
    [SerializeField] Event OnDeath;

    [Header("Misc")]
    [SerializeField] int scoreMultiplier;
    [SerializeField] Dropper Dropper;
    private State state = State.TITLE;

    private void Start()
    {
        OnAddScore.Subscribe(AddScore);
    }
    private void Update()
    {
        
        switch (state)
        {
            case State.TITLE:
                TitleUI.active = true;
                GameUI.active = false;
                Dropper.inputEnabled = false;
                break;
            case State.START:
                TitleUI.active = false;
                GameUI.active = true;
                Dropper.inputEnabled = true;
                gametime = 0f;
                break;
            case State.PLAY:
                gametime += Time.deltaTime;
                break;
            case State.PAUSE:
                break;
            case State.GAME_OVER:
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
    public void Death()
    {
        state = State.GAME_OVER;
    }

    public void AddScore(int amount)
    {
        score = score + amount;
    }

    public void ScoreMult(int amount)
    {
        scoreMultiplier = amount;
    }
}
