using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReuse : MonoBehaviour
{
    GameObject player;
    CWeapon weapon;
    private void Start()
    {
        player = GameObject.Find("Player");
        weapon = this.GetComponent<CWeapon>();
    }
    void Update()
    {
        if(Vector2.Distance(player.transform.position, this.transform.position) <= 1 && this.transform.parent != player.transform)
        {
            //this.setparent;
            Destroy(this.gameObject);
            CWeaponManager.Instance.AddWeapon(weapon);
        }
    }
}
