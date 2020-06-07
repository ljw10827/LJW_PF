using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFixController : CRangedEnemyController
{
    public int nMaxBullet = 12;
    public override void Awake()
    {
        base.Awake();
        fBulletSpeed = 3f;
        
    }

    public override void TurnObject(float fXDir)
    {
        base.TurnObject(fXDir);
    }

    public override void MoveForwardObject(Vector3 moveDirection)
    {
        base.MoveForwardObject(moveDirection);
    }

    public override void AttackObject(int nDiceValue)
    {
        base.AttackObject(nDiceValue);
        Debug.Log("ATTack");
        StartCoroutine(this.ShotVer1());
    }



    IEnumerator ShotVer1()
    {
        float fRotationAngle = 360 / nMaxBullet;
        var firstbullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
        firstbullet.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
        Vector2 dir = (this.enemyAI.GetTargetPosition() - firstbullet.transform.position).normalized;
        float fAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firstbullet.transform.rotation = Quaternion.AngleAxis(fAngle, Vector3.forward);
        firstbullet.GetComponent<Rigidbody2D>().velocity =  dir.normalized * fBulletSpeed * 5;
        yield return new WaitForSeconds(0.5f);
        var pos = firstbullet.transform.position;
        firstbullet.SetActive(false);
        for (int i = 1; i <= nMaxBullet; i++)
        {
            var bullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
            bullet.transform.position = pos;
            bullet.transform.localRotation = Quaternion.Euler(0, 0, 0 + fRotationAngle * i);
            bullet.transform.localScale = this.GetDirectionToInt() * bullet.transform.localScale;
            bullet.GetComponent<CBullet>().fDamage = fAtk;
            bullet.GetComponent<Rigidbody2D>().velocity = (this.GetDirectionToInt() * bullet.transform.right * fBulletSpeed);
        }
        yield break;
    }
}
