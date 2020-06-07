using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossController : MonoBehaviour
{
    IController bossController;
    IBasicAI bossAI;
    public GameObject bossObject;
    public Animator animator;

    protected bool bIsFacingRight;
    float fSpeed = 3.0f;
    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMY), LayerMask.NameToLayer(KDefine.LAYER_PLAYER), true);
        if (!bossObject)
        {
            bossObject = this.gameObject;
        }

        if (bossObject)
        {
            bossController = bossObject.GetComponent<IController>();
            bossAI = bossObject.GetComponent<IBasicAI>();
            bossController.AtkEvent += this.AttackObject;
            bossController.MoveEvent += this.MoveForwardObject;
            bossController.RandomMoveEvent += this.MoveForwardObject;
            bossController.TurnEvent += this.TurnObject;

            animator = this.GetComponent<Animator>();
        }
    }

    public void TurnObject(float fXDir)
    {
        if ((fXDir < -0.5 && bossAI.FacingRight) || (fXDir > 0.5 && !bossAI.FacingRight))
        {
            bossAI.FacingRight = !bossAI.FacingRight;
            animator.SetBool("FacingRight", bossAI.FacingRight);
            bossObject.transform.localScale = new Vector3(bossObject.transform.localScale.x * -1f, 1f, 1f);
            //HP BAR DO SOMETHING THIS FLIP
        }
    }

    public void MoveForwardObject(Vector3 moveDirection)
    {
        //Animator SetFloat or trigger? move animation play  DO SOMETHING
        animator.SetFloat("Speed", fSpeed);
        this.transform.Translate(moveDirection * (this.fSpeed * Time.deltaTime));
    }

    public void MoveForwardObject()
    {
        animator.SetFloat("Speed", fSpeed);
        this.transform.Translate(GetDirection() * (this.fSpeed * Time.deltaTime));
    }

    public void AttackObject(int nDiceValue)
    {
        animator.SetFloat("Speed", 0.0f);
        animator.SetInteger("AttackState", nDiceValue);
        Debug.Log("여기야");
        switch (nDiceValue)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                Debug.Log("다이스 범위 초과!");
                break;
        }
    }

    public Vector3 GetDirection()
    {
        return bossAI.FacingRight ? Vector3.right : Vector3.left;
    }

}
