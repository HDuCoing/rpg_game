using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInputSystem : MonoBehaviour

{
    public GameObject Right_Hand;
    public bool canAttack = true;
    public float attackCoolDown = 1.0f;

    void update()
    {// if middle mouse button is clicked, animate
        Debug.Log("update");
        if (Input.GetKey(KeyCode.Mouse0))
        { Debug.Log("mouse 0");
            if (canAttack)
            {   
                handAttack();
                Debug.Log("trigger hand attack");
            }
        }
    }
    // triggers Rhand in blend tree and turns off attack
    public void handAttack()
    {
        Animator anim = Right_Hand.GetComponent<Animator>();
        canAttack = false;
        anim.SetTrigger("Rhand");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }
}
