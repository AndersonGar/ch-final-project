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
        if (time <= 0)
        {
            Debug.Log("Perdiste, el tiempo se acabó");
        }
    }

    void ResetTimer()
    {
        time = timer;
        print("Tienes "+timer+" segundos para hallar las 4 cajas y abrir la puerta");
    }
}
