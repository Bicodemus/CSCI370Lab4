using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(10, 50)]
    public int startingCount = 20;
    const float AgentDensity = 0.08f;
    public float spawnSize;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRad = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadMultiplier = 1f;

    float squareMaxSpeed;
    float squareNeighborRad;
    float squareAvoidanceRad;
    public float SquareAvoidanceRad { get { return squareAvoidanceRad; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRad = neighborRad * neighborRad;
        squareAvoidanceRad = squareNeighborRad * avoidanceRadMultiplier * avoidanceRadMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                (Random.insideUnitSphere * startingCount * AgentDensity * spawnSize) + transform.position,
                Quaternion.Euler(Vector3.up * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRad);
        foreach(Collider c in contextColliders)
        {
            if ( c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

}
