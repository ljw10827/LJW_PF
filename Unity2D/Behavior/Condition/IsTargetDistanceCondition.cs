using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetDistanceCondition : BTNode
{
	private IBasicAI myAI;
	private INPCAI myNPCAI;
	private float fDistance;
	
	public IsTargetDistanceCondition(IBasicAI AI, float fRange)
	{
		myAI = AI;
		fDistance = fRange;
	}

	public override BTState Evaluate()
	{
        if (Vector3.Distance(myAI.GetTransform().position, myAI.GetTargetPosition()) > fDistance)
        //if (Vector3.Distance(myAI.GetTransform().position, CPlayer.Instance.transform.position) > fDistance)
        {
            return BTState.SUCCESS;
		}

		return BTState.FAILURE;
	}

}
