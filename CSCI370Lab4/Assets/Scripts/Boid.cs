using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;

    private float cohesionRadius = 10;
    private float separationDistance = 5;
    private Collider[] boids;
    private Vector3 cohesion;
    private Vector3 separation;
    private int separationCount;
    private Vector3 alignment;
    private float maxSpeed = 15;
    Collider collide;
    Rigidbody rb;

    private void Start()
    {
        collide = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        velocity = Vector3.forward;
        InvokeRepeating("CalculateVelocity", 0, 0.1f);
    }

    void CalculateVelocity()
    {
        Debug.Log("Help");
        cohesion = Vector3.zero;
        separation = Vector3.zero;
        separationCount = 0;
        alignment = Vector3.zero;

        boids = GetNearbyObjects();
        foreach (var boid in boids)
        {
            if (boid.tag == "Fish1")
            {
                cohesion += boid.transform.position;
                alignment += boid.GetComponent<Rigidbody>().velocity;

                if (boid != collide && (transform.position - boid.transform.position).magnitude < separationDistance)
                {
                    separation += (transform.position - boid.transform.position) / (transform.position - boid.transform.position).magnitude;
                    separationCount++;
                }
            }
        }

        if (boids.Length > 0)
        {
            cohesion = cohesion / boids.Length;
            cohesion = cohesion - transform.position;
            cohesion = Vector3.ClampMagnitude(cohesion, maxSpeed);
        }
        if (separationCount > 0)
        {
            separation = separation / separationCount;
            separation = Vector3.ClampMagnitude(separation, maxSpeed);
        }
        if (boids.Length > 0)
        {
            alignment = alignment / boids.Length;
            alignment = Vector3.ClampMagnitude(alignment, maxSpeed);
        }

        velocity += cohesion + separation * 10 + alignment * 1.5f;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    
    }

    Collider[] GetNearbyObjects()
    {
        int size = 0;
        Collider[] contextColliders = Physics.OverlapSphere(transform.position, cohesionRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != collide)
            {
                size++;
            }
        }
        Collider[] returnArray = new Collider[size];
        int tracker = 0;
        foreach (Collider c in contextColliders)
        {
            if (c != collide)
            {
                returnArray[tracker] = c;
                Debug.Log(c);
            }
        }
        return returnArray;
    }

    void Update()
    {
        if (transform.position.magnitude > 25)
        {
            velocity += -transform.position.normalized;
        }

        transform.position += velocity * Time.deltaTime;

        Debug.DrawRay(transform.position, separation, Color.green);
        Debug.DrawRay(transform.position, cohesion, Color.magenta);
        Debug.DrawRay(transform.position, alignment, Color.blue);
    }
}
