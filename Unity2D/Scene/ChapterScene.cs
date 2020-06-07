using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterScene : CSceneManager
{
	public List<CStage> stageList;
	public CPortal portal;
	private CStage currentStage;
	private int nCurrentIndex = 0;
	private int nMaxStage = 0;
	private CMovement player;

	public override void Awake()
	{
		base.Awake();
		currentStage = stageList[nCurrentIndex];
		player = FindObjectOfType<CMovement>();
		portal = this.transform.Find("Portal").GetComponent<CPortal>();
		portal.SetChapterScene(this);
		this.MoveStage();
		
	}

	public override void Update()
	{
		base.Update();
		Debug.Log(currentStage);
		Debug.Log(currentStage.bIsStageEnd);
		if (currentStage != null && currentStage.bIsStageEnd)
		{
			if (!portal.gameObject.activeSelf)
			{
				portal.transform.position = currentStage.nextDungeonEntrance;
				portal.gameObject.SetActive(true);
			}
		}
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
	}

	public void MoveStage()
	{
		portal.gameObject.SetActive(false);

		if (nMaxStage == 0)
		{
			currentStage.gameObject.SetActive(true);
			player.transform.position = currentStage.StartPosition;
			nMaxStage++;
		}
		
		else
		{
			stageList.RemoveAt(nCurrentIndex);
			nCurrentIndex = Random.Range(0, stageList.Count);
			nMaxStage++;
			currentStage = stageList[nCurrentIndex];
			currentStage.gameObject.SetActive(true);
			player.transform.position = currentStage.StartPosition;
		}
		//마지막 스테이지일때 챕터 이동 or 대기실 이동
	}

}
