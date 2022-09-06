using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwisterBehaviour : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.onChangingPosFromTwister += SpawnToNewMaze;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnDisable()
    {
        GameManager.onChangingPosFromTwister -= SpawnToNewMaze;
    }
    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void SpawnToNewMaze(Transform inMaze)
    {
        transform.position = inMaze.position;
    }

}
