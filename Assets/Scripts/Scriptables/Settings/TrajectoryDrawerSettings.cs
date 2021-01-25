using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableSettings/TrajectoryDrawerSettings", fileName = "TrajectoryDrawerSettings")]
public class TrajectoryDrawerSettings : ScriptableObject
{
    [SerializeField]
    private GameObject trajectoryPointPrefab;

    [SerializeField]
    private float trajectoryDrawStep = 0.1f;

    public GameObject TrajectoryPointPrefab => trajectoryPointPrefab;

    public float TrajectoryDrawStep => trajectoryDrawStep;
}
