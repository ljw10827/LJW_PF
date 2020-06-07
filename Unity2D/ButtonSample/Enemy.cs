using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CLivingEntity
{
    /*
    public ParticleSystem hitEffect;

    private Animator animator;
    private SpriteRenderer sRenderer;

    public float damage = 20f;
    public float timeBetAttack = 0.5f;
    private float lastAttackTime;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        hitEffect.Stop();
    }


    public void Setup(float newHealth, float newDamage, float newSpeed, Color skinColor)
    {
        startingHealth = newHealth;
        health = newHealth;
        damage = newDamage;
        // 패스파인더.스피드 추가 필요
        // 렌더러 외형 추가 필요

    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void OnDamage(float damage, Vector3 hitPos)
    {
        if(hitPos.x < transform.position.x)
        {
            hitEffect.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        }
        else
        {
            hitEffect.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 180));
        }


        if (hitEffect.gameObject.activeSelf)
        {
            
            hitEffect.Stop();
            hitEffect.Play();

        }
        else
        {
            hitEffect.gameObject.SetActive(true);
        }

        
        base.OnDamage(damage, hitPos);

        Debug.Log("HP: " + health);

    }

    public override void Die()
    {
        animator.SetTrigger("Die");
        
        base.Die();
    }

    private void Bye()
    {
       
        gameObject.SetActive(false);
    }

    */
}
