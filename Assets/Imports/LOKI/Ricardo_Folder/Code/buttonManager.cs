using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class buttonManager : MonoBehaviour
{
    public int buttonIndex { get; set; }

    [SerializeField] GameManger gm;
    [SerializeField] Color defaultColor;
    [SerializeField] Color highlightColor;
    [SerializeField] float resetDelay = .25f;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = defaultColor;
    }

    void OnMouseDown()
    {
        gm.PlayerPick(buttonIndex);
        PressButton();
    }

    public void PressButton()
    {
        GetComponent<MeshRenderer>().material.color = highlightColor;
        Invoke("ResetButton", resetDelay);
    }

    void ResetButton()
    {
        GetComponent<MeshRenderer>().material.color = defaultColor;
    }
}
