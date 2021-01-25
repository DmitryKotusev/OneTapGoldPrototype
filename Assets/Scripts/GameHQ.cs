using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHQ : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent ballGotIntoHole;

    [SerializeField]
    private ScriptableEvent ballMissed;

    [SerializeField]
    private ScriptableEvent reloadLauncher;

    [SerializeField]
    private ScriptableEventFloatFloat showFinishGamePopup;

    [SerializeField]
    private ScriptableEvent restart;

    [SerializeField]
    private FloatSharedVariable currentAcceleration;

    [SerializeField]
    private LaunchBallSettings launchBallSettings;

    [SerializeField]
    private CurrentScoreCounter currentScoreCounter;

    [SerializeField]
    private FlagSpawner flagSpawner;

    [SerializeField]
    private BestScoreSaver bestScoreSaver;

    private GameStatus gameStatus;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        flagSpawner.SpawnFlag();

        ConfigureGameStart();
    }

    private void ConfigureGameStart()
    {
        currentScoreCounter.ResetScore();

        flagSpawner.RandomlyPlaceFlag();

        reloadLauncher.RaiseEvent();

        currentAcceleration.Variable = launchBallSettings.StartAcceleration;

        gameStatus = GameStatus.Started;
    }

    private void OnEnable()
    {
        ballGotIntoHole.ScriptableSignal += OnBallGotIntoHole;

        ballMissed.ScriptableSignal += OnBallMissed;

        restart.ScriptableSignal += OnRestart;
    }

    private void OnDisable()
    {
        ballGotIntoHole.ScriptableSignal -= OnBallGotIntoHole;

        ballMissed.ScriptableSignal -= OnBallMissed;

        restart.ScriptableSignal -= OnRestart;
    }

    private void OnBallGotIntoHole()
    {
        // Transfer to next level
        currentScoreCounter.IncreaseScore();

        // Respawn flag
        flagSpawner.RandomlyPlaceFlag();

        // Reload launcher
        reloadLauncher.RaiseEvent();

        // Increase current acceleration
        currentAcceleration.Variable = Mathf.Clamp(
            currentAcceleration.Variable + launchBallSettings.AccelerationChangeSpeed,
            launchBallSettings.StartAcceleration,
            launchBallSettings.MaxAcceleration
            );
    }

    private void OnBallMissed()
    {
        if (gameStatus == GameStatus.Finished)
        {
            return;
        }

        bestScoreSaver.TrySaveNewBestScore(currentScoreCounter.CurrentScore);

        showFinishGamePopup.RaiseEvent(currentScoreCounter.CurrentScore, bestScoreSaver.GetBestScore());

        gameStatus = GameStatus.Finished;
    }

    private void OnRestart()
    {
        ConfigureGameStart();
    }
}
