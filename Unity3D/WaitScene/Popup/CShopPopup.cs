﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShopPopup : CComponent
{
	public GameObject m_oOriginNotice = null;

	public override void Awake()
	{
		base.Awake();
	}


	public void OnTouchShopFrame(GameObject a_oSender)
	{
		var oParentName = a_oSender.name;

		var oNotice = Function.CreateCopiedGameObject("Notice", m_oOriginNotice, this.gameObject);
		var oNoticePopup = oNotice.GetComponentInChildren<CNoticePopup>();

		oNoticePopup.m_oItemName = oParentName;

		CSoundManager.Instance.PlayEffectSound("Sounds/Effect/ClickObject");

	}

	public void OnTouchBackButton(Button a_oSender)
	{
		if (this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(false);
			CSoundManager.Instance.PlayEffectSound("Sounds/Effect/ClickObject");
		}
	}


	public void Purchase(string a_oItemName)
	{
		this.PurchaseItem(a_oItemName);
	}


	private void PurchaseItem(string a_oItemName)
	{
		var oItemList = CItemStorage.Instance.GetItemInfoList();
		var oCurrentSlot = oItemList[0].m_nSlot;


		for (int i = 0; i < oItemList.Count; ++i)
		{
			oCurrentSlot = oItemList[i].m_nSlot > oCurrentSlot ? oItemList[i].m_nSlot : oCurrentSlot; 
		}


		for (int i = 0; i < oItemList.Count; ++i)
		{
			if (oItemList[i].m_oName == a_oItemName)
			{
				var stItemInfo = new CItemStorage.STItemInfo();

				stItemInfo.m_nID = oItemList[i].m_nID;
				stItemInfo.m_oName = oItemList[i].m_oName;
				stItemInfo.m_nAmount = oItemList[i].m_nAmount + 1;
				
				if (oItemList[i].m_nSlot == 0)
				{
					stItemInfo.m_nSlot = oCurrentSlot + 1;
					
				}

				else
				{
					stItemInfo.m_nSlot = oItemList[i].m_nSlot;
				}

				oItemList[i] = stItemInfo;
				break;
			}
		}

		CItemStorage.Instance.SaveItemList();
		CPlayerStorage.Instance.MoneyMinus(500);
		CSceneManager.CurrentSceneManager.SendMessage("SettingText");
	}

}
