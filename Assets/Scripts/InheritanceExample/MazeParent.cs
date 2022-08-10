using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeParent : MonoBehaviour
{
    private int pickups_count;
    private int level;

    public int Pickups_count { get => pickups_count; set => pickups_count = value; }
    public int Level { get => level; set => level = value; }

    public void OpenMaze()
    {
        Debug.Log("Bienvenido al laberinto");
    }

    public void CloseMaze()
    {
        Debug.Log("Saliendo del laberinto");
    }


}
