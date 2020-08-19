using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
    public string URL = "https://benbaeyens.com";
    public Text response;


    private void Start()
    {
        Request();
    }

    public void Request()
    {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    IEnumerator OnResponse(WWW req)
    {
        yield return req;

        response.text = req.text;
    }
}
