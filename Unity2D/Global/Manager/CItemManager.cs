using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CItemManager : MonoBehaviour
{
	private static CItemManager instance;
	public static CItemManager Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject obj = new GameObject(typeof(CItemManager).ToString());
				obj.AddComponent<CItemManager>();
				instance = obj.GetComponent<CItemManager>();
			}
			return instance;
		}
	}
	Dictionary<string, KeyValuePair<string, CObjectPool>> itemDict;
	StringBuilder keyString;

	void Awake()
	{
		itemDict = new Dictionary<string, KeyValuePair<string, CObjectPool>>();
		keyString = new StringBuilder();	
	}

	public GameObject GetObjectForKey(string objectName)
	{
		if (!itemDict.ContainsKey(objectName))
		{
			this.PushKeyValue(objectName);
		}

		var filePath = itemDict[objectName].Key;
		var pool = itemDict[objectName].Value;

		return pool.VisibleObject(filePath, this.transform);
	}

	public void PushObject(string objectName, GameObject gameObject)
	{
		gameObject.transform.localPosition = Vector3.zero;
		itemDict[objectName].Value.InVisbileObject(gameObject);
	}

	public void PushKeyValue(string objectName)
	{
		keyString.Clear();
		keyString.Append("Prefabs/");
		keyString.Append("Item/");
		keyString.Append(objectName);
		itemDict.Add(objectName, new KeyValuePair<string, CObjectPool>(keyString.ToString(), new CObjectPool()));
	}

	public CItemManager Create()
	{
		return Instance;
	}
	

}
