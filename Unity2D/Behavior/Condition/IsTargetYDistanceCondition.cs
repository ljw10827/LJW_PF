using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetYDistanceCondition : BTNode
{
	IBasicAI myAI;
	float fDistance;
	public IsTargetYDistanceCondition(IBasicAI AI, float fRange)
	{
		myAI = AI;
		fDistance = fRange;
	}

	public override BTState Evaluate()
	{
		if (Mathf.Abs(myAI.GetTransform().position.y - myAI.GetTargetPosition().y) < fDistance)
		{
			return BTState.FAILURE;
		}

		return BTState.SUCCESS;
	}
}
