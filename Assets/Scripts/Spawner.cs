using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public Vector2 spawnArea;

    public float spawnInterval;

    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoroutine(spawnInterval));
    }

    private IEnumerator SpawnCoroutine(float interval)
    {
        while (true)
        {
            Vector2 randomPosition = GenerateRandomPosition();

            GameObject enemyGameObject = Instantiate(enemyPrefab);
            Enemy enemyScript = enemyGameObject.GetComponent<Enemy>();

            enemyGameObject.transform.position = randomPosition;
            enemyScript.targetTransform = playerTransform;

            yield return new WaitForSeconds(interval);
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        Vector2 position = new Vector2();

        float value = Random.value > 0.5 ? -1 : 1;

        if (Random.value < 0.5)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * value;
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * value;
        }

        return position;
    }
}
