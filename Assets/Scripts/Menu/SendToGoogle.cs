using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    // public GameObject username;
    // public GameObject score;
    // public GameObject hintsforpuzzle1;
    // public GameObject hintsforpuzzle2;
    // public GameObject hintsforpuzzle3;
    // public GameObject timeforroom1;
    // public GameObject timeforroom2;
    // public GameObject timeforroom3;
    // public GameObject totalnumberofhints;
    // public GameObject heartratebefore;
    // public GameObject heartrateafter;
    // public GameObject rating;
    // public GameObject difficulty;
    // public GameObject likes;
    // public GameObject dislikes;
    // public GameObject wishtheycoulddo;

    private static string Name = "";
    private static string Score = "";
    private static string HintsForPuzzle1 = "";
    private static string HintsForPuzzle2 = "";
    private static string HintsForPuzzle3 = "";
    private static string TimeForRoom1 = "";
    private static string TimeForRoom2 = "";
    private static string TimeForRoom3 = "";
    private static string TotalNumberOfHints = "";
    private static string HeartRateBefore = "";
    private static string HeartRateAfter = "";
    private static string Rating = "";
    private static string Difficulty = "";
    private static string Likes = "";
    private static string Dislikes = "";
    private static string WishTheyCouldDo = "";

    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";

    IEnumerator Post(string name, string score, string hintsforpuzzle1, string hintsforpuzzle2, string hintsforpuzzle3, string timeforroom1, string timeforroom2, string timeforroom3, string totalnumberofhints, string heartratebefore, string heartrateafter, string rating, string difficulty, string likes, string dislikes, string wishtheycoulddo)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1288604378", name);
        form.AddField("entry.876960760", score);
        form.AddField("entry.292689356", hintsforpuzzle1);
        form.AddField("entry.504458729", hintsforpuzzle2);
        form.AddField("entry.2002984662", hintsforpuzzle3);
        form.AddField("entry.1518842093", timeforroom1);
        form.AddField("entry.974818698", timeforroom2);
        form.AddField("entry.411248928", timeforroom3);
        form.AddField("entry.1833221045", totalnumberofhints);
        form.AddField("entry.632023255", heartratebefore);
        form.AddField("entry.2076689957", heartrateafter);
        form.AddField("entry.1522289904", rating);
        form.AddField("entry.347837100", difficulty);
        form.AddField("entry.1483791588", likes);
        form.AddField("entry.1549649089", dislikes);
        form.AddField("entry.2021286873", wishtheycoulddo);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        Debug.Log("Data user: " + name + " and score: " + score + " sent");
        yield return www;
    }

    public void Send()
    {
        StartCoroutine(Post(Name, Score, HintsForPuzzle1, HintsForPuzzle2, HintsForPuzzle3, TimeForRoom1, TimeForRoom2, TimeForRoom3, TotalNumberOfHints, HeartRateBefore, HeartRateAfter, Rating, Difficulty, Likes, Dislikes, WishTheyCouldDo));
    }

    public void GetTime()
    {
         if (GameObject.Find("TimerText") != null)
        {
            CountdownTimer m_cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
            Score = m_cdTimer.timeValue.ToString(); //score.GetComponent<InputField>().text;

            TimeForRoom1 = m_cdTimer.puzzleTimes[0].ToString();
            TimeForRoom2 = m_cdTimer.puzzleTimes[1].ToString();
            TimeForRoom3 = m_cdTimer.puzzleTimes[2].ToString();
        }

    }

    public void ReadStringInput(string a)
    {
        Name = a;
        Debug.Log(Name);
    }
    public void ReadStringInput1(string b)
    {
        HeartRateBefore = b;
        Debug.Log(HeartRateBefore);
    }
    public void ReadStringInput2(string c)
    {
        HeartRateAfter = c;
        Debug.Log(HeartRateAfter);
    }
    public void ReadStringInput3(string d)
    {
        Rating = d;
        Debug.Log(Rating);
    }
    public void ReadStringInput4(string e)
    {
        Difficulty = e;
        Debug.Log(Difficulty);
    }
    public void ReadStringInput5(string f)
    {
        Likes = f;
        Debug.Log(Likes);
    }
    public void ReadStringInput6(string g)
    {
        Dislikes = g;
        Debug.Log(Dislikes);
    }
    public void ReadStringInput7(string h)
    {
        WishTheyCouldDo = h;
        Debug.Log(WishTheyCouldDo);
    }
}
