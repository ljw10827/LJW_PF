using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEquipment : MonoBehaviour
{
    public CEquip selectWeapon;
    public CEquip selectAromor;
    private Dictionary<string, Transform> equipTransformDict;

    void Awake()
    {
        equipTransformDict = new Dictionary<string, Transform>();
        equipTransformDict.Add("Weapon", this.transform.Find("BaseFrame").Find("Weapon"));
        equipTransformDict.Add("Armor", this.transform.Find("BaseFrame").Find("Armor"));
    }

    public void SelectWeapon(CEquip item)
    {
        if (selectWeapon != null && !item.bIsUse)
        {
            selectWeapon.ClickItem();
            selectWeapon.DestroyObject();
        }

        item.ClickItem();

        if (item.bIsUse)
        {
            selectWeapon = item;
            item.CreateCopy("WeaponCopy", equipTransformDict["Weapon"].position);
        }

        else
        {
            selectWeapon = null;
            item.DestroyObject();
        }
    }


    void OnBecameInvisible()
    {
        Debug.Log("화면밖이지");
    }

    void OnBecameVisible()
    {
        Debug.Log("화면안이지");
    }

}
