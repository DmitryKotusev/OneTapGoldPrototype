using System;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    [SerializeField]
    private TrajectoryDrawerSettings trajectoryDrawerSettings;

    [SerializeField]
    private Transform trajectoryPointsHolder;

    private List<GameObject> trajectoryPoints = new List<GameObject>();

    private float latestCountedFlightDistance = 0;

    public float LatestCountedFlightDistance => latestCountedFlightDistance;

    public void DisableTrajectory()
    {
        foreach (GameObject trajectoryPoint in trajectoryPoints)
        {
            trajectoryPoint.SetActive(false);
        }
    }

    public void DrawTrajectory(Vector2 currentPosition, Vector2 velocity)
    {
        DisableTrajectory();

        float launchDegree = Mathf.Atan2(velocity.y, velocity.x);

        latestCountedFlightDistance
            = Mathf.Pow(velocity.magnitude, 2) * Mathf.Sin(2 * launchDegree) / Physics2D.gravity.magnitude;

        int amountOfPointsToDraw = 1 + (int)(latestCountedFlightDistance / trajectoryDrawerSettings.TrajectoryDrawStep);

        List<GameObject> listOfPointsToDraw = GetListOfPointsToDraw(amountOfPointsToDraw);

        for (int i = 0; i < amountOfPointsToDraw; i++)
        {
            float currentX = currentPosition.x + trajectoryDrawerSettings.TrajectoryDrawStep * i;

            float currentY = GetYValueOfParabola(currentPosition, velocity.magnitude, launchDegree,  currentX);

            listOfPointsToDraw[i].transform.position = new Vector3(currentX, currentY, listOfPointsToDraw[i].transform.position.z);

            listOfPointsToDraw[i].SetActive(true);
        }
    }

    private List<GameObject> GetListOfPointsToDraw(int requiredAmountOfPointsToDraw)
    {
        int pointsToSpawnAmount = requiredAmountOfPointsToDraw - trajectoryPoints.Count;

        for (int i = 0; i < pointsToSpawnAmount; i++)
        {
            GameObject newTrajectoryPoint
                = Instantiate(
                    trajectoryDrawerSettings.TrajectoryPointPrefab,
                    Vector3.zero,
                    Quaternion.identity,
                    trajectoryPointsHolder
                    );

            newTrajectoryPoint.transform.localPosition = Vector3.zero;

            newTrajectoryPoint.SetActive(false);

            trajectoryPoints.Add(newTrajectoryPoint);
        }

        return trajectoryPoints.GetRange(0, requiredAmountOfPointsToDraw);
    }

    private float GetYValueOfParabola(Vector2 startPosition, float startVelocityValue, float angle, float x)
    {
        return startPosition.y + (x - startPosition.x) * Mathf.Tan(angle)
            - (Physics2D.gravity.magnitude / 2 * Mathf.Pow(x - startPosition.x, 2)
            / Mathf.Pow(startVelocityValue, 2) / Mathf.Pow(Mathf.Cos(angle), 2));
    }
}
