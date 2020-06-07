using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetTask : BTNode
{
	IBasicAI myAI;
	event ControllEventFloat turnEvent;

	public FindTargetTask(IBasicAI AI, ControllEventFloat eventFloat)
	{
		myAI = AI;
		turnEvent = eventFloat;
	}

	public override BTState Evaluate()
	{
		if (myAI.Target == null)
		{
			GameObject target = GameObject.Find("Player");
			myAI.Target = target;
		}

		if (myAI.Target != null)
		{
			float fXdir = myAI.Target.transform.position.x - myAI.GetTransform().position.x;
			if (turnEvent != null && !myAI.GetIsAttack())
			{
				turnEvent(fXdir);
			}
		}
		return BTState.SUCCESS;
	}
}
