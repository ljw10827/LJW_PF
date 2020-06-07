using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsNPCTargetDistanceCondition : BTNode
{
	INPCAI myAI;
	NPCEventControl showInteractImageEvent;
	float fDistance;

	public IsNPCTargetDistanceCondition(INPCAI AI, NPCEventControl showEvent, float fRange)
	{
		myAI = AI;
		fDistance = fRange;
		this.showInteractImageEvent = showEvent;
	}

	public override BTState Evaluate()
	{
		if (myAI.GetDistance() > fDistance)
		{
			showInteractImageEvent(false);
			return BTState.FAILURE;
		}


		if (this.showInteractImageEvent != null)
		{
			showInteractImageEvent(true);
		}
		
		return BTState.SUCCESS;
	}
}
