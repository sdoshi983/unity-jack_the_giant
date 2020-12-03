using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences 
{
    public static string easyDifficulty = "EasyDifficulty";
    public static string mediumDifficulty = "MediumDifficulty";
    public static string hardDifficulty = "HardDifficulty";

    public static string easyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string mediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string hardDifficultyHighScore = "HardDifficultyHighScore";

    public static string easyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string mediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string hardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string isMusicOn = "IsMusicOn";

    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(easyDifficulty, state);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(easyDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(mediumDifficulty, state);
    }

    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(mediumDifficulty);
    }

    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(hardDifficulty, state);
    }

    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(hardDifficulty);
    }

    // ---------------------------

    public static void SetEasyDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(easyDifficultyHighScore, state);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(easyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(mediumDifficultyHighScore, state);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(mediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(hardDifficultyHighScore, state);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(hardDifficultyHighScore);
    }
    // ---------------------------

    public static void SetEasyDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(easyDifficultyCoinScore, state);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(easyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(mediumDifficultyCoinScore, state);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(mediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(hardDifficultyCoinScore, state);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(hardDifficultyCoinScore);
    }

    // --------------------------
    
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(isMusicOn, state);
    }

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(isMusicOn);
    }
}
