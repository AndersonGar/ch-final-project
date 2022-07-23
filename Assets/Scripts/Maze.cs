using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject door;
    public Renderer doorMat;
    public Transform spawnZone;
    // Start is called before the first frame update
    public void DesactiveDoor()
    {

        //door.SetActive(false);
        Color c = doorMat.material.color;
        doorMat.material.color = new Color(c.r,c.g,c.b,0.25f);
        door.GetComponent<BoxCollider>().isTrigger = true;
        
    }
}
