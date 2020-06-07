using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoTestGun : CAutoWeapon
{
	public override void Start()
	{
		base.Start();
		fAtkSpeed = 0.2f;
		fCurrentAtkSpeed = fAtkSpeed;
		Mathf.Clamp(fCurrentAtkSpeed, 0, fAtkSpeed);
		fKnockback = 50f;
        fBulletSpeed = 20f;

	}

	public override void Attack()
	{
		base.Attack();
	}

	public override void Shot()
	{
		base.Shot();
		if (bIsShotAble)
		{ 
			var bullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
			bullet.transform.position = this.gunAttackPivot.position;
			bullet.transform.localScale = new Vector2(this.GetDirection(), 1);
			bullet.GetComponent<CBullet>().fDamage = fAtk;
			bullet.GetComponent<CBullet>().fDistance = this.fbulletDistance;
			bullet.GetComponent<CBullet>().SetStartPos();
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(fBulletSpeed * this.GetDirection(), 0f);
			CEffectManager.Instance.GetEffect("Fire", gunAttackPivot.position);
		}
	}

    protected override void SetDamage()
    {
        fAtk = 10 * this.fBonusDamage;
    }
}
