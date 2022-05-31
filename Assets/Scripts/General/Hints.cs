using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hints : MonoBehaviour
{
    public GameObject hintTextBox, originalOldHintButton, oldHintButtons, warning;
    public Text hintTextBoxText;
    public int[] hintsPerRoom = {0, 0, 0};
    public int hintsGiven;
    
    GameObject oldHintButton;
    TextMeshPro TMP;
    
    GameController2 dialogueScript;
    CountdownTimer m_cdTimer;
    Coroutine lastRoutine;
    

    int lastHintGiven = -1;
    int curPrompt = 0;
    int puzzleNum;
    
    static bool doneTyping = true;
    bool firstHasRun = false;
    
    string activeSentence;
    
    string[] hintsText = new string[9]
    {
        "The clock needs to be fixed, so move it to your local time and it will open",
        "Use a flashlight to light up your way",
        "Look at the trapdoor and note to see what it needs. The clock in the room might help you.",
        "Sometimes, it's okay to snoop around. Why don't you read a page from the ghost's diary? There may be a book title that you have to find.",
        "Open the book to the first page. Remember the secret code translator from the first room you escaped? That might come in handy to figure out the code for the chest.",
        "Look at the signs above the bookshelves",
        "The doll wants tea. Find the tea set and give it to the doll",
        "A telephone rings.. A translator can get you from the sounds to the computer",
        "Three security cameras and three statues"
    };
    
    string[] prompts = new string[] {
/*0*/       "Use W, A, S, and D or arrow keys to move up, left, down, and right",
            "Use F or Spacebar to interact with objects",
            "You could move the clockhand by dragging it to the desired position",
            "Activate items in the inventory with 1, 2, 3... or click the item on the hotbar then use F or Spacebar to use it",
            "Click the numbers on the screen to enter the passowrd",
/*5*/       "Place the books in empty bookshelves by interacting with a bookshelf and then use F or Spacebar again with an active item",
            "It's locked",
            "Wow! Boxes!",
            "A painting of a mansion with a moon behind it. It reminds you, you're trapped in one yourself",
            "The blacklight makes the numbers 1324 appear",
/*10*/      "Don't you love to stop and smell the flowers when you're about to become a ghost for the rest of your life",
            "A comfortable looking chair",
            "A comfortable looking couch",
            "Something happened..."
    };

    void Start()
    { 
       m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
       if (GameObject.Find("DialogueCanvas") != null) dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
    }

    void Update() {
        if (GameObject.Find("DialogueCanvas") != null)  if (!firstHasRun && dialogueScript.isDialogueDone()) {
            callTypeSentence(prompts[curPrompt]);
            firstHasRun = true;
        }

        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space)) && doneTyping)
        {
            hintTextBox.SetActive(false);
        }
    }

    public void confirmHint()
    {
        warning.SetActive(true);
    }

    public void hintConfirmed(bool confirmed)
    {
        if (confirmed)
        {
            Debug.Log("run givehint");
            giveHint();
        }
        warning.SetActive(false);
    }

    public void giveHint() {
        if (puzzleNum != lastHintGiven)
        {
            m_cdTimer.SubtractHintTime();
            callTypeSentence(hintsText[puzzleNum]);
            //Position is found by taking the normal position (-337, -120) and incrementing to make new buttons higher than old ones. The second number for x and the last for y is for modification because parent object
            oldHintButton = Instantiate(originalOldHintButton, new Vector3(-337 + 578, -120 + hintsGiven * 60 + 252, 0), new Quaternion(0, 0, 0, 1), oldHintButtons.transform);
            oldHintButton.SetActive(true);
            hintTextBox.SetActive(true);
            if (puzzleNum < 3) hintsPerRoom[0] ++;
            else if (puzzleNum < 6) hintsPerRoom[1] ++;
            else if (puzzleNum < 9) hintsPerRoom[2] ++;
            hintsGiven ++;
            lastHintGiven = puzzleNum;
            Debug.Log("Hint " + puzzleNum + " given");
        }
    }

    public void giveOldHint()
    {
        if(hintTextBox.activeSelf) 
        {
            if (hintTextBox != null) 
                hintTextBox.SetActive(false);
        } else {

            callTypeSentence(hintsText[puzzleNum]);
        }
    }

    public void FinishedPuzzle(int currPuzzle) {
        if (currPuzzle == null) {
            if (puzzleNum < hintsText.Length)
            {
                puzzleNum++;
                Debug.LogError("No int given as a parameter for FinishedPuzzle(int currPuzzle). Defaulting to add one");
            }
        } else {
            puzzleNum = currPuzzle;
        }
        foreach (Transform child in oldHintButtons.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        hintsGiven = 0;
        hintTextBox.SetActive(false);
        m_cdTimer.LogSubPuzzleTime(puzzleNum);
    }

    public void NextPrompt() {
        curPrompt ++;
        callTypeSentence(prompts[curPrompt]);
    }
    
    public void SetPrompt(int index) {
        curPrompt = index;
        callTypeSentence(prompts[index]);
    }

	IEnumerator TypeSentence (string sentence)
	{
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

    void callTypeSentence(string sentence) {
        if (lastRoutine != null)
            StopCoroutine(lastRoutine);
        lastRoutine = StartCoroutine(TypeSentence(sentence));
    }

    public int GetPuzzleNum() {
        return puzzleNum;
    }
}