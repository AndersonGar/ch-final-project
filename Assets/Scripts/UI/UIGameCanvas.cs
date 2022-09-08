using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIGameCanvas : MonoBehaviour
{
    public TextMeshProUGUI txtTimer, txtCubeCounter, txtMessages;
    public string[] messagesValues = new string[7];
    [SerializeField] UnityEvent OnNotification;
    // Start is called before the first frame update
    void Start()
    {
        txtTimer.text = string.Format("{0:00}:{1:00}",5,0);
        txtMessages.text = "";
        txtCubeCounter.text = "0/4";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimerText(int minutes, int seconds, int miliseconds)
    {
        txtTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateMessageText(int i)
    {
        string _message = messagesValues[i];
        OnNotification.Invoke();
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
