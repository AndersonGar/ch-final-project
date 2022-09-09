using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 initPosition;
    public Transform target;
    bool falling;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.onInstantianteingMaze += StartFalling;
        MenuManager.onPausingOrResuming += StreamSound;
    }

    private void OnDisable()
    {
        GameManager.onInstantianteingMaze -= StartFalling;
        MenuManager.onPausingOrResuming -= StreamSound;
    }

    void StreamSound(bool value)
    {
        GetComponent<AudioSource>().Play();
        if (!value)
        {
            GetComponent<AudioSource>().Pause();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            MoveToTarget();
        }
    }

    void StartFalling(Transform newTarget)
    {
        transform.position = initPosition;
        falling = true;
        target = newTarget;
    }

    void MoveToTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position,step);
    }
}
