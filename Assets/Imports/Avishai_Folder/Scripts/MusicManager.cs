using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    [Range(0, 300)] public float loopStart = 0f;  // Loop start time in seconds
    [Range(0, 300)] public float loopEnd = 
        0f;   // Loop end time in seconds
    public string[] scenesWithMusic;             // List of scene names where music should play

    private static MusicManager instance;

    void Awake()
    {
        // Ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject); // Persist this GameObject across scenes
    }

    void Start()
    {
        // Ensure loopStart and loopEnd are valid
        if (loopStart < 0 || loopEnd > musicSource.clip.length || loopStart >= loopEnd)
        {
            Debug.LogError("Invalid loop points. Ensure they are within the clip's duration and loopStart < loopEnd.");
            return;
        }

        musicSource.Play(); // Start playing the music
        StartCoroutine(HandleSeamlessLoop());

        // Subscribe to scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from scene changes to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator HandleSeamlessLoop()
    {
        while (true)
        {
            float remainingTime = loopEnd - musicSource.time;
            yield return new WaitForSeconds(remainingTime); // Wait until loopEnd
            musicSource.time = loopStart; // Snap back to loopStart
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is in the list of scenes with music
        if (!System.Array.Exists(scenesWithMusic, s => s == scene.name))
        {
            Destroy(gameObject); // Destroy MusicManager if the scene does not require music
        }
    }
}
