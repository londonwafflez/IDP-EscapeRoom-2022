using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReadGoogleSheet : MonoBehaviour
{
    public Text outputArea;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObtainSheetData());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ObtainSheetData());
    }
    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            string updateText = "";
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);

            foreach (var item in o["feed"]["entry"])
            {
                var itemo = JSON.Parse(item.ToString());

                updateText += itemo [0]["gsx$timestamp"]["$t"] + ":" + itemo[0]["gsx$username"]["$t"] + itemo[0]["gsx$score"]["$t"];
            }
            outputArea.text = updateText;
        }
    }
}
