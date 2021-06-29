using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightScript : MonoBehaviour

{

    public Animator animator;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A)) // Keyboard variable in order to run Minion Fight Script while waiting for UI script
        {
            print("From FightScript: attacking");
            if (CombatStateManager.instance != null)
            CombatStateManager.instance.NextPlayersTurn();
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Heal");
        }
    }
}