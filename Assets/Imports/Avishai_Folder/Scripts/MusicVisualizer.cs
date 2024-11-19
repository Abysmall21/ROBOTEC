using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[ExecuteInEditMode]
public class MusicVisualizer : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider scrubSlider;          // Reference to the UI Slider
    public RectTransform loopStartMarker; // Reference to the Loop Start marker
    public RectTransform loopEndMarker;   // Reference to the Loop End marker
    public MusicManager musicManager;     // Reference to the MusicManager for loop points
    public Text songNameText;             // Reference to the UI Text for displaying the song name

    void Start()
    {
        // Validate references
        if (musicSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned in MusicVisualizer.");
            return;
        }

        if (scrubSlider == null)
        {
            Debug.LogWarning("Slider is not assigned in MusicVisualizer.");
            return;
        }

        // Display the song filename (if playing)
        if (songNameText != null && musicSource.clip != null)
        {
            songNameText.text = "Now Playing: " + musicSource.clip.name;
        }

        // Set the slider size (e.g., width to 400 and height to 20)
        RectTransform sliderRect = scrubSlider.GetComponent<RectTransform>();
        sliderRect.sizeDelta = new Vector2(800f, 20f); // Set your desired width and height

        // Initialize the slider with the clip length
        scrubSlider.minValue = 0f;
        scrubSlider.maxValue = musicSource.clip.length;
        scrubSlider.value = 0f; // Start at the beginning of the song

        scrubSlider.onValueChanged.AddListener(OnScrub); // Add listener for slider value change

        // Set marker positions
        UpdateMarkers();
    }

    void UpdateMarkers()
    {
        if (loopStartMarker && loopEndMarker && musicManager && scrubSlider)
        {
            float startNormalized = Mathf.InverseLerp(0f, musicSource.clip.length, musicManager.loopStart);
            float endNormalized = Mathf.InverseLerp(0f, musicSource.clip.length, musicManager.loopEnd);

            SetMarkerPosition(loopStartMarker, startNormalized);
            SetMarkerPosition(loopEndMarker, endNormalized);
        }
    }

    void SetMarkerPosition(RectTransform marker, float normalizedPosition)
    {
        // Calculate marker position in slider space
        Vector3[] sliderCorners = new Vector3[4];
        scrubSlider.GetComponent<RectTransform>().GetWorldCorners(sliderCorners);

        float sliderWidth = sliderCorners[2].x - sliderCorners[0].x;
        float markerX = sliderCorners[0].x + (normalizedPosition * sliderWidth);

        marker.position = new Vector3(markerX, marker.position.y, marker.position.z);
    }

    void OnScrub(float value)
    {
        // Update the playback position when the user scrubs
        if (musicSource != null)
        {
            musicSource.time = Mathf.Clamp(value, 0f, musicSource.clip.length); // Ensure it's within bounds
        }
    }

    void Update()
    {
        // Update the slider's value to match the current playback time
        if (musicSource != null && musicSource.isPlaying && scrubSlider != null)
        {
            scrubSlider.value = Mathf.Clamp(musicSource.time, 0f, musicSource.clip.length); // Ensure it's within bounds

            // Check if the current playback time is close to the loop end time
            if (musicSource.time >= musicManager.loopEnd)
            {
                musicSource.time = musicManager.loopStart; // Loop to the start
                scrubSlider.value = musicManager.loopStart; // Update the slider to reflect the loop start
            }
        }

        // Clear song name text when the scene stops
        //if (!EditorApplication.isPlaying && songNameText != null)
        {
            songNameText.text = ""; // Clear text when the scene is stopped in the editor
        }
    }
}
