using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPrevPositionCondition : BTNode
{
	IBasicAI myAI;
	float fDistance;

	public CheckPrevPositionCondition(IBasicAI AI, float fRange)
	{
		myAI = AI;
		fDistance = fRange;
	}

	public override BTState Evaluate()
	{
		//Debug.Log("Prev : " + myAI.MyPrevPosition + " current : " + myAI.GetTransform().position + " 거리 : " + Vector2.Distance(myAI.MyPrevPosition, myAI.GetTransform().position));
		
		if (Vector2.Distance(myAI.MyPrevPosition, myAI.GetTransform().position) <= fDistance)
		{
			return BTState.SUCCESS;
		}

		return BTState.FAILURE;
	}
}
