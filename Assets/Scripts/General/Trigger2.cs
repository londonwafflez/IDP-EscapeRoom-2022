using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger2 : MonoBehaviour
{
    public GameObject obj;

    protected bool runTrigger = false;
    public string BadEnd;
    public string GoodEnd;

    CountdownTimer m_cdTimer;

    void Start()
    {

        m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();




    }
  
    protected void Update()
    {
        m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();

        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {

                if (m_cdTimer.timeValue == 0)
                {
                    SceneManager.LoadScene(BadEnd);
                }
                if (m_cdTimer.timeValue > 0)
                {
                    SceneManager.LoadScene(GoodEnd);
                }


                
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        runTrigger = true;
    }


}
