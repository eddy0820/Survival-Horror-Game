using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    public float chaseRange = 7;
    public HidingSpot hidingSpots;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform wayPointsOject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach(Transform t in wayPointsOject)
        {
            wayPoints.Add(t);
        }
        
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // hidingSpots = GameObject.FindObjectOfType(typeof(HidingSpot)) as HidingSpot;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (timer > 20)
            {
                animator.SetBool("isPatrolling", false);
            }

        if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
            }

            if (distance < chaseRange && hidingSpots.inside == false)
                {
                    animator.SetBool("isChasing", true);
                }
    

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
