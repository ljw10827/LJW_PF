using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerHealth : CLivingEntity
{
    private CMovement movement;
    private CShooter shooter;
    public CHeartUI heartUI;
    public Animator animator;

    public bool isImmotal;


    public override void Awake()
    {
        base.Awake();
        animator = this.GetComponent<Animator>();
        this.fCurrentHealth = this.fStartHealth;
        movement = this.GetComponent<CMovement>();
        shooter = this.GetComponent<CShooter>();

        heartUI = GameObject.Find("Heart_UI").GetComponent<CHeartUI>();
        heartUI.SetHeart((int)fCurrentHealth, (int)fMaxHealth, shield);
    }

    public override void RestoreHealth(float NewHealth)
    {
        if ((int)fCurrentHealth + (int)NewHealth <= (int)fMaxHealth)
        {
            heartUI.AddHeart((int)NewHealth);
        }
        base.RestoreHealth(NewHealth);
    }

    public void AddShield(int num = 2)
    {
        shield+=num;
        heartUI.AddShield(num);
    }

    public override void OnDamage(float damage, Vector3 hitPos)
    {
        if (!movement.bIsDash)
        {
            base.OnDamage(damage, hitPos);
            heartUI.SubtractHeart((int)damage);
        }
    }

    public override void Death()
    {
        base.Death();
        animator.SetBool("isDeath", true);
        movement.rigidbody.velocity = new Vector2(0f, 0f);
        movement.rigidbody.isKinematic = true;
        if (this.IsDead)
        {
            movement.enabled = false;
            shooter.enabled = false;
        }
    }

    public void EndGame()
    {
        Function.StopGame();
    }

    public void AddMaxHealth(int num = 2)
    {
        fMaxHealth += num;
        heartUI.SetHeart((int)fCurrentHealth, (int)fMaxHealth, shield);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
