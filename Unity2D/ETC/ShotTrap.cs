using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrap : MonoBehaviour
{
    public float fBulletSpeed;
    public float fShotDelay;

    private float timeCount;

    void Start()
    {
        timeCount = Time.time;
    }

    void Update()
    {
        if(Time.time > timeCount + fShotDelay)
        {
            timeCount = Time.time;
            Shot();
        }
    }
    
    void Shot()
    {
        var firstbullet = CRangedObjectManager.Instance.GetRangedObject("Enemy");
        firstbullet.transform.position = this.transform.position;


        firstbullet.GetComponent<Rigidbody2D>().velocity = transform.right * fBulletSpeed;
    }
}
