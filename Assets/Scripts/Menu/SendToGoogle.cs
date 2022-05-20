using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    public GameObject username;

   private string Name;
   private string Score;

   private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";

   IEnumerator Post(string name, string score)
   {
       WWWForm form = new WWWForm();
       form.AddField("entry.1288604378", name);
       form.AddField("entry.876960760", score);
       byte[] rawData = form.data;
       WWW www = new WWW(BASE_URL, rawData);
       Debug.Log("Data user: " + name + " and score: " + score + " sent");
       yield return www;
   }

   public void Send()
   {
       CountdownTimer m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
        float minutes = Mathf.FloorToInt(m_cdTimer.timeValue / 60);
        float seconds = Mathf.FloorToInt(m_cdTimer.timeValue % 60);
        Score = string.Format("{0:00}:{1:00}", minutes, seconds); //score.GetComponent<InputField>().text;

       StartCoroutine(Post(Name, Score));
    }

    public void getName() {
        Name = username.GetComponent<TMP_InputField>().text;
    }
}
