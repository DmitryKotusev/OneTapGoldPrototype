using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableSettings/SpawnFlagSettings", fileName = "SpawnFlagSettings")]
public class SpawnFlagSettings : ScriptableObject
{
    [SerializeField]
    private float minSpawnXCoordinate = 0;

    [SerializeField]
    private float maxSpawnXCoordinate = 20;

    [SerializeField]
    private GameObject flagPrefab;

    public float MinSpawnXCoordinate => minSpawnXCoordinate;

    public float MaxSpawnXCoordinate => maxSpawnXCoordinate;

    public GameObject FlagPrefab => flagPrefab;
}
