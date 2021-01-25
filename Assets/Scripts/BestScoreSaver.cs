using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreSaver : MonoBehaviour
{
    public bool TrySaveNewBestScore(int newBestScore)
    {
        int currentBestValue = PlayerPrefs.GetInt("BestScore", 0);

        if (newBestScore > currentBestValue)
        {
            PlayerPrefs.SetInt("BestScore", newBestScore);

            return true;
        }

        return false;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }
}
