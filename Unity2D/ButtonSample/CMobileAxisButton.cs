using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CMobileAxisButton : MonoBehaviour, IPointerExitHandler
{
    public string axisName;
    public float fMaxValue = 1f;
    public float fAddSpeed;
    public Image buttonImage;
    public bool bIsRight;
    private bool bIsMinus;
    private bool bIsTouch;
    CMobileInput.CVirtualAxis myAxis;

    // Start is called before the first frame update
    void Awake()
    {
        myAxis = CMobileInput.FindAxis("Horizontal");
        bIsMinus = fMaxValue < 0 ? true : false;
        buttonImage = this.GetComponent<Image>();
    }

    void Update()
    {
        if (myAxis.bIsTouch && bIsTouch)
        {
            myAxis.UpdateValue(Mathf.MoveTowards(myAxis.GetAxis(), fMaxValue, fAddSpeed * Time.deltaTime));
        }
        else if (!myAxis.bIsTouch && !bIsTouch)
        {
            myAxis.UpdateValue(Mathf.MoveTowards(myAxis.GetAxis(), 0, fAddSpeed * Time.deltaTime));
        }
    }



    public void OnPointerExit(PointerEventData pointerEventData)
    {
        myAxis.bIsTouch = false;
        bIsTouch = false;
        buttonImage.color = Color.white;
        Debug.Log("ssssdasa");
    }

}
