using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReloadItem : MonoBehaviour, IItem
{
	public int nCount;
	
	public void Use()
	{
		CWeaponManager.Instance.GetCurrentWeapon().ReloadBullet(nCount);
	}
}
