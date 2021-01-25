using UnityEngine;
using TMPro;

public class FinishGamePopup : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent restart;

    [SerializeField]
    private TMP_Text currentScorelabelText;

    [SerializeField]
    private TMP_Text bestScoreLabelText;

    public void SetCurrentScoreText(string currentScoreText)
    {
        currentScorelabelText.text = currentScoreText;
    }

    public void SetBestScoreText(string bestScoreText)
    {
        bestScoreLabelText.text = bestScoreText;
    }

    public void OnRestartButtonClick()
    {
        restart.RaiseEvent();

        Destroy(gameObject);
    }
}
