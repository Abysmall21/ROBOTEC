using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public TMP_Text textMeshPro;             // Reference to TMP Text component
    public Color startColor = Color.white;   // Set this in the Editor
    public Color endColor = Color.red;       // Set this in the Editor
    public float fadeDuration = 1f;          // Duration for fading to the other color (in seconds)

    private float lerpTime = 0f;
    private bool fadingToEnd = true;         // To control the direction of the fade

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TMP_Text>();

        textMeshPro.color = startColor; // Set initial color to startColor
    }

    void Update()
    {
        // Increment lerpTime based on whether we're fading to the start or end color
        lerpTime += Time.deltaTime / fadeDuration;

        // Lerp the color based on direction
        if (fadingToEnd)
        {
            textMeshPro.color = Color.Lerp(startColor, endColor, lerpTime);
        }
        else
        {
            textMeshPro.color = Color.Lerp(endColor, startColor, lerpTime);
        }

        // When lerpTime reaches 1 (end of fade), reverse the fade direction
        if (lerpTime >= 1f)
        {
            lerpTime = 0f; // Reset lerpTime
            fadingToEnd = !fadingToEnd; // Reverse the fade direction
        }
    }
}
