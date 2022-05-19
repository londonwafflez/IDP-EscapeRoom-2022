using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class SendToGoogle : MonoBehaviour
// {
//     public GameObject username;

//     private string Name;

//     [SerializeField]
//     private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfKocdLkRBcJ4Ww4KZ3teQ3VZ5AUEJCE5sQ2ZcyLtctHI0uMQ/formResponse";

//     IEnumerator Post(string name){
//         WWWform form = new WWform();
//         form.AddField("",name)
//         byte[] rawData = form.data;
//         WWW www = new WWW(BASE_URL, rawData);
//         yield return www;
//     }
//     public void Send() {
//         Name = username.GetComponent<InputField>().text;

//         StartCoroutine(Post(Name));
//     }
// }

