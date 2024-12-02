using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterTrigger : MonoBehaviour
{
    public string TagName;
    
    public int score = 5;
    public int CurScore = 0;
    public TMP_Text scoreText;
    public GameObject[] targetCo;
    public Collider[] tragetCo;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE:" + CurScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + CurScore.ToString();
    }
    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == TagName)
        {
            CurScore = CurScore + score;
            scoreText.text = "SCORE: " + CurScore.ToString();
        }
    }
}
