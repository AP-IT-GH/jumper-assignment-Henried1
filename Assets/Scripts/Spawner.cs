using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawn = null;
    public float minTime = 2.0f; 
    public float maxTime = 5.0f; 

    private void Start()
    {
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }

    private void SpawnObstacle()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawn.position;

        // Schedule the next spawn
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}
