using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIntroScene : CSceneManager
{
	public GameObject _oSettingPopup = null;
	public GameObject[] backgroundList;
	public override void Awake()
	{
		base.Awake();
		_oSettingPopup.SetActive(false);
	}

	public void ChangeWaitScene()
	{
		Initiate.Fade("PlazaScene", Color.black, 0.5f);
	}

	public void OnClickSetting()
	{
		_oSettingPopup.SetActive(true);
		for (int i = 0; i < backgroundList.Length; i++)
		{
			backgroundList[i].SetActive(false);
		}
	}

	public void OnPopupExit()
	{
		_oSettingPopup.SetActive(false);
		for (int i = 0; i < backgroundList.Length; i++)
		{
			backgroundList[i].SetActive(true);
		}
	}

}
