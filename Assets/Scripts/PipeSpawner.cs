using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;      // prefab de tuberías
    public float spawnRate = 2f;       // cada cuántos segundos spawnea
    public float minY = -2f;           // límite inferior del hueco
    public float maxY = 2f;            // límite superior del hueco
    public float xSpawn = -10f;         // posición X donde spawnea

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float yPos = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(xSpawn, yPos, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}