using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject bullet;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            print("Bullet");
            GameObject b = Instantiate(bullet, this.transform.position + this.transform.forward*2f + this.transform.up*1f, this.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000);
        }
    }

}
