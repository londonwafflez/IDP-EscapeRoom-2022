using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleForm : MonoBehaviour
{
   [SerializeField] InputField Username;
   [SerializeField] InputField Score;
   [SerializeField] InputField TimeForPuzzle1r1;
   [SerializeField] InputField TimeForPuzzle2r1;
   [SerializeField] InputField TimeForPuzzle3r1;
   [SerializeField] InputField TimeForPuzzle1r2;
   [SerializeField] InputField TimeForPuzzle2r2;
   [SerializeField] InputField TimeForPuzzle3r2;
   [SerializeField] InputField TimeForPuzzle1r3;
   [SerializeField] InputField TimeForPuzzle2r3;
   [SerializeField] InputField TimeForPuzzle3r3;
   [SerializeField] InputField HintsForPuzzle1;
   [SerializeField] InputField HintsForPuzzle2;
   [SerializeField] InputField HintsForPuzzle3;
   [SerializeField] InputField TimeForRoom1;
   [SerializeField] InputField TimeForRoom2;
   [SerializeField] InputField TimeForRoom3;
   [SerializeField] InputField TotalNumberOfHints;
   [SerializeField] InputField HeartRateBefore;
   [SerializeField] InputField HeartRateAfter;
   [SerializeField] InputField Rating;
   [SerializeField] InputField Difficulty;
   [SerializeField] InputField Likes;
   [SerializeField] InputField Dislikes;
   [SerializeField] InputField WishTheyCouldDo;

    private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdvKxbJzSXpFuFo5ogRHYYe5hbzx12OmnLe4MgNNkgi29s78w/formResponse";
    
    public void Send()
    {
        StartCoroutine(Post(Username.text, Score.text, TimeForPuzzle1r1.text, TimeForPuzzle2r1.text, TimeForPuzzle3r1.text, TimeForPuzzle1r2.text, TimeForPuzzle2r2.text, TimeForPuzzle3r2.text, TimeForPuzzle1r3.text, TimeForPuzzle2r3.text, TimeForPuzzle3r3.text, HintsForPuzzle1.text, HintsForPuzzle2.text, HintsForPuzzle3.text, TimeForRoom1.text, TimeForRoom2.text, TimeForRoom3.text, TotalNumberOfHints.text, HeartRateBefore.text, HeartRateAfter.text, Rating.text, Difficulty.text, Likes.text, Dislikes.text, WishTheyCouldDo.text));
    }

      IEnumerator Post(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17, string s18, string s19, string s20, string s21, string s22, string s23, string s24, string s25)
   {
       WWWForm form = new WWWForm();
       form.AddField("entry.1288604378", s1);
       form.AddField("entry.876960760", s2);
       form.AddField("entry.1605547814", s3);
       form.AddField("entry.46043638", s4);
       form.AddField("entry.1212807785", s5);
       form.AddField("entry.462832709", s6);
       form.AddField("entry.1474807138", s7);
       form.AddField("entry.1405352907", s8);
       form.AddField("entry.1569948200", s9);
       form.AddField("entry.454777614", s10);
       form.AddField("entry.1078749720", s11);
       form.AddField("entry.292689356", s12);
       form.AddField("entry.504458729", s13);
       form.AddField("entry.2002984662", s14);
       form.AddField("entry.1518842093", s15);
       form.AddField("entry.974818698", s16);
       form.AddField("entry.411248928", s17);
       form.AddField("entry.1833221045", s18);
       form.AddField("entry.632023255", s19);
       form.AddField("entry.2076689957", s20);
       form.AddField("entry.1522289904", s21);
       form.AddField("entry.347837100", s22);
       form.AddField("entry.1483791588", s23);
       form.AddField("entry.1549649089", s24);
       form.AddField("entry.2021286873", s25);

       UnityWebRequest www = UnityWebRequest.Post(URL, form);

       yield return www.SendWebRequest();
   }
}
