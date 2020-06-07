using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSwordWeaponItem : CEquip
{
	public string oName;
	public int nAtk;

	public override void Start()
	{
		base.Start();
	}

	public override void ClickItem()
	{
		if (bIsUse)
		{
			bIsUse = false;
			oText.text = oEmptyString;
		}
		
		else
		{
			bIsUse = true;
			oText.text = oTextString;
		}
	}

	public override void CreateCopy(string objectName, Vector3 position)//string objectName, Vector3 position)
	{
		oText.text = oEmptyString;
		copyObject = Function.CreateCopiedGameObject(objectName, this.gameObject, this.transform.parent.gameObject);
		copyObject.transform.position = position;
		oText.text = oTextString;
	}

	public override void DestroyObject()
	{
		Destroy(this.copyObject);
		Debug.Log("파아괴에에에");
	}
}
