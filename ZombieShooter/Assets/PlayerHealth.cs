using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //create a public method that reduces hit points by the amount of damage

    public void TakeDamage(float damage){
        hitPoints -= damage;
        if(hitPoints<=0){
            GetComponent<DeathHandler>().HandleDeath();
           Debug.Log("You dead. my glip glop");
        }

    }
}
