using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealthScript : MonoBehaviour
{
    public int maxHealth = 5; // Set maximum health
    public int currentHealth; // make a callable to get current health
    public Animator PlayerAnim;
    public Animator Minion;
    public float effectTiming;



    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // if game start, all enemy health value are set to max value
        healthBar.SetMaxHealth(maxHealth); // set value

    }

   
    //Update is called once per frame
    //void OnCollisionStay(Collision collision)
    void OnTriggerStay(Collider collider) // Set as trigger so the attack is only effective if in range of enemy | Due to trigger stay enenemy keep looping
     {
        
        if (currentHealth != 0) // check if enemy isn't dead
        {
            if (Input.GetKeyDown(KeyCode.A)) // if hit space bar, apply damage | Note subject to change to UI panel
            {

                TakeDamage(1); // hit damage value are set to 1
                Minion.SetTrigger("HitDamage");
                print("current health is " + currentHealth);
            } 
        }
        if (currentHealth == 0) // Minion death is at 0 then die
            {
            print("Minion Will die");
            
            if (Minion.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true) // if current anim was Idle and health is zero then die


                { 
                Minion.SetTrigger("Dead");
                print("from Minion Health Script: Minion health is 0");
                }
            
            }
        
    }

    void Update()
    {
        if (currentHealth == 0) // Minion death is at 0 then die
        {
            print("I should die once only ");
           Minion.SetTrigger("Dead");
        }
    }


void TakeDamage(int damage) // Apply damage script
    {
        currentHealth -= damage; // if damage apply hit Take Damage Value

        healthBar.SetHealth(currentHealth); // Set new Value


    }
}

