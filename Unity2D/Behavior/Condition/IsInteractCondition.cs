using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInteractCondition : BTNode
{
	INPCAI myAI;

	public IsInteractCondition(INPCAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
		//if CPlayer.instance.bIsInteract == true  => success 아니면 failure

		return BTState.SUCCESS;
	}


}
