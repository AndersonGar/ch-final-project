using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject effectPref;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    public void DestroyPickup()
    {
        GameObject effect = Instantiate(effectPref, this.transform.position, Quaternion.identity);
        Destroy(effect);

    }

}
