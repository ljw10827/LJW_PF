using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//기본시간 랜덤으로 변수주고 +0.04씩 더해주며 생성하기. 코루틴으로
public class CAutoShotGun : CAutoWeapon
{
	public int nMaxBullet;
	private float fCreateTime = 0.05f;


	public override void Start()
	{
		base.Start();
		fAtkSpeed = 0.10f;
		fCurrentAtkSpeed = fAtkSpeed;
		Mathf.Clamp(fCurrentAtkSpeed, 0, fAtkSpeed);
		fKnockback = 50f;
        fBulletSpeed = 20f;
        fAtk = 3f;
        nMaxBullet = 12;
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
            StartCoroutine(CreateBullet());
        }
	}

	IEnumerator CreateBullet()
	{
        float fRotationAngle = 3f;

        //CreateTime도 변수로 만들어서 랜덤 해도됨
        for (int i = 0; i < nMaxBullet; i++)
		{
            float fRandomTime = fCreateTime / nMaxBullet;
            int nRandom = Random.Range(0, 11);
            var bullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
            //bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            bullet.transform.position = this.gunAttackPivot.position;
            bullet.transform.localRotation = Quaternion.Euler(0, 0, -15 + fRotationAngle * nRandom);
            bullet.transform.localScale = this.GetDirection() * bullet.transform.localScale;
            bullet.GetComponent<CBullet>().fDamage = fAtk;
            bullet.GetComponent<CBullet>().fDistance = this.fbulletDistance;
            bullet.GetComponent<CBullet>().SetStartPos();
            bullet.GetComponent<Rigidbody2D>().velocity = (this.GetDirection() * bullet.transform.right * fBulletSpeed);
            yield return new WaitForSeconds(fRandomTime);
			//fRandomTime += fCreateTime;
		}
	}

    protected override void SetDamage()
    {
        fAtk = 3;
    }
}
