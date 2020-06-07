using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeartItem : MonoBehaviour, IItem
{
    CHeartUI heartUI;
    public int nAddHealthCount;
    void Start()
    {
        heartUI = GameObject.Find("Heart_UI").GetComponent<CHeartUI>();
    }

    public void Use()
    {
        heartUI.AddHeart();
    }
}
