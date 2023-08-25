using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private float minMovementDurantion;
    [SerializeField]
    private float maxMovementDurantion;
    [SerializeField]
    private GameEvent destroied;
    [SerializeField]
    private int score;
    private AIPath path;
    private GraphNode randomNode;

    private float currentTimer;
    private float singleMomentDurantion;

    void Start()
    {
        path = GetComponent<AIPath>();

        PickRandomDestination();
    }

    void Update()
    {
        currentTimer += Time.deltaTime;

        if(currentTimer > singleMomentDurantion)
        {
            PickRandomDestination();
        }
    }

    public void OnHittedByBall()
    {
        Destroy();
    }

    public void Destroy()
    {
        destroied.Raise(score);
        Destroy(gameObject);
    }

    public void OnGamePaused()
    {
        path.canMove = false;
    }

    public void OnGameResumed()
    {
        path.canMove = true;
    }

    private void PickRandomDestination()
    {
        currentTimer = 0;
        singleMomentDurantion = Random.Range(minMovementDurantion, maxMovementDurantion);
        var grid = AstarPath.active.data.gridGraph;

        randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];

        path.destination = (Vector3)randomNode.position;
        path.SearchPath();
    }
}
