using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum EWeaponCategory
{
    E_AUTOGUN,
    E_PENETRATE,
    E_CHARGEGUN
};

public abstract class CWeapon : MonoBehaviour
{
    protected CMovement playerMovement;
    protected Rigidbody2D playerRigidbody;
    protected Transform gunAttackPivot;
    public StringBuilder remainBulletString;
    [SerializeField]
    protected int nCurrentBulletCount;
    [SerializeField]
    protected int nMaxBulletCount;
    protected int nQuality;
    protected float fAtk;
    protected float fDistance;
    protected float fKnockback;
    protected float fCurrentAtkSpeed;
    protected float fLastShotTime;
    protected bool bIsShotAble = true;
    protected BoxCollider2D interactCollider;
    [SerializeField]
    protected float fbulletDistance;
    public float fBulletSpeed;
    public float fAtkSpeed;
    public int IndexNumber { get; set; }

    public float fBonusDamage;
    protected EWeaponCategory weaponCategory;

    public virtual void Start()
    {
        if (gunAttackPivot == null)
        {
            OnEnter();
        }
    }

    public virtual void Shot()
    {
        if (nCurrentBulletCount <= 0)
        {
            bIsShotAble = false;
            return;
        }
        this.KnockBack();
        this.MinusBulletCount();
    }
    
    public void SetBonusDamage(float fDamage)
    {
        fBonusDamage = fDamage;
        this.SetDamage();
    }
    public abstract void Attack();
    protected abstract void SetDamage();
    protected void KnockBack()
    {
        playerRigidbody.AddForce(new Vector2(-this.GetDirection() * this.fKnockback, 0)); ;
    }
    protected int GetDirection()
    {
        return playerMovement.bIsFacingRight ? 1 : -1;
    }

    public EWeaponCategory GetWeaponCategory()
    {
        return weaponCategory;
    }

    public void MadeBulletString()
    {
        if (nMaxBulletCount == 123456789)
        {
            remainBulletString.Clear();
            return;
        }
        remainBulletString.Clear();
        remainBulletString.Append(nCurrentBulletCount.ToString());
        remainBulletString.Append("/");
        remainBulletString.Append(nMaxBulletCount.ToString());
        CWeaponManager.Instance.SetBulletText(remainBulletString.ToString());
    }

    public void MinusBulletCount()
    {
        this.nCurrentBulletCount--;

        if (remainBulletString.Length != 0)
        {
            this.MadeBulletString();
        }
    }

    public void ReloadBullet(int nCount)
    {
        nCurrentBulletCount +=  nCount;
    }

    public void OnEnter()
    {
        playerMovement = FindObjectOfType<CMovement>();
        gunAttackPivot = this.transform.Find("GunAttackPivot");
        playerRigidbody = playerMovement.GetComponent<Rigidbody2D>();
        interactCollider = this.GetComponent<BoxCollider2D>();
        weaponCategory = new EWeaponCategory();
        remainBulletString = new StringBuilder();
        Mathf.Clamp(nCurrentBulletCount, 0, nMaxBulletCount);
        SetDamage();
    }

    public void InteractEndWeapon()
    {
        this.interactCollider.enabled = false;
    }

    public void InteractStartWeapon()
    {
        this.interactCollider.enabled = true;
    }

    
}
