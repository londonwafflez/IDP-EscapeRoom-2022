using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode1 : MonoBehaviour
{
    public GameObject chest;
    public GameObject key1;
    public Sprite openChest;
    SpriteRenderer spriteRenderer;
    public string Code;
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public GameObject bbar, dialogueCanvasObj;
    public GameController3 control;


    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }


    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Correct");
            gameObject.SetActive(false);
            spriteRenderer = chest.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = openChest;
            key1.SetActive(true);
            GameObject.Find("HintButton").GetComponent<Hints>().FinishedPuzzle();
            if (SceneManager.GetActiveScene().name == "Library") GameObject.Find("HintButton").GetComponent<Hints>().SetPrompt(5);
            dialogueCanvasObj.SetActive(true);
            bbar.GetComponent<SpriteRenderer>().enabled = true;

            control.Started();

            
            Destroy(chest.GetComponent<Trigger>());
            Destroy(this);
            

        }

        if (Nr != Code)
        {
            Debug.Log("Incorrect");
            NrIndex++;
            Nr = null;
            UiText.text = Nr;
        }
        
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;  
        Debug.Log("Cleared");
    }
}
