using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public GameObject FalseWall;
    public GameObject TragetObject;
    public GameObject MoveToPos;
    public int Goal;
    public EnterTrigger _enterTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Goal = _enterTrigger.CurScore;
        if(Goal >= 60)
        {
            HideWall();
            _enterTrigger.CurScore = 0;
        }
    }
    void HideWall()
    {
        FalseWall.SetActive(false);
        TragetObject.transform.position = MoveToPos.transform.position;
    }
}
