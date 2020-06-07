using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestScene : CSceneManager
{
	public override void Awake()
	{
		base.Awake();
		CRangedObjectManager.Create();
	}

	public override void Update()
	{
		base.Update();
	}
}
