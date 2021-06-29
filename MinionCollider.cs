using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class MinionCollider : MonoBehaviour
{
    // Public V3 is to find the position of the character that trigger the box collider
    public Vector3 pos;
    public float speed = 1.0f;
    public Animator anim;
    public Slider EnemyHealth;

    // For Script to work, you need to have a box collider, nav mesh and a riggid body attach to both character
    // Box collider for both character must be on trigger


    void OnTriggerEnter(Collider other) // onTrigger Enter instead of Stay to kill the idle annimation
    {
        
        if (EnemyHealth.value  == 0)
        {
            print("Enemy HealthBar is 0");
            //Do not move
        }

        if (EnemyHealth.value != 0) // if Slider equal is not 0 then do action
        {
            print("Enemy is alive");
        
            //print name of Character collided with
            string PlayerName = (other.name);
            //print (PlayerName);

        
            string CurrentEnemy = (this.transform.name);// Get Current Enemy name
            //print(CurrentEnemy);

            if (PlayerName == "Player")
            {
                print("From Minion Collider Script: Good_CH");// double checking if right CH // Under the Minion Nav Mesh, set the Stopping distance at 2 to stop minion in front of ennemy 


                anim.SetTrigger("Approach");// Run Toward enemy

                Vector3 targetPosition = (other.transform.position); // Get player position
                                                                     // print(targetPosition);
                Vector3 currentPosition = this.transform.position; // Get our current node position
                                                                   //print(currentPosition);
                Vector3 directionOfTravel = targetPosition - currentPosition; // Calculate travel units

                directionOfTravel.Normalize();//now normalize the direction, since we only want the direction information
                                              //print(directionOfTravel);


                //print(this.transform.name);
                float step = speed * Time.deltaTime;
                //print(step);
                // this.transform.Translate(directionOfTravel *step);// translate minion to new position || ISSUE WITH TIME.deltaTime to translate object overtime 
                this.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
                //this.transform.(directionOfTravel * Time.deltaTime);
                anim.SetTrigger("Idle");// When landing in front player go to Idle
            }
        }

        
    }

}
