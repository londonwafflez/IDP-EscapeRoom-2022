// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class SendToGoogle : MonoBehaviour
// {
//     // public GameObject username;
//     // public GameObject score;
//     // public GameObject timeforpuzzle1r1;
//     // public GameObject timeforpuzzle2r1;
//     // public GameObject timeforpuzzle3r1;
//     // public GameObject timeforpuzzle1r2;
//     // public GameObject timeforpuzzle2r2;
//     // public GameObject timeforpuzzle3r2;
//     // public GameObject timeforpuzzle1r3;
//     // public GameObject timeforpuzzle2r3;
//     // public GameObject timeforpuzzle3r3;
//     // public GameObject hintsforpuzzle1;
//     // public GameObject hintsforpuzzle2;
//     // public GameObject hintsforpuzzle3;
//     // public GameObject timeforroom1;
//     // public GameObject timeforroom2;
//     // public GameObject timeforroom3;
//     // public GameObject totalnumberofhints;
//     // public GameObject heartratebefore;
//     // public GameObject heartrateafter;
//     // public GameObject rating;
//     // public GameObject difficulty;
//     // public GameObject likes;
//     // public GameObject dislikes;
//     // public GameObject wishtheycoulddo;

//     // private string Name;
//     // private string Score;
//     // private string TimeForPuzzle1r1;
//     // private string TimeForPuzzle2r1;
//     // private string TimeForPuzzle3r1;
//     // private string TimeForPuzzle1r2;
//     // private string TimeForPuzzle2r2;
//     // private string TimeForPuzzle3r2;
//     // private string TimeForPuzzle1r3;
//     // private string TimeForPuzzle2r3;
//     // private string TimeForPuzzle3r3;
//     // private string HintsForPuzzle1;
//     // private string HintsForPuzzle2;
//     // private string HintsForPuzzle3;
//     // private string TimeForRoom1;
//     // private string TimeForRoom2;
//     // private string TimeForRoom3;
//     // private string TotalNumberOfHints;
//     // private string HeartRateBefore;
//     // private string HeartRateAfter;
//     // private string Rating;
//     // private string Difficulty;
//     // private string Likes;
//     // private string Dislikes;
//     // private string WishTheyCouldDo;

//     // private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";

//     // IEnumerator Post(string name, string score, string timeforpuzzle1r1, string timeforpuzzle2r1, string timeforpuzzle3r1, string timeforpuzzle1r2, string timeforpuzzle2r2, string timeforpuzzle3r2, string timeforpuzzle1r3, string timeforpuzzle2r3, string timeforpuzzle3r3, string hintsforpuzzle1, string hintsforpuzzle2, string hintsforpuzzle3, string timeforroom1, string timeforroom2, string timeforroom3, string totalnumberofhints, string heartratebefore, string heartrateafter, string rating, string difficulty, string likes, string dislikes, string wishtheycoulddo)
//     // {
//     //     WWWForm form = new WWWForm();
//     //     form.AddField("entry.1288604378", name);
//     //     form.AddField("entry.876960760", score);
//     //     form.AddField("entry.1605547814", timeforpuzzle1r1);
//     //     form.AddField("entry.46043638", timeforpuzzle2r1);
//     //     form.AddField("entry.1212807785", timeforpuzzle3r1);
//     //     form.AddField("entry.462832709", timeforpuzzle1r2);
//     //     form.AddField("entry.1474807138", timeforpuzzle2r2);
//     //     form.AddField("entry.1405352907", timeforpuzzle3r2);
//     //     form.AddField("entry.1569948200", timeforpuzzle1r3);
//     //     form.AddField("entry.454777614", timeforpuzzle2r3);
//     //     form.AddField("entry.1078749720", timeforpuzzle3r3);
//     //     form.AddField("entry.292689356", hintsforpuzzle1);
//     //     form.AddField("entry.504458729", hintsforpuzzle2);
//     //     form.AddField("entry.2002984662", hintsforpuzzle3);
//     //     form.AddField("entry.1518842093", timeforroom1);
//     //     form.AddField("entry.974818698", timeforroom2);
//     //     form.AddField("entry.411248928", timeforroom3);
//     //     form.AddField("entry.1833221045", totalnumberofhints);
//     //     form.AddField("entry.632023255", heartratebefore);
//     //     form.AddField("entry.2076689957", heartrateafter);
//     //     form.AddField("entry.1522289904", rating);
//     //     form.AddField("entry.347837100", difficulty);
//     //     form.AddField("entry.1483791588", likes);
//     //     form.AddField("entry.1549649089", dislikes);
//     //     form.AddField("entry.2021286873", wishtheycoulddo);
//     //     byte[] rawData = form.data;
//     //     WWW www = new WWW(BASE_URL, rawData);
//     //     Debug.Log("Data user: " + name + " and score: " + score + " sent");
//     //     yield return www;
//     // }

