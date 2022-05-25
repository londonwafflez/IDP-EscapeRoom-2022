// using System.Collections;
// using UnityEngine;
// using UnityEngine.Networking;
// using UnityEngine.UI;

// public class Data : MonoBehaviour
// {
//     [SerializeField] string Username;
//     [SerializeField] string Score;
//     private string URL = "https://docs.google.com/spreadsheets/d/1ZlVADmM7B8WjgOY-8yd7nzJUorSmVfBua0TbrFYvv5Q/edit?resourcekey#gid=493063165";
    
//     // void Awake()

//     public void Send()
//     {
//         StartCoroutine(Post(Username, Score));
//     }

//     IEnumerator Post(string s1, string s2, string s3, string s4, string s5, string s6,string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15)
//     {
//         WWWForm form = new WWWForm();
//         form.AddField("",s1);
//         form.AddField("",s2);
    

//         UnityWebRequest www = UnityWebRequest.Post(URL, form);

//         yield return www.SendWebRequest();
//     }
// }
