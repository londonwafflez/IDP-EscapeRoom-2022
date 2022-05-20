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

    bool allKeyClicked, wClicked, aClicked, sClicked, dClicked;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        GetInput();
        Animate();
    }
    private void FixedUpdate() {
        rb.velocity = input * moveSpeed;
    }
    private void GetInput(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (!allKeyClicked && SceneManager.GetActiveScene().name == "Storage Room") {
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
                GameObject.Find("HintButton").GetComponent<Hints>().NextPrompt();
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
}
