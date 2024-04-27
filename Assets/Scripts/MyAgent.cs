using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class MLAgentPlayer : Agent
{
    public float force = 10f;
    public Transform reset = null;
    public float maxHeight = 5f; // Maximum jumping height

    private Rigidbody rb = null;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        ResetAgent();
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (actionBuffers.ContinuousActions[0] > 0)
        {
            UpForce();
            AddReward(-0.001f); // Apply a small penalty for jumping
        }
        else
        {
            // AddReward(0.001f); // Apply a small reward for not jumping
        }
    }

    public override void OnEpisodeBegin()
    {
        if (transform.localPosition.y < 0f)
        {
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = Quaternion.identity;
        }
        if (transform.localPosition.y > maxHeight)
        {
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = Quaternion.identity;
        }

        ResetAgent();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AddReward(-1.0f);
            Destroy(collision.gameObject);
            EndEpisode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            AddReward(0.5f);
        }
    }

    private void UpForce()
    {
        // Limit the maximum jumping height
        if (transform.position.y < maxHeight && transform.localPosition.y < maxHeight)
        {
            // Freeze rotation along the X and Z axes
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
        }
    }


    private void ResetAgent()
    {
        transform.position = reset.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (transform.position.y < -5f || transform.position.x > 10f) // Adjust the threshold as needed
        {
            EndEpisode();
        }
    }
}