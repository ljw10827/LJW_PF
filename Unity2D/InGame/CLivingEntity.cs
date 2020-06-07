using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CLivingEntity : MonoBehaviour, IDamageable
{
    public float fCurrentHealth;
    public float fStartHealth;
    public float fMaxHealth;
    public float fDef;
    public event Action onDeath;
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
    public int shield = 0;
    public float flashTime = 0.2f;

    private Shader flashShader;
    private Shader originShader;
    private SpriteRenderer spriteRenderer;

    public virtual void Awake()
    {
        this.flashShader = Shader.Find("GUI/Text Shader");
        this.originShader = Shader.Find("Sprites/Default");
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public virtual void OnDamage(float damage, Vector3 hitPos)
    {
        if (shield > 0) shield--;
        else
        {
            fCurrentHealth -= damage;
        }
        //fCurrentHealth -= damage;

        IsDamaged = true;
        StartCoroutine(FlashSprite());
        if (fCurrentHealth <= 0 && !IsDead)
        {
            Death();
        }
    }

    public virtual void RestoreHealth(float fNewHealth)
    {
        if (IsDead)
        {
            return;
        }
        fCurrentHealth = fCurrentHealth + fNewHealth >= fMaxHealth ? fMaxHealth : fCurrentHealth + fNewHealth;
    }

    public virtual void Death()
    {
        if (onDeath != null)
        {
            onDeath();
        }

        IsDead = true;
    }

    IEnumerator FlashSprite()
    {
        this.spriteRenderer.material.shader = this.flashShader;
        this.spriteRenderer.material.color = Color.red;

        yield return new WaitForSeconds(flashTime);
        this.spriteRenderer.material.shader = this.originShader;
        this.spriteRenderer.material.color = Color.white;
        IsDamaged = false;

        yield break;
    }
}
