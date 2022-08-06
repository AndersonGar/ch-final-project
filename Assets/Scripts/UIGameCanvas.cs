using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameCanvas : MonoBehaviour
{
    public TextMeshProUGUI txtTimer, txtCubeCounter, txtMessages;
    public string[] messagesValues = new string[7];
    // Start is called before the first frame update
    void Start()
    {
        txtTimer.text = "5:00:00";
        txtMessages.text = "";
        txtCubeCounter.text = "0/4";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimerText(int minutes, int seconds, int miliseconds)
    {
        txtTimer.text = minutes + ":" + seconds + ":" + miliseconds;
    }

    public void UpdateMessageText(int i)
    {
        string _message = messagesValues[i];
        StartCoroutine(StartMessaging(_message));
    }

    public void UpdateCubeCounterText(int i)
    {
        txtCubeCounter.text = i + "/" + 4.ToString();
    }

    IEnumerator StartMessaging(string message)
    {
        txtMessages.text = message;
        yield return new WaitForSeconds(3);
        txtMessages.text = "";
    }
}
