using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShieldItem : MonoBehaviour, IItem
{
    CHeartUI heartUI;
    void Start()
    {
        heartUI = GameObject.Find("Heart_UI").GetComponent<CHeartUI>();
    }

    public void Use()
    {
        heartUI.AddShield();
    }
}
