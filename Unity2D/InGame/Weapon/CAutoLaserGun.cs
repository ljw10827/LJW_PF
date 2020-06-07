using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoLaserGun : CPenetrateWeapon
{
	public override void Start()
	{
		base.Start();
		fAtkSpeed = 0.10f;
		fCurrentAtkSpeed = fAtkSpeed;
		Mathf.Clamp(fCurrentAtkSpeed, 0, fAtkSpeed);
		fKnockback = 50f;
	}

	public override void Attack()
	{
		base.Attack();
	}

	public override void Shot()
	{
		base.Shot();
		var bullet = CRangedObjectManager.Instance.GetRangedObject("LaserInVisible");
		bullet.transform.position = this.gunAttackPivot.position;
		bullet.transform.localScale = this.GetDirection() * bullet.transform.localScale;
		bullet.GetComponent<CLaser>().fDamage = fAtk;
		bullet.GetComponent<CLaser>().SetLaserStart(this.gunAttackPivot.position);
		bullet.GetComponent<CLaser>().rigidbody.AddForce(this.GetDirection() * bullet.transform.right * fBulletSpeed);
	}
	
	protected override void SetDamage()
	{
		fAtk = 3 * this.fBonusDamage;
	}
}
