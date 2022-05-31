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
        if ("teapot123" == userText.text && "8664" == passText.text)
        {
            SecurityCams.SetActive(true);
            GameObject.Find("HintButton").GetComponent<Hints>().FinishedPuzzle(9);
            LoginCanvas.SetActive(false);
            feedback.SetActive(false);
        } else
        {
            feedback.SetActive(true);
            feedbackTMP.text = "Username and/or password incorrect";
        }
    }
}