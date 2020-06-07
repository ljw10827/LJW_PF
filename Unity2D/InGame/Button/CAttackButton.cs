using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CAttackButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    public bool IsAttack { get; set; }
    public bool IsInteract { get; set; }
    public Sprite attackSprite;
    public Sprite interactSprite;
    public Image currentImage;

    public void Awake()
    {
        IsAttack = false;
        currentImage = this.GetComponent<Image>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //if (!IsAttack && !IsInteractImage())
        //{
        //    IsAttack = true;
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!IsAttack && !IsInteractImage())
        {
            IsAttack = true;
        }

        else if (!IsAttack && IsInteractImage())
        {
            Debug.Log("Sadasdadsqweasdzxcasdqwe");
            IsInteract = true;
            StartCoroutine(this.InteractEnd());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsAttack)
        {
            IsAttack = false;
        }

        if (IsInteract)
        {
            IsInteract = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsAttack)
        {
            IsAttack = false;
        }

        if (IsInteract)
        {
            IsInteract = false;
        }
    }

    public void ChangeInteractImage()
    {
        currentImage.sprite = interactSprite;
    }

    public void ChangeAttackImage()
    {
        currentImage.sprite = this.attackSprite;
    }
    
    public bool IsInteractImage()
    {
        return currentImage.sprite == interactSprite ? true : false;
    }

    private IEnumerator InteractEnd()
    {
        yield return new WaitForEndOfFrame();
        IsInteract = false;
    }

}
