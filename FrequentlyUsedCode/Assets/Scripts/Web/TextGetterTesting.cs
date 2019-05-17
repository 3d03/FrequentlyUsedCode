using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TextGetterTesting : MonoBehaviour
{
    public string textFromWWW;
    public string url = ""; // <-- enter your url here

    public Text text;
    void Start()
    {
            StartCoroutine(GetText());
    }


    public void AssignText()
    {
        text.text = textFromWWW;
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            textFromWWW = www.downloadHandler.text;
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
