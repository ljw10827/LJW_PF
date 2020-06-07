using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPausePopup : CBasePopup
{
	public override void AppearPopup()
	{
		this.gameObject.SetActive(true);
		//Manager Show Pause POpup
		Function.StopGame();
	}

	public override void DisAppearPopup()
	{
		this.gameObject.SetActive(false);
		//Manager Disappear Pause POpup
		Function.StartGame();
	}

	public void OnClickYesButton()
	{
		this.DisAppearPopup();
	}

	public void OnClickNoButton()
	{
		this.DisAppearPopup();
	}
}
