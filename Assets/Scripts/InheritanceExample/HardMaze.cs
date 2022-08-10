using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMaze : MazeParent
{
    private int enemy_robot_count;

    public void EnemiesOn()
    {
        Debug.Log("Tu competidor ha empezado a buscar los cubos");
    }
}
