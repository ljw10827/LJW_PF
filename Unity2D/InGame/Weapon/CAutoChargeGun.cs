﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoChargeGun : CChargeWeapon
{
    public override void Start()
    {
        base.Start();
        fKnockback = 50f;
        fBulletSpeed = 20f;
    }

    public override void Shot()
    {
        if (!bIsCharge)
        {
            return;
        }
        base.Shot();
        var bullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
        bullet.transform.position = this.gunAttackPivot.position;
        bullet.transform.localScale = new Vector2(this.GetDirection(), 1);
        bullet.GetComponent<CBullet>().fDamage = fAtk * this.fCurrenrtCharge;
        bullet.GetComponent<CBullet>().fDistance = this.fbulletDistance;
        bullet.GetComponent<CBullet>().SetStartPos();
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(fBulletSpeed * this.GetDirection(), 0f));
        CEffectManager.Instance.GetEffect("Fire", gunAttackPivot.position);
        bIsCharge = false;
    }


    protected override void SetDamage()
    {
        fAtk = 3 * this.fBonusDamage;
    }
}
