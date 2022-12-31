using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachineBehaviour {

    public Transform player;
    GameObject Robot;
    public NavMeshAgent agent;

    float visDistToSeek = 12.0f;

    private void Awake(){
        agent = GameObject.FindGameObjectWithTag("ai").GetComponent<NavMeshAgent>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("toAttack",false);
        Robot = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        var direction = player.transform.position - Robot.transform.position;
        if (direction.magnitude > visDistToSeek){
            animator.SetBool("toChase",true);
        }
        if(Robot.GetComponent<health>().currentHealth <= 4){
            animator.SetBool("toHide",true);
        }
    }

}
