using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    public Sprite Up;
    public Sprite Down;
    public Sprite Right;
    public Sprite Left;
    public float speed;
    */
    
    //public float speed = 500;
    //public Transform obj;//

    /*public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        obj.transform.position += tempVect;
    }*/

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down);

    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<SpriteRenderer>().sprite = Up;
            move = new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = Left;
            move = new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = Right;
            move = new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = Down;
            move = new Vector3(0, 0, -speed * Time.deltaTime);
        }

        transform.position += move;
    }*/

}