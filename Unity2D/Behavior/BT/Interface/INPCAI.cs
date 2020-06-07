using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCAI
{
	Transform GetMyTransform();
	float GetDistance();
	bool GetIsHidden();
	List<string> GetMessageList();
}
