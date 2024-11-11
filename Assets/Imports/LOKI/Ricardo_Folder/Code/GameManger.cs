using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject[] button;
    [Header ("Color Order")]
    [SerializeField] List<int> colorOrder;
    [SerializeField] float pickDelay = 0.4f;
    [SerializeField] int pickNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        SetButtonIndex();
        StartCoroutine("PlayGame");
    }

    void SetButtonIndex()
    {
        for (int i = 0; i < button.Length; i++)
        {
            buttonManager buttonScript = button[i].GetComponent<buttonManager>();
            buttonScript.buttonIndex = i;
        }
    }

    IEnumerator PlayGame()
    {
        pickNumber = 0;
        yield return new WaitForSeconds(pickDelay);

        //play the colors that are stored
        foreach (int colorIndex in colorOrder)
        {
            button[colorIndex].GetComponent<buttonManager>().PressButton();
            yield return new WaitForSeconds(pickDelay);
        }

        PickRandomColor();
    }

    void PickRandomColor()
    {
        int rnd = Random.Range(0, button.Length);
        buttonManager buttonScript = button[rnd].GetComponent<buttonManager>();
        buttonScript.PressButton();
        colorOrder.Add(rnd);
    }

    public void PlayerPick(int pick)
    {
        Debug.Log("Player click a button" + pick);
        if (pick == colorOrder[pickNumber])
        {
            Debug.Log("Correct");
            pickNumber++;
            if(pickNumber == colorOrder.Count)
            {
                //update the player's score
                StartCoroutine("PlayGame");
            }
        }
        else
        {
            Debug.Log("You suck ass");
            ResetGame();

            StartCoroutine("PlayGame");
        }
    }

    void ResetGame()
    {
        Debug.Log("Resetting");
        // check to see if we have a new hiscore
        // set the players current score to zero 
        colorOrder.Clear();
    }
}
