using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25f, 0f, 0f);
    public float startDelay = 2f;
    public float repeatRate = 2f;
    void Start() =>
    InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    void SpawnObstacle() =>
    Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
}

