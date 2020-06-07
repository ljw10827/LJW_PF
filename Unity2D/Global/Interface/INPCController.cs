using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NPCEventControl(bool bIsVisible);
public delegate void NPCEventControlList(List<string> plist);
public delegate void NPCEventControlString(string oMessage);

public interface INPCController
{
	event NPCEventControl showInteractEvent;
	event NPCEventControlList showMessageEvent;
	event NPCEventControlString showMessageStringEvent;
}
