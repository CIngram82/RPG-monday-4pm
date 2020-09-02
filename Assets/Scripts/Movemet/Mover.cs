using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    NavMeshAgent navAgent;
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        UpdateAnimator();
    }

    public void MoveTo(Vector3 point)
    {

        navAgent.destination = point;

    }
    public void StopMovement()
    {
        navAgent.isStopped = true;
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = navAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
    }
}
