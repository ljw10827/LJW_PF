using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CMobileInput
{
	private static CVirtualInput virtualInput;
	static CMobileInput()
	{
		virtualInput = new CVirtualInput();
	}
	public class CVirtualAxis
	{
		string axisName;
		float fValue;
		public bool bIsTouch;

		public CVirtualAxis(string name)
		{
			axisName = name;
			bIsTouch = false;
			fValue = 0;
		}
		public float GetAxis() { return fValue; }
		public void UpdateValue(float value) { fValue = value; }
	}

	public static CVirtualAxis FindAxis(string axisName)
	{
		return virtualInput.FindAxisForKey(axisName);
	}

	public static float GetAxis(string axisName)
	{
		return GetAxisInVirtualInput(axisName);
	}

	private static float GetAxisInVirtualInput(string name)
	{
		return virtualInput.GetAxis(name);
	}
}
