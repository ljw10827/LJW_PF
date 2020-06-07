using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestRandomMoveFlightController : CRangedEnemyController
{
    public int nMaxBullet = 12;
    private IRandomMoveAI randomAI;
    private Vector3 currentDir;
    public override void Awake()
    {
        base.Awake();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMY), LayerMask.NameToLayer(KDefine.LAYER_ENEMYBULLET));
        fBulletSpeed = 1.5f;
        randomAI = enemyObject.GetComponent<IRandomMoveAI>();
        currentDir = Vector3.zero;
    }

    public void Update()
    {
        if (randomAI.IsMoving)
        {
            this.MoveForwardObject(currentDir);
        }
    }

    public override void TurnObject(float fXDir)
    {
        base.TurnObject(fXDir);
    }

    public override void MoveForwardObject(Vector3 moveDirection)
    {
        base.MoveForwardObject(moveDirection);
        if (currentDir != moveDirection)
        {
            currentDir = moveDirection;
        }
    }

    public override void AttackObject(int nDiceValue)
    {
        base.AttackObject(nDiceValue);
        this.Shot();
    }

    void Shot()
    {
        float fRotationAngle = 360 / nMaxBullet;
        var firstbullet = CRangedObjectManager.Instance.GetRangedObject("Enemy");
        firstbullet.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
        
        Vector2 dir = (this.enemyAI.GetTargetPosition() - firstbullet.transform.position).normalized;
        float fAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firstbullet.transform.rotation = Quaternion.AngleAxis(fAngle, Vector3.forward);
        firstbullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * fBulletSpeed * 5;
    }
}
