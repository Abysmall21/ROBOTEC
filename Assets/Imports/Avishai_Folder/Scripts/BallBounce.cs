using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [Header("Bounce Sound Settings")]
    public AudioClip bounceSound;  // Reference to the bounce sound
    private AudioSource audioSource;  // AudioSource component for playing the sound

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play the bounce sound on collision
        if (audioSource != null && bounceSound != null)
        {
            audioSource.PlayOneShot(bounceSound);  // Play the sound once
        }
    }
}
