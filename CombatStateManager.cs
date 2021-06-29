using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CombatStateManager : MonoBehaviour
{
    //public  FightScript;
    public int whosTurn = 0;
    public GameObject ButtonIcon;
    public Animator animMainPlayer;
    public Animator MinionAnim;

   public static CombatStateManager instance;

    void Start()
    {
     instance=this;

        // hide game over panel
        ButtonIcon.SetActive(false);

        // after a small delay to get the game underway and let everything
        // set up call ManageQueue in half second
        //Invoke("ManageQueue", 0.5f);
    }


    void ManageQueue()
    {
        // turn the notification panel back on
        ButtonIcon.SetActive(true);
        whosTurn = 0;
  

        // hide panel after a while
       // Invoke("HideNotificationPanelAndLetPlayerHaveTurn", 2f);


    }



    public void NextPlayersTurn()
    {
        // next player will be selected
        
        if (animMainPlayer.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true)
        {

            if (MinionAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true)
            {
                print("From Combat State Manager Script= Enemy Turn");
                whosTurn += 1;
            }

        }
        if (MinionAnim.GetCurrentAnimatorStateInfo(0).IsName("WalkInCircle") == true)
        {
            print("From Combat State Manager Script= Player Turn");
            whosTurn = 0;
        }

        // call the queue again so the next player can fight
        ManageQueue();

    }
}
