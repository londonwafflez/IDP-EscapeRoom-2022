using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    public InputField usernameInput;
    public Text usernameText;

    public GameObject username;
    public GameObject score;

   private string Name;
   private string Score;

   [SerializeField]
   private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";

   IEnumerator Post(string name, string score)
   {
       WWWForm form= new WWWForm();
       form.AddField("entry.1288604378", name);
       form.AddField("entry.876960760", score);
       byte[] rawData = form.data;
       WWW www = new WWW(BASE_URL, rawData);
       yield return www;
   }

   public void Send()
   {
       Name = username.GetComponent<InputField>().text;
       Score = score.GetComponent<InputField>().text;

       StartCoroutine(Post(Name, Score));

   }

}
