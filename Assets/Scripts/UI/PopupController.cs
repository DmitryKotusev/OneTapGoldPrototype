using System;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField]
    private PopupControllerSettings popupControllerSettings;

    [SerializeField]
    private ScriptableEventFloatFloat showFinishGamePopup;

    private void OnEnable()
    {
        showFinishGamePopup.ScriptableSignal += OnShowEndGamePopup;
    }

    private void OnDisable()
    {
        showFinishGamePopup.ScriptableSignal -= OnShowEndGamePopup;
    }
    private void OnShowEndGamePopup(float currentScore, float bestScore)
    {
        FinishGamePopup finishGamePopup
                = Instantiate(
                    popupControllerSettings.FinishGamePopupPrefab,
                    transform
                    ).GetComponent<FinishGamePopup>();
        
        finishGamePopup.SetCurrentScoreText(currentScore.ToString());

        finishGamePopup.SetBestScoreText(bestScore.ToString());
    }
}
