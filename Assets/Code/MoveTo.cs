using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public GameObject FalseWall;
    public GameObject TragetObject;
    public GameObject MoveToPos;
    public int Goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Goal == 30)
        {
            HideWall();
        }
    }
    void HideWall()
    {
        FalseWall.SetActive(false);
        TragetObject.transform.position = MoveToPos.transform.position;
    }
}
