using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public string[] scenesToPersistIn; // Add scenes where object should persist
    private static MusicPlayer instance;

    void Awake()
    {
        // Check if there is already an instance of MusicPlayer
        if (instance == null)
        {
            // If not, set this as the instance
            instance = this;
            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Check if the current scene is in the specified list
            if (IsScenePersisting(SceneManager.GetActiveScene().name))
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // If instance exists, destroy the duplicate
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure the music player persists only in the specified scenes
        if (IsScenePersisting(scene.name))
        {
            if (!gameObject.scene.isLoaded)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    bool IsScenePersisting(string sceneName)
    {
        foreach (var scene in scenesToPersistIn)
        {
            if (sceneName == scene)
                return true;
        }
        return false;
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
