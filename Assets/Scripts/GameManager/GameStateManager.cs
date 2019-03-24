using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class GameStateManager : MonoBehaviour
{
    public const int GAME_START = 0;
    public const int GAME_PLAY = 1;
    public const int GAME_PAUSED = 2;
    public const int GAME_END = 3;

    public static GameStateManager instance = null;
    public static int gameStateId = 0;

    public static void start()
    {
        gameStateId = GAME_START;
    }

    public static void play()
    {
        gameStateId = GAME_PLAY;
    }

    internal static bool isStart()
    {
        return gameStateId == GAME_START;
    }

    public static void end()
    {
        gameStateId = GAME_END;
    }

    public static bool isPlay()
    {
        return gameStateId == GAME_PLAY;
    }

    public static bool isPaused()
    {
        return gameStateId == GAME_PAUSED;
    }

    public static void pause()
    {
        gameStateId = GAME_PAUSED;
    }

    public static void unpause()
    {
        gameStateId = GAME_PLAY;
    }

    internal static bool isEnd()
    {
        return gameStateId == GAME_END;
    }
}
