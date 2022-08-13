using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject door;
    public Renderer doorMat;
    public Transform spawnZone;
    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerManager.cubesCollected += DesactiveDoor;
    }

    private void OnDisable()
    {
        PlayerManager.cubesCollected -= DesactiveDoor;
    }
    public void DesactiveDoor()
    {
        doorMat.enabled = false;
        door.GetComponentInChildren<ParticleSystem>().Play();
        door.GetComponent<BoxCollider>().isTrigger = true;
        
    }
}
