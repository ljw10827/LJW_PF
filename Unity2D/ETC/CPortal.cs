using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPortal : MonoBehaviour
{
	private ChapterScene chapterManager;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(KDefine.TAG_PLAYER))
		{
			Debug.Log("포탈");
			if (this.chapterManager != null)
			{
				chapterManager.MoveStage();
			}
		}
	}

	public void SetChapterScene(ChapterScene chapterScene)
	{
		this.chapterManager = chapterScene;
	}
}
