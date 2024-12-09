using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    public GameObject Dart;
    Vector3 pos;
    public void Spawn()
    {
        pos = this.gameObject.transform.position;
        Instantiate(Dart);
    }

}
