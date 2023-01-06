using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead(){
        return isDead;
    }

    //create a public method that reduces hit points by the amount of damage

    public void TakeDamage(float damage){
        //GetComponent<EnemyAI>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints<=0){
            Die();
                       // Destroy(gameObject);
        }

    }
[SerializeField] GameObject EnemyNew;
[SerializeField] float timeBeforeRevival = 60f;
    private void Die(){

        if(isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
Invoke("NewEnemy", timeBeforeRevival);
        
    }

    private void NewEnemy(){
        Debug.Log("new enemy called");
//i had to explicitly enable the components after instantiating as there was some bug in the unity and the components didnt get enabled after instantiation
        GameObject en;
        en = Instantiate(EnemyNew, transform.position, Quaternion.identity) as GameObject;
        UnityEngine.AI.NavMeshAgent nav= en.GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.enabled = true;
        EnemyAi aiScript = en.GetComponent<EnemyAi>();
        aiScript.enabled = true;
        EnemyHealth aiHealth = en.GetComponent<EnemyHealth>();
        aiHealth.hitPoints = Time.time/10;

    }
}
