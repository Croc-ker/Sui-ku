using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject TitleUI;
    [SerializeField] FloatVariable GameTimeCounter;
    [SerializeField] IntVariable Score;

    public enum States
    {
        TITLE,
        START,
        PLAY,
        PAUSE,
        GAME_OVER
    }


}
