using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Wander : StateMachineBehaviour
{

    
    public NavMeshAgent agent;
    public Transform player;
    Vector3 dest;

    float visDist = 15.0f;
    float visAngle = 45.0f;

    GameObject Robot;


    private void Awake(){
        agent = GameObject.FindGameObjectWithTag("ai").GetComponent<NavMeshAgent>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("toPatrol",false);
        Robot = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dest = new Vector3(Random.Range(-25, 25), 1.313f, Random.Range(-25, 25));
        agent.SetDestination(dest);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector3 d = agent.destination;
        Vector3 distance = agent.destination - Robot.transform.position;
        //Debug.Log("DISTANCE: " + distance.magnitude);
        if(distance.magnitude <= 3){
            dest = new Vector3(Random.Range(-25, 25), 1.313f, Random.Range(-25, 25));
            agent.SetDestination(dest);
        }

        Vector3 direction = player.position - Robot.transform.position;
        //Debug.Log("DISTANCE: " + direction.magnitude);
        float angle = Vector3.Angle(direction, Robot.transform.forward);
        //Debug.Log("ANGLE: " + angle);
        if (direction.magnitude < visDist && angle < visAngle){
            animator.SetBool("toChase",true);
        }

        if(Robot.GetComponent<health>().currentHealth <= 4){
            animator.SetBool("toHide",true);
        }
    }

}