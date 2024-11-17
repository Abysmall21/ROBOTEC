using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public float bounceForce = 10f; // Set this value higher to make the ball bounce higher

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ballRb = other.GetComponent<Rigidbody>();

        if (ballRb != null)
        {
            // Apply an upward force to create a bounce effect
            ballRb.velocity = new Vector3(ballRb.velocity.x, 0, ballRb.velocity.z); // Reset Y velocity to 0
            ballRb.AddForce(Vector3.up * bounceForce, ForceMode.VelocityChange);
        }
    }
}
