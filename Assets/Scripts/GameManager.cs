using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> mazeList;
    public Vector3 mazePosition;
    public GameObject maze, door;
    public int level = 0;
    public PlayerManager player;
    public float timer;
    float time;
    public UIGameCanvas gameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        InstiateMaze();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void ChangeMaze()
    {
        maze.SetActive(false);
        level++;
        if (level >= mazeList.Count)
        {
            gameCanvas.UpdateMessageText(5);
            Debug.Log("Ganaste, felicitaciones");
            return;
        }
        InstiateMaze();
        ResetTimer();

    }

    public void InstiateMaze()
    {
        maze = Instantiate(mazeList[level], mazePosition, Quaternion.identity);
        StartCoroutine(player.SpawnPlayer(maze.GetComponent<Maze>().spawnZone.position));
    }

    public void OpenDoor()
    {
        this.maze.GetComponent<Maze>().DesactiveDoor();
    }

    void Timer()
    {
        time -= Time.deltaTime;
        int _minutes = (int)(time / 60f);
        int _seconds = (int)(time - _minutes * 60f);
        int _miliseconds = (int)((time - (int)time) * 100f);
        if (time <= 0)
        {
            gameCanvas.UpdateMessageText(6);
            Debug.Log("Perdiste, el tiempo se acabó");
            _minutes = 0;
            _seconds = 0;
            _miliseconds = 0;
        }
        gameCanvas.UpdateTimerText(_minutes, _seconds, _miliseconds);
    }

    void ResetTimer()
    {
        time = timer;
        gameCanvas.UpdateMessageText(0);
        print("Tienes "+timer+" segundos para hallar las 4 cajas y abrir la puerta");
    }
}
