using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent buttonDown;

    [SerializeField]
    private ScriptableEvent buttonUp;

    [SerializeField]
    private ScriptableEvent reloadLauncher;

    [SerializeField]
    private FloatSharedVariable currentAcceleration;

    [SerializeField]
    private LaunchBallSettings launchBallSettings;

    [SerializeField]
    private SpawnFlagSettings spawnFlagSettings;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private TrajectoryDrawer trajectoryDrawer;

    [SerializeField]
    private Ball ball;

    private float currentSpeedValue = 0;

    private bool isCharging = false;

    private bool isEmpty = false;

    public void Reload()
    {
        currentSpeedValue = 0;

        isCharging = false;

        isEmpty = false;

        ball.Reload();

        ball.transform.position = transform.position;

        trajectoryDrawer.DisableTrajectory();
    }

    public void Launch()
    {
        ball.Launch(launchBallSettings.LaunchDirection * currentSpeedValue);

        isCharging = false;

        isEmpty = true;

        Debug.Log($"Launch speed: {currentSpeedValue}");
    }

    private void Update()
    {
        if (!isCharging)
        {
            return;
        }

        currentSpeedValue += currentAcceleration.Variable * Time.deltaTime;

        trajectoryDrawer.DrawTrajectory(transform.position, launchBallSettings.LaunchDirection * currentSpeedValue);

        CheckMaxLaunchCoordinate();
    }

    private void CheckMaxLaunchCoordinate()
    {
        float cameraWidth = mainCamera.aspect * mainCamera.orthographicSize;

        float launchCoordinate = trajectoryDrawer.LatestCountedFlightDistance + transform.position.x;

        float maxLaunchCoordinate = Mathf.Min(spawnFlagSettings.MaxSpawnXCoordinate, cameraWidth);

        if (launchCoordinate > maxLaunchCoordinate)
        {
            Launch();
        }
    }

    private void OnEnable()
    {
        buttonDown.ScriptableSignal += OnButtonDown;
        
        buttonUp.ScriptableSignal += OnButtonUp;

        reloadLauncher.ScriptableSignal += OnReloadLauncher;
    }

    private void OnDisable()
    {
        buttonDown.ScriptableSignal -= OnButtonDown;

        buttonUp.ScriptableSignal -= OnButtonUp;

        reloadLauncher.ScriptableSignal -= OnReloadLauncher;
    }

    private void OnButtonDown()
    {
        if (isEmpty)
        {
            return;
        }

        isCharging = true;
    }

    private void OnButtonUp()
    {
        if (isEmpty)
        {
            return;
        }

        if (!isCharging)
        {
            return;
        }

        Launch();
    }

    private void OnReloadLauncher()
    {
        Reload();
    }
}
