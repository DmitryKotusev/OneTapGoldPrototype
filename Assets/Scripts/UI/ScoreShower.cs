using UnityEngine;
using TMPro;

public class ScoreShower : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private ScriptableEventInt changeScoreEvent;

    public void OnScoreUpdate(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    private void OnEnable()
    {
        changeScoreEvent.ScriptableSignal += OnScoreUpdate;
    }

    private void OnDisable()
    {
        changeScoreEvent.ScriptableSignal -= OnScoreUpdate;
    }
}
