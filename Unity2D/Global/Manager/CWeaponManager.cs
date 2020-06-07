using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CWeaponManager : MonoBehaviour
{
    private static CWeaponManager instance;
    public static CWeaponManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(CWeaponManager).ToString());
                obj.AddComponent<CWeaponManager>();
                instance = obj.GetComponent<CWeaponManager>();
            }

            return instance;
        }
    }
    public int nWeaponMaxCount = 3;
    Text remainBulletText;
    static List<CWeapon> weaponList;
    CWeapon currentWeapon;
    Transform weaponParent;


    public void SetBulletText(string bulletStr)
    {
        if (remainBulletText == null)
        {
            remainBulletText = GameObject.Find("RemainBullet").GetComponent<Text>();
        }

        if (bulletStr.Length != 0)
        {
            remainBulletText.text = bulletStr;
        }
    }

    public void SetCurrentWeapon(CWeapon weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = weapon;
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.MadeBulletString();
        currentWeapon.InteractEndWeapon();
        weaponParent.GetComponent<CShooter>().SetCurrentWeapon(currentWeapon);
    }

    public CWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public void AddWeapon(CWeapon weapon)
    {
        var AddWeapon = GameObject.Instantiate(weapon, weaponParent);
        AddWeapon.transform.localPosition = currentWeapon.transform.localPosition;
        CWeapon createWeapon;
        createWeapon = AddWeapon.GetComponent<CWeapon>();
        //string baseFilePath = "Prefabs/RemovePrefab/";
        if (this.IsFullInventory())
        {
            var throwWeapon = GameObject.Instantiate(currentWeapon);
            throwWeapon.transform.position = Vector3.zero;
            throwWeapon.OnEnter();
            weaponList.RemoveAt(currentWeapon.IndexNumber);
            createWeapon.IndexNumber = currentWeapon.IndexNumber;
            weaponList.Insert(createWeapon.IndexNumber, createWeapon);
            Destroy(currentWeapon.gameObject);
            throwWeapon.InteractStartWeapon();
        }

        else
        {
            //var AddWeapon = GameObject.Instantiate(CResourceManager.Instance.GetObjectForKey(baseFilePath + weapon.gameObject.name), weaponParent);
            createWeapon.IndexNumber = weaponList.Count;
            weaponList.Add(createWeapon);
        }
            createWeapon.OnEnter();
            this.SetCurrentWeapon(createWeapon);
    }

    public bool IsFullInventory()
    {
        if (weaponList.Count >= nWeaponMaxCount)
        {
            return true;
        }
        return false;
    }

    public void ChangeWeapon()
    {
        int nIndex = 0;
        nIndex = currentWeapon.IndexNumber >= 2 ? 0 : currentWeapon.IndexNumber + 1;
        this.SetCurrentWeapon(weaponList[nIndex]);
    }

    public static CWeaponManager Create()
    {
        weaponList = new List<CWeapon>();
        return instance;
    }


    public void SetParent(Transform parent)
    {
        this.weaponParent = parent;
    }
}
