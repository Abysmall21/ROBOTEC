using UnityEngine;
using System;

public class DestroyOnTouch : MonoBehaviour
{
    [Header("Settings")]
    public string targetTag = "Ground"; // Tag of the object to trigger destruction

    public event Action OnDestroyed; // Event triggered when the object is destroyed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            OnDestroyed?.Invoke(); // Trigger the OnDestroyed event
            Destroy(gameObject);   // Destroy this object
        }
    }
}
