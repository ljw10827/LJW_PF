using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGunItem : MonoBehaviour
{
    CWeapon weapon;

    void Start()
    {
        this.weapon = this.GetComponent<CWeapon>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(KDefine.TAG_PLAYER))
        {
            collision.gameObject.GetComponent<CShooter>().SetSpareWeapon(weapon);
            collision.gameObject.GetComponent<CShooter>().playerInput.AttackButton.ChangeInteractImage();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(KDefine.TAG_PLAYER))
        {
            collision.gameObject.GetComponent<CShooter>().playerInput.AttackButton.ChangeAttackImage();
        }
    }
}
