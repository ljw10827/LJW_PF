using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBaseEnemyController : CLivingEntity
{
    protected IController enemyController;
    protected IBasicAI enemyAI;
    public GameObject enemyObject;
    public Animator animator;
    public float fAtk;


    public float fSpeed;
    protected bool bIsDead;

    public override void Awake()
    {
        base.Awake();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMY), LayerMask.NameToLayer(KDefine.LAYER_PLAYER), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMY), LayerMask.NameToLayer(KDefine.LAYER_ENEMY), true);

        if (!enemyObject)
        {
            enemyObject = this.gameObject;
        }

        if (enemyObject)
        {
            enemyController = enemyObject.GetComponent<IController>();
            enemyAI = enemyObject.GetComponent<IBasicAI>();
            enemyAI.LivingEntity = this;
            enemyController.AtkEvent += this.AttackObject;
            enemyController.MoveEvent += this.MoveForwardObject;
            enemyController.TurnEvent += this.TurnObject;
            enemyController.RandomMoveEvent += this.MoveForwardObject;
            bIsDead = this.IsDead;
            enemyAI.FacingRight = false;
            animator = this.GetComponent<Animator>();
        }

        onDeath += Die;
    }

    void Die()
    {
        CEffectManager.Instance.GetEffect("DeathBoom_01", this.transform.position + new Vector3(0f, 0.4f, 0f));
        this.gameObject.SetActive(false);
    }

    public virtual void TurnObject(float fXDir)
    {
        if ((fXDir < -0.5 && enemyAI.FacingRight) || (fXDir > 0.5 && !enemyAI.FacingRight))
        {
            enemyAI.FacingRight = !enemyAI.FacingRight;
            animator.SetBool("FacingRight", enemyAI.FacingRight);
            enemyObject.transform.localScale = new Vector3(enemyObject.transform.localScale.x * -1f, 1f, 1f);
        }
    }
    public virtual void MoveForwardObject(Vector3 moveDirection)
    {
        animator.SetFloat("Speed", fSpeed);
        this.transform.Translate(moveDirection * (this.fSpeed * Time.deltaTime));
    }

    public virtual void MoveForwardObject()
    {
        animator.SetFloat("Speed", fSpeed);
        this.transform.Translate(GetDirection() * (this.fSpeed * Time.deltaTime));
    }

    public virtual void AttackObject(int nDiceValue)
    {
        animator.SetFloat("Speed", 0.0f);
        animator.SetInteger("AttackState", nDiceValue);

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
        return this.enemyAI.FacingRight ? Vector3.right : Vector3.left;
    }

    public int GetDirectionToInt()
    {
        return this.enemyAI.FacingRight ? 1 : -1;
    }

    public virtual void AttackTime() { }

    public virtual void AttackTimeEnd() { }

    public bool DeathCheck()
    {
        bIsDead = this.IsDead;
        return bIsDead;
    }
}

