using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        RandomizeObjectColor();
    }

    public void RandomizeObjectColor()
    {
        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Apply the random color to the object's material
        rend.material.color = randomColor;
    }
}
