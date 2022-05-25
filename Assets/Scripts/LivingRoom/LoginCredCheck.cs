using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginCredCheck : MonoBehaviour
{
    bool userEntered, passEntered;
    public GameObject feedback, LoginCanvas, SecurityCams;
    public TMP_Text feedbackTMP;
    public TMP_InputField userText, passText;


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
        if ("user" == userText.text && "8664" == passText.text)
        {
            LoginCanvas.SetActive(false);
            feedback.SetActive(false);
            SecurityCams.SetActive(true);
        } else
        {
            feedback.SetActive(true);
            feedbackTMP.text = "Username and/or password incorrect";
        }
    }
}