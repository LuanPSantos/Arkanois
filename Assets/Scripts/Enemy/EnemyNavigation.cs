using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyNavigation : MonoBehaviour
{

    [SerializeField]
    private float minMovementDurantion;
    [SerializeField]
    private float maxMovementDurantion;
    private AIPath path;
    private GraphNode randomNode;

    private float currentTimer;
    private float singleMomentDurantion;

    void Start()
    {
        path = GetComponent<AIPath>();

        PickRandomDestination();
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;

        if(currentTimer > singleMomentDurantion)
        {
            PickRandomDestination();
        }
    }

    private void PickRandomDestination()
    {
        singleMomentDurantion = Random.Range(minMovementDurantion, maxMovementDurantion);
        currentTimer = 0;
        var grid = AstarPath.active.data.gridGraph;

        randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];

        path.destination = (Vector3)randomNode.position;
        path.SearchPath();
    }
}