//     // public void Send()
//     // {
//     //     CountdownTimer m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
//     //     Score = m_cdTimer.timeValue.ToString(); //score.GetComponent<InputField>().text;

//     //     Name = username.GetComponent<TMP_InputField>().text;
//     //     Score = score.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle1r1 = timeforpuzzle1r1.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle2r1 = timeforpuzzle2r1.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle3r1 = timeforpuzzle3r1.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle1r2 = timeforpuzzle1r2.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle2r2 = timeforpuzzle2r2.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle3r2 = timeforpuzzle3r2.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle1r3 = timeforpuzzle1r3.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle2r3 = timeforpuzzle2r3.GetComponent<TMP_InputField>().text;
//     //     TimeForPuzzle3r3 = timeforpuzzle3r3.GetComponent<TMP_InputField>().text;
//     //     HintsForPuzzle1 = hintsforpuzzle1.GetComponent<TMP_InputField>().text;
//     //     HintsForPuzzle2 = hintsforpuzzle2.GetComponent<TMP_InputField>().text;
//     //     HintsForPuzzle3 = hintsforpuzzle3.GetComponent<TMP_InputField>().text;
//     //     TimeForRoom1 = timeforroom1.GetComponent<TMP_InputField>().text;
//     //     TimeForRoom2 = timeforroom2.GetComponent<TMP_InputField>().text;
//     //     TimeForRoom3 = timeforroom3.GetComponent<TMP_InputField>().text;
//     //     TotalNumberOfHints = totalnumberofhints.GetComponent<TMP_InputField>().text;
//     //     HeartRateBefore = heartratebefore.GetComponent<TMP_InputField>().text;
//     //     HeartRateAfter = heartrateafter.GetComponent<TMP_InputField>().text;
//     //     Rating = rating.GetComponent<TMP_InputField>().text;
//     //     Difficulty = difficulty.GetComponent<TMP_InputField>().text;
//     //     Likes = likes.GetComponent<TMP_InputField>().text;
//     //     Dislikes = dislikes.GetComponent<TMP_InputField>().text;
//     //     WishTheyCouldDo = wishtheycoulddo.GetComponent<TMP_InputField>().text;

//     //     StartCoroutine(Post(Name, Score, TimeForPuzzle1r1, TimeForPuzzle2r1, TimeForPuzzle3r1, TimeForPuzzle1r2, TimeForPuzzle2r2, TimeForPuzzle3r2, TimeForPuzzle1r3, TimeForPuzzle2r3, TimeForPuzzle3r3, HintsForPuzzle1, HintsForPuzzle2, HintsForPuzzle3, TimeForRoom1, TimeForRoom2, TimeForRoom3, TotalNumberOfHints, HeartRateBefore, HeartRateAfter, Rating, Difficulty, Likes, Dislikes, WishTheyCouldDo));
//     // }

//     // public void getName()
//     // {
//     //     Name = username.GetComponent<TMP_InputField>().text;
//     // }
// }
