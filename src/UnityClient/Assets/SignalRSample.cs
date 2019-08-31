using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalRSample : MonoBehaviour
{
    public GameObject text;
    private Text _outputText;
    private string _receivedMessage;
    private HubConnection _con;
    // Start is called before the first frame update
    async void Start()
    {
        _outputText = text.GetComponent<Text>();

        _con = new HubConnectionBuilder()
            .WithUrl("http://localhost:7071/api")
            .Build();
        _con.On<string>("addMessage", x =>
        {
            _receivedMessage = x;
        });
        await _con.StartAsync();
    }

    void Update()
    {
        _outputText.text = _receivedMessage;
    }
}
