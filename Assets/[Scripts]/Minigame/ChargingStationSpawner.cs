using UnityEngine;

public class ChargingStationSpawner : MonoBehaviour
{
    public GameObject chargingStationPrefab;
    public float spawnInterval = 60f; // Spawn a new station every 60 seconds

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnChargingStation();
            timer = 0f;
        }
    }

    private void SpawnChargingStation()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
        Instantiate(chargingStationPrefab, randomPosition, Quaternion.identity);
    }
}