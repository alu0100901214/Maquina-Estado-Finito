using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class health : MonoBehaviour
{
 
    public int maxHealth;
    public int currentHealth;

    public TextMeshProUGUI healthText;

    void Start(){
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Bullet"){
            if(currentHealth > 0){
                currentHealth--;
            }else{
                currentHealth = 0;
            }
        }
    }

    public void recoverHealth(int value){
        currentHealth += value;
    }
    
}
