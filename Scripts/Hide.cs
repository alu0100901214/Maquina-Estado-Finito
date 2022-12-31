using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hide : StateMachineBehaviour
{
    public Transform player;
    GameObject Robot;
    public NavMeshAgent agent;

    public float fireRate;
    public float nextFire = 0.0f;

    private void Awake(){
        agent = GameObject.FindGameObjectWithTag("ai").GetComponent<NavMeshAgent>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("toHide",false);
        Robot = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float dist = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;

        for (int i = 0; i < World.Instance.GetHidingSpots().Length; i++)
        {
            Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - player.transform.position;
            Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 10;

            if (Vector3.Distance(Robot.transform.position, hidePos) < dist) {
                chosenSpot = hidePos;
                dist = Vector3.Distance(Robot.transform.position, hidePos);
            }
        }

        agent.SetDestination(chosenSpot);

        if(Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Robot.GetComponent<health>().recoverHealth(1);
        }

        if(Robot.GetComponent<health>().currentHealth >= 10){
            animator.SetBool("toPatrol",true);
        }
    }

}
