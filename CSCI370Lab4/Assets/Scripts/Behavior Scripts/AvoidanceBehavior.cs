using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute (menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, maintain current alignment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        //add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        foreach (Transform item in context)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) <= flock.SquareAvoidanceRad)
            {
                nAvoid++;
                avoidanceMove += agent.transform.position - item.position;
            }
        }
        
        if (nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }

        return avoidanceMove;
    }
}
