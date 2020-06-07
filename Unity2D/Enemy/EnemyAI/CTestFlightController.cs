using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFlightController : CRangedEnemyController
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
        this.Shot();
    }

    void Shot()
    {
        float fRotationAngle = 360 / nMaxBullet;
        var firstbullet = CRangedObjectManager.Instance.GetRangedObject("TestAutoGun");
        firstbullet.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMY), LayerMask.NameToLayer(KDefine.LAYER_ENEMYBULLET));
        Vector2 dir = (this.enemyAI.GetTargetPosition() - firstbullet.transform.position).normalized;
        float fAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firstbullet.transform.rotation = Quaternion.AngleAxis(fAngle, Vector3.forward);
        firstbullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * fBulletSpeed * 5;
    }
}
