using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    [Range(0, 300)] public float loopStart = 0f;  // Loop start time in seconds
    [Range(0, 300)] public float loopEnd = 0f;    // Loop end time in seconds

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
    }

    IEnumerator HandleSeamlessLoop()
    {
        int loopStartSample = Mathf.FloorToInt(loopStart * musicSource.clip.frequency);
        int loopEndSample = Mathf.FloorToInt(loopEnd * musicSource.clip.frequency);

        while (true)
        {
            if (musicSource.timeSamples >= loopEndSample)
            {
                musicSource.Stop();
                musicSource.timeSamples = loopStartSample;
                musicSource.Play();
            }
            yield return null;
        }
    }
}
