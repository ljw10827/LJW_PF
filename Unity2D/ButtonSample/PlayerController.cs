using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player클래스 생성.
    public bool isAttack = false;
    public bool isInteract = false;
    public CButton oButtons;

    public void Awake()
    {
        oButtons = Function.FindComponent<CButton>("Buttons");
    }

    public void Attack()
    {
        if (!oButtons.isChangingImage)
        {
            isAttack = true;
            Debug.Log("isAttack!");
        }

        else if (oButtons.isChangingImage && !isAttack)
        {
            isInteract = true;
        }
    }

    public void AttackEnd()
    {
        isAttack = false;
        isInteract = false;
    }
}
