using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterTrigger : MonoBehaviour
{
    public string TagName;
    public GameObject[] Triggers;
    public int score;
    public int CurScore = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE:" + CurScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider co)
    {
        if(co.gameObject.tag == TagName)
        {
            CurScore = score++;
            scoreText.text = "SCORE: " + CurScore.ToString();
        }
    }
}