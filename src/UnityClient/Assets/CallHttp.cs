using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallHttp : MonoBehaviour
{
    public GameObject text;
    private Text _outputText;

    void Start()
    {
        _outputText = text.GetComponent<Text>();
    }

    private IEnumerator OnSend(string uri)
    {
        var req = UnityWebRequest.Get(uri);
        yield return req.SendWebRequest();
        Debug.Log($"Result: {req.downloadHandler.text}");
        _outputText.text = req.downloadHandler.text;
    }

    public void OnPointerClick(BaseEventData eventData)
    {
        Debug.Log("Invoked");
        StartCoroutine(OnSend("http://localhost:7071/api/sample?name=xxxx"));
    }
}
