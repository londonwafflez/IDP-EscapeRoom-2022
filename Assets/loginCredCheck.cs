using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class loginCredCheck : MonoBehaviour
{
    bool userEntered, passEntered;
    string userInput;
    string passInput;
    public GameObject feedback;
    public TMP_Text feedbackTMP, userText, passText;
    

    void Start()
    { 
        feedbackTMP = feedback.GetComponent<TMP_Text>();
    }

    /*    public void usernameDeselect(string user)
        {
            userEntered = true;
            userInput = user;
            checkCredentials();
        }

        public void passwordDeselect(string pass)
        {
            passEntered = true;
            passInput = pass;
            checkCredentials();
        }*/

    public void checkCredentials()
    {
        userInput = userText.text;
        passInput = passText.text;

        Debug.Log(passInput + "|password");
        string corPass = "password";

        Debug.Log(passInput.GetType());
        Debug.Log(corPass.GetType());

        if ("password" == passInput)
        {
            gameObject.SetActive(false);
            feedback.SetActive(false);
            Debug.Log("both correct");
        } else
        {
            feedbackTMP.text = "Username and/or password incorrect";
            Debug.Log("none");
        }
    }
}
