using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navAgent;

        private void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navAgent.destination = destination;
            navAgent.isStopped = false;
        }

        public void Cancel()
        {
            navAgent.isStopped = true;
            print("Canceling Movement");
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }


    }

}