using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seek : StateMachineBehaviour {

    public Transform player;
    GameObject Robot;
    public NavMeshAgent agent;

    float visDistToPatrol = 20.0f;
    float visDistToAttack = 10.0f;

    private void Awake(){
        agent = GameObject.FindGameObjectWithTag("ai").GetComponent<NavMeshAgent>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("toChase",false);
        Robot = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        agent.SetDestination(player.transform.position);
        var direction = player.transform.position - Robot.transform.position;
        if (direction.magnitude > visDistToPatrol){
            animator.SetBool("toPatrol",true);
        }
        if (direction.magnitude < visDistToAttack){
            animator.SetBool("toAttack",true);
        }
        if(Robot.GetComponent<health>().currentHealth <= 4){
            animator.SetBool("toHide",true);
        }
    }

}
