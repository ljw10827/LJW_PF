﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveTask : BTNode
{
	Vector3 currentDir;
	ControllEventVector3 randomMoveEvent;
	public RandomMoveTask(ControllEventVector3 moveEvent)
	{
		currentDir = Vector3.zero;
		randomMoveEvent = moveEvent;
	}

	public override BTState Evaluate()
	{
		if (randomMoveEvent != null)
		{
			int nX = Random.Range(0, 2);
			int nY = Random.Range(0, 2);

			nX = nX == 0 ? -1 : 1;
			nY = nY == 0 ? -1 : 1;

			if (currentDir.x == nX && currentDir.y == nY)
			{
				nX *= -1;
			}

			currentDir.x = nX;
			currentDir.y = nY;
			randomMoveEvent(currentDir);
			return BTState.SUCCESS;
		}

		return BTState.FAILURE;
	}
}
