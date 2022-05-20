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
    bool doneTyping = true;
    string activeSentence;
    string[] hintsText = new string[9]
    {
        "The clock needs to be fixed, so move it to the correct time and it will open",
        "Try looking around the room for hidden objects",
        "Look at the trapdoor and see what it needs. The clock in the room might help you.",
        "Sometimes, it�s okay to snoop around. Why don�t you read a page from the ghost�s diary? There may be a book title that you have to find.",
        "Open the book to the first page. Remember the secret code translator from the first room you escaped? That might come in handy to figure out the code for the chest.",
        "Look at the signs above the bookshelves",
        "The doll wants tea. Find the tea set and give it to the doll",
        "A telephone rings.. The note on the telephone can be used for the computer",
        "Each security camera footage shows a specific spot in each room. You�ve collected 3 statues from each room, put them back  into that specific spot"
    };
    int curPrompt = 0;
    string[] prompts = new string[] {
        "Use W, A, S, and D to move up, left, down, and right",
        "Use F or Spacebar to interact with objects",
        "You could move the clockhand by dragging it to the desired position",
        "Activate items in the inventory with 1, 2, 3... or click the item on the hotbar then use F or Spacebar to use it",
        "Click the numbers on the screen to enter the passowrd"
    };

    CountdownTimer m_cdTimer;

    void Start()
    {
       m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
       StartCoroutine(TypeSentence(prompts[curPrompt]));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) && doneTyping)
        {
            hintTextBox.SetActive(false);
        }
    }

    public void giveHint() {
        if (puzzleNum != lastHintGiven)
        {
            m_cdTimer.SubtractHintTime();
            StartCoroutine(TypeSentence(hintsText[puzzleNum]));
            //Position is found by taking the normal position (-337, -120) and incrementing to make new buttons higher than old ones. The second number for x and the last for y is for modification because parent object
            oldHintButton = Instantiate(originalOldHintButton, new Vector3(-337 + 578, -120 + hintsGiven * 60 + 252, 0), new Quaternion(0, 0, 0, 1), oldHintButtons.transform);
            oldHintButton.SetActive(true);
            hintTextBox.SetActive(true);
            hintsGiven ++;
            lastHintGiven = puzzleNum;
            Debug.Log("Hint " + puzzleNum + " given");
        }
    }

    public void giveOldHint()
    {
        if(hintTextBox.activeSelf) 
        {
            hintTextBox.SetActive(false);
        } else {

            StartCoroutine(TypeSentence(hintsText[puzzleNum]));
        }
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

    public void NextPrompt() {
        curPrompt ++;
        StopCoroutine(TypeSentence(activeSentence));
        StartCoroutine(TypeSentence(prompts[curPrompt]));
    }
    
    public void SetPrompt(int index) {
        curPrompt = index;
        StartCoroutine(TypeSentence(prompts[index]));
    }

	IEnumerator TypeSentence (string sentence)
	{
        activeSentence = sentence;
        hintTextBox.SetActive(true);
        doneTyping = false;
		hintTextBoxText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            if(!hintTextBox.activeSelf) {
                break;
            }
			hintTextBoxText.text += letter;
            yield return new WaitForSeconds(0.05f);
			yield return null;
		}
        doneTyping = true;
	}
}