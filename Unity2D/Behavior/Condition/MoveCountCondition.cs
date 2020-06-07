using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCountCondition : BTNode
{
	int nCurrentMoveCount;
	int nMaxCount;
	public MoveCountCondition(int nCount)
	{
		nMaxCount = nCount;
		nCurrentMoveCount = 0;
	}

	public override BTState Evaluate()
	{
		if (nCurrentMoveCount > nMaxCount)
		{
			nCurrentMoveCount = 0;
			return BTState.FAILURE;
		}
		nCurrentMoveCount++;
		return BTState.SUCCESS;
	}
}
