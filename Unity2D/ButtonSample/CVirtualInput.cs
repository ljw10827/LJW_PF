using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVirtualInput
{
    private Dictionary<string, CMobileInput.CVirtualAxis> axisDict = new Dictionary<string, CMobileInput.CVirtualAxis>();

    public CMobileInput.CVirtualAxis FindAxisForKey(string name)
    {
        if (!axisDict.ContainsKey(name))
        {
            var virtualAxis = new CMobileInput.CVirtualAxis(name);
            axisDict.Add(name, virtualAxis);
        }

        return axisDict[name];
    }

    public float GetAxis(string name)
    {
        return axisDict[name].GetAxis();
    }
}
