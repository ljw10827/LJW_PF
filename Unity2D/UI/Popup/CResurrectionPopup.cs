using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CResurrectionPopup : CBasePopup
{
	Text oText;
	public override void AppearPopup()
	{
		this.gameObject.SetActive(true);
		oText = GameObject.Find("CountingText").GetComponent<Text>();
		StartCoroutine(CountingNumber());
		Function.StopGame();

	}

	public override void DisAppearPopup()
	{
		this.gameObject.SetActive(false);
	}

	public void OnClickADButton()
	{
		this.DisAppearPopup();
		//플레이어 살리는 함수를 만들고 셋hp부분 없앰.
		//Player Fix CPlayer.Instance.SetHP(100);
		//Player Fix CPlayer.Instance.characterState = CCharacter.CharacterState.IDLE;
		Function.StartGame();
		//DO SOMETHING -> GO TO AD 
	}

	public void OnClickExitButton()
	{
		this.DisAppearPopup();
		Function.StartGame();
		Initiate.Fade("PlazaScene", Color.black, 0.5f);
		//DO SOMETHING -> GO TO WAIT SCENE
	}

	public IEnumerator CountingNumber()
	{
		int nCount = 5;
		while(nCount >= 0)
		{
			oText.text = nCount.ToString();
			yield return new WaitForSecondsRealtime(1.0f);
			nCount--;
		}

		this.DisAppearPopup();
		Function.StartGame();
		Initiate.Fade("PlazaScene", Color.black, 0.5f);

		Debug.Log("Game Over");
		//DO SOMETHING -> GO TO WAIT SCENE
	}
}
