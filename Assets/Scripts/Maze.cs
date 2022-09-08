using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject door;
    public Renderer doorMat;
    public Transform spawnZone, twister;
    public List<Transform> lstSpawnerPoints;
    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerManager.cubesCollected += DesactiveDoor;
        PlayerManager.onTouchingEnemy += RandomSpawnPlayer;
    }

    private void OnDisable()
    {
        PlayerManager.cubesCollected -= DesactiveDoor;
        PlayerManager.onTouchingEnemy -= RandomSpawnPlayer;
    }
    public void DesactiveDoor()
    {
        doorMat.enabled = false;
        door.GetComponentInChildren<ParticleSystem>().Play();
        door.GetComponent<BoxCollider>().isTrigger = true;
    }

    void RandomSpawnPlayer(Transform player)
    {
        int r = UnityEngine.Random.Range(0, lstSpawnerPoints.Count);
        player.transform.position = lstSpawnerPoints[r].position;
    }

}
