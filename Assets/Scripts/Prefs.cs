using UnityEngine;

public static class Prefs
{
    public static int levelIndex
    {
        get => PlayerPrefs.GetInt(Prefkey.level_index.ToString(), 0);
        set => PlayerPrefs.SetInt(Prefkey.level_index.ToString(), value);
    }

    public static int bestLevel
    {
        get => PlayerPrefs.GetInt(Prefkey.best_level.ToString(), 0);
        set
        {
            int bestLevelUseData = PlayerPrefs.GetInt(Prefkey.best_level.ToString(), 0);
            if (bestLevelUseData >= value)
            {
                return;
            }
            PlayerPrefs.SetInt(Prefkey.best_level.ToString(), value);
        }
    }
}
