using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScoreCounter : MonoBehaviour
{
    [SerializeField]
    private ScriptableEventInt changeScoreEvent;

    private int currentScore = 0;

    public void IncreaseScore()
    {
        CurrentScore++;
    }

    public int CurrentScore
    {
        get => currentScore;

        private set
        {
            currentScore = value;

            changeScoreEvent.RaiseEvent(currentScore);
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
