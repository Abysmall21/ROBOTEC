using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // Public variable to set the scene name in the Inspector
    public AudioClip soundEffect; // Sound effect to play on collision
    public float delayBeforeSceneChange = 2f; // Delay before changing the scene (default 2 seconds)
    private AudioSource audioSource; // AudioSource to play the sound effect
    private bool soundPlayed = false; // Flag to check if the sound has been played

    void Start()
    {
        // Get or add an AudioSource component to the sphere
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBall") && !soundPlayed)
        {
            // Play sound effect once
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
                soundPlayed = true; // Mark sound as played
            }

            // Start the timer for scene change
            Invoke("ChangeScene", delayBeforeSceneChange);
        }
    }

    void ChangeScene()
    {
        // Change to the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
