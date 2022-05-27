using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator anim;

    public float moveSpeed;

    private Rigidbody2D rb;

    private float x;
    private float y;

    private Vector2 input;
    private bool moving;

    static bool allKeyClicked, wClicked, aClicked, sClicked, dClicked;

    GameController2 dialogueScript;
    Trigger computerTrigger;
    public GameObject computerCanvas;

    bool isTyping;

    ChangeActiveScene m_scene;
    Hints hints;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("InSceneSceneChanger") != null) { 
            m_scene = GameObject.Find("InSceneSceneChanger").GetComponent<ChangeActiveScene>();

            if(m_scene.getScene() == "StorageRoom")
            {
                dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
                hints = GameObject.Find("HintButton").GetComponent<Hints>();
            }
            else if (m_scene.getScene() == "Library")
            {
                dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
            } else {
                computerTrigger = GameObject.Find("computer").GetComponent<Trigger>();
                dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
            }
        } 
        else {
            if (SceneManager.GetActiveScene().name == "Storage Room") {
                dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
            }
            else if (SceneManager.GetActiveScene().name == "Library")
            {
                dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
            } 
            else {
                computerTrigger = GameObject.Find("computer").GetComponent<Trigger>();
            }
        }
    }

    private void Update() {
        if (dialogueScript != null) {
            if (dialogueScript.isDialogueDone() && !isTyping)
            {
                GetInput();
                Animate();
            } 
        } else {
            if (!computerCanvas.activeSelf) 
                typing(false);
        }
    }
    private void FixedUpdate() {
        rb.velocity = input * moveSpeed;
    }
    private void GetInput(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (!allKeyClicked && /*SceneManager.GetActiveScene().name*/m_scene.getScene() == "StorageRoom") {
            if (!wClicked && y == 1) {
                Debug.Log("W clicked");
                wClicked = true;
            }
            if (!aClicked && x == -1) {
                Debug.Log("A clicked");
                aClicked = true;
            }
            if (!sClicked && y == -1) {
                Debug.Log("S clicked");
                sClicked = true; 
            }
            if (!dClicked && y == -1) {
                Debug.Log("D clicked");
                dClicked = true;
            }
            if (wClicked && aClicked && sClicked && dClicked) {
                allKeyClicked = true;
                if (hints.GetPuzzleNum() == 0)
                    hints.SetPrompt(1);
            }
        }

        input = new Vector2(x, y);
        input.Normalize(); 
    }
    private void Animate(){
       if(input.magnitude > 0.1f || input.magnitude < -0.1f)
       {
           moving = true;
       } 
       else
       {
           moving = false;
       }

       if(moving)
       {
           anim.SetFloat("X", x);
           anim.SetFloat("Y", y);
       }

       anim.SetBool("Moving", moving);
    }

    public void typing(bool isTyping) {
        this.isTyping = isTyping;
        computerTrigger.enabled = !isTyping;
    }

    public bool getTyping() {
        return isTyping;
    }
}