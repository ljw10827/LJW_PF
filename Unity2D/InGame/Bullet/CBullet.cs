using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CBullet : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public string bulletName;
    public float fDamage { get; set; }
    public float fDistance;
    protected bool bIsEnemyBullet;
    private Vector2 startPos;

    public virtual void Awake()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_PLAYERBULLET), LayerMask.NameToLayer(KDefine.LAYER_ENEMYBULLET), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_ENEMYBULLET), LayerMask.NameToLayer(KDefine.LAYER_ENEMYBULLET), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(KDefine.LAYER_PLAYERBULLET), LayerMask.NameToLayer(KDefine.LAYER_PLAYERBULLET), true);
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (this.gameObject.activeSelf && !bIsEnemyBullet)
        {
            if (Vector2.Distance(startPos, this.transform.position) >= fDistance)
            {
                CRangedObjectManager.Instance.PushRangedObject(bulletName, this.gameObject);
            }
        }
    }

    public void SetStartPos()
    {
        startPos = this.transform.position;
    }

}
