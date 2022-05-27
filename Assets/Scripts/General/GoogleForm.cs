// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GoogleForm : MonoBehaviour
// {
//    [SerializedField] InputField Username;
//    [SerializedField] InputField Score;
//    [SerializedField] InputField TimeForPuzzle1r1;
//    [SerializedField] InputField TimeForPuzzle2r1;
//    [SerializedField] InputField TimeForPuzzle3r1;
//    [SerializedField] InputField TimeForPuzzle1r2;
//    [SerializedField] InputField TimeForPuzzle2r2;
//    [SerializedField] InputField TimeForPuzzle3r2;
//    [SerializedField] InputField TimeForPuzzle1r3;
//    [SerializedField] InputField TimeForPuzzle2r3;
//    [SerializedField] InputField TimeForPuzzle3r3;
//    [SerializedField] InputField HintsForPuzzle1;
//    [SerializedField] InputField HintsForPuzzle2;
//    [SerializedField] InputField HintsForPuzzle3;
//    [SerializedField] InputField TimeForRoom1;
//    [SerializedField] InputField TimeForRoom2;
//    [SerializedField] InputField TimeForRoom3;
//    [SerializedField] InputField TotalNumberOfHints;
//    [SerializedField] InputField HeartRateBefore;
//    [SerializedField] InputField HeartRateAfter;
//    [SerializedField] InputField Rating;
//    [SerializedField] InputField Difficulty;
//    [SerializedField] InputField Likes;
//    [SerializedField] InputField Dislikes;
//    [SerializedField] InputField WishTheyCouldDo;

//     private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";
    
//     public void Send()
//     {
//         StartCoroutine(Post(Name, Score, TimeForPuzzle1r1, TimeForPuzzle2r1, TimeForPuzzle3r1, TimeForPuzzle1r2, TimeForPuzzle2r2, TimeForPuzzle3r2, TimeForPuzzle1r3, TimeForPuzzle2r3, TimeForPuzzle3r3, HintsForPuzzle1, HintsForPuzzle2, HintsForPuzzle3, TimeForRoom1, TimeForRoom2, TimeForRoom3, TotalNumberOfHints, HeartRateBefore, HeartRateAfter, Rating, Difficulty, Likes, Dislikes, WishTheyCouldDo));
//     }

//       IEnumerator Post(string name, string score, string timeforpuzzle1r1, string timeforpuzzle2r1, string timeforpuzzle3r1, string timeforpuzzle1r2, string timeforpuzzle2r2, string timeforpuzzle3r2, string timeforpuzzle1r3, string timeforpuzzle2r3, string timeforpuzzle3r3, string hintsforpuzzle1, string hintsforpuzzle2, string hintsforpuzzle3, string timeforroom1, string timeforroom2, string timeforroom3, string totalnumberofhints, string heartratebefore, string heartrateafter, string rating, string difficulty, string likes, string dislikes, string wishtheycoulddo)
//    {
//        WWWForm form = new WWWForm();
//        form.AddField("entry.1288604378", name);
//        form.AddField("entry.876960760", score);
//        form.AddField("entry.1605547814", timeforpuzzle1r1);
//        form.AddField("entry.46043638", timeforpuzzle2r1);
//        form.AddField("entry.1212807785", timeforpuzzle3r1);
//        form.AddField("entry.462832709", timeforpuzzle1r2);
//        form.AddField("entry.1474807138", timeforpuzzle2r2);
//        form.AddField("entry.1405352907", timeforpuzzle3r2);
//        form.AddField("entry.1569948200", timeforpuzzle1r3);
//        form.AddField("entry.454777614", timeforpuzzle2r3);
//        form.AddField("entry.1078749720", timeforpuzzle3r3);
//        form.AddField("entry.292689356", hintsforpuzzle1);
//        form.AddField("entry.504458729", hintsforpuzzle2);
//        form.AddField("entry.2002984662", hintsforpuzzle3);
//        form.AddField("entry.1518842093", timeforroom1);
//        form.AddField("entry.974818698", timeforroom2);
//        form.AddField("entry.411248928", timeforroom3);
//        form.AddField("entry.1833221045", totalnumberofhints);
//        form.AddField("entry.632023255", heartratebefore);
//        form.AddField("entry.2076689957", heartrateafter);
//        form.AddField("entry.1522289904", rating);
//        form.AddField("entry.347837100", difficulty);
//        form.AddField("entry.1483791588", likes);
//        form.AddField("entry.1549649089", dislikes);
//        form.AddField("entry.2021286873", wishtheycoulddo);

//        UnityWebRequest www = UnityWebRequest.Post(URL, form);

//        yield return www.SendRequest();
//    }
// }
