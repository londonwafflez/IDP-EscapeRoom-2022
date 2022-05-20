using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hints : MonoBehaviour
{
    public Text hintTextBoxText;
    int puzzleNum, hintsGiven;
    public GameObject hintTextBox, originalOldHintButton, oldHintButtons;
    TextMeshPro TMP;
    GameObject oldHintButton;
    int lastHintGiven = -1;
    string[] hintsText = new string[9]
    {
        "The clock needs to be fixed, so move it to the correct time and it will open",
        "Try looking around the room for hidden objects",
        "Look at the trapdoor and see what it needs. The clock in the room might help you.",
        "Sometimes, it’s okay to snoop around. Why don’t you read a page from the ghost’s diary? There may be a book title that you have to find.",
        "Open the book to the first page. Remember the secret code translator from the first room you escaped? That might come in handy to figure out the code for the chest.",
        "Look at the signs above the bookshelves",
        "The doll wants tea. Find the tea set and give it to the doll",
        "A telephone rings.. The note on the telephone can be used for the computer",
        "Each security camera footage shows a specific spot in each room. You’ve collected 3 statues from each room, put them back  into that specific spot"
    };
    CountdownTimer m_cdTimer;

    void Start()
    {
       m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
        {
            hintTextBox.SetActive(false);
        }
    }

    public void giveHint() {
        if (puzzleNum != lastHintGiven)
        {
            hintTextBoxText.text = hintsText[puzzleNum];
            //Position is found by taking the normal position (-337, -120) and incrementing to make new buttons higher than old ones. The second number for x and the last for y is for modification because parent object
            oldHintButton = Instantiate(originalOldHintButton, new Vector3(-337 + 578, -120 + hintsGiven * 60 + 252, 0), new Quaternion(0, 0, 0, 1), oldHintButtons.transform);
            oldHintButton.SetActive(true);
            hintTextBox.SetActive(true);
            hintsGiven++;
            m_cdTimer.SubtractHintTime();
            lastHintGiven = puzzleNum;
            Debug.Log("Hint " + puzzleNum + " given");
        }
    }

    public void giveOldHint()
    {
        hintTextBoxText.text = hintsText[puzzleNum];
        hintTextBox.SetActive(!hintTextBox.activeSelf);
    }

    public void FinishedPuzzle() {
        if (puzzleNum < hintsText.Length)
        {
            puzzleNum++;
            foreach (Transform child in oldHintButtons.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            hintsGiven = 0;
            hintTextBox.SetActive(false);
        }
    }
}