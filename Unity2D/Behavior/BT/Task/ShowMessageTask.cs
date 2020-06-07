using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessageTask : BTNode
{
	INPCAI myAI;
	NPCEventControlString showMessageEvent;

	public ShowMessageTask(INPCAI AI, NPCEventControlString showEvent)
	{
		myAI = AI;
		this.showMessageEvent = showEvent;
	}

	public override BTState Evaluate()
	{
		showMessageEvent("NPC 메시지얌");
		return BTState.SUCCESS;
	}
}
