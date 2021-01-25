using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    [SerializeField]
    private SpawnFlagSettings spawnFlagSettings;

    [SerializeField]
    private Camera mainCamera;

    private GameObject flagObject;

    public void RandomlyPlaceFlag()
    {
        float cameraWidth = mainCamera.aspect * mainCamera.orthographicSize;

        float maxSpawnWidth = Mathf.Min(spawnFlagSettings.MaxSpawnXCoordinate, cameraWidth);

        float spawnXCoordinate = Random.Range(spawnFlagSettings.MinSpawnXCoordinate, maxSpawnWidth);

        flagObject.transform.position = new Vector3(
            spawnXCoordinate,
            flagObject.transform.position.y,
            flagObject.transform.position.z
            );
    }

    public void SpawnFlag()
    {
        flagObject = Instantiate(spawnFlagSettings.FlagPrefab);
    }
}
