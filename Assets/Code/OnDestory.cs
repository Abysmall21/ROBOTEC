using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestory : MonoBehaviour
{
    public string tagName;
    private void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag == tagName)
        {
            Destroy(co.gameObject);
        }
    }
}
