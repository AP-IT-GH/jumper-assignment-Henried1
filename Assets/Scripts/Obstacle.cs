using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
