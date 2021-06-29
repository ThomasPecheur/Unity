using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class MinionFightingSystem : MonoBehaviour
{
    public GameObject playerPanel;
    public GameObject Player;
    public Animator animMainPlayer;
    public GameObject MainPlayerUI;
    public Animator MinionAnim;
    //public NextPlayersTurn whosTurn ;
    public int whosTurn = 0; // to not error set whos Turn at 0
    

    void CombatStateLook()
    {
           CombatStateManager.instance.NextPlayersTurn();//optimzie Speed instead of component
    //int a =   Player.Find("CombatStateManager").GetComponent<CombatStateManager>().WhosTurn;
    //Debug.Log(a.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        //whosTurn = 0;
        if (whosTurn == 1)


        {
            if (animMainPlayer.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true)
            {

                print("Enemy Turn");
                whosTurn = 1; // Set interger to whos turn
                MinionAnim.SetTrigger("Attack");// if minion turns, set trigger to attack player |
                MinionAnim.SetTrigger("Idle");// after attack go idle and wait your turn

            }
            else
            {
                print("Player Turn");
                whosTurn = 0; // set variable to be picked up by PlayerFight Script || 0= player turn to attack!
                MainPlayerUI.SetActive(true);
                if (animMainPlayer.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true)
                {
                    print("Button of playerPanel is Attacking mod");
                    //MinionAnim.SetTrigger("HitDamage");// if main player is attacking Minion get hit interaction.

                }
            }
        }
        if (whosTurn == 0)
            {
                print("Player still in look for enemy");
            }
    }

}

