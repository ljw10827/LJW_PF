using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CEquip : MonoBehaviour
{
	public Transform _transform;
	public Text oText;
	public const string oTextString = "장착중";
	public const string oEmptyString = "";
	public bool bIsUse;
	public GameObject copyObject;
	

	public virtual void Start()
	{
		_transform = this.gameObject.GetComponent<Transform>();
		oText = this.GetComponentInChildren<Text>();
	}

	public abstract void ClickItem();

	public abstract void CreateCopy(string objectName, Vector3 position);

	public abstract void DestroyObject();
		

}
