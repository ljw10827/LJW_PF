using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CButton : MonoBehaviour
{
    public bool isChangingImage = false;

    private Button attackButton;
    private Sprite interactImage;
    private Sprite originImage;

    public void Start()
    {
        this.attackButton = Function.FindComponent<Button>("AttackButton");
        originImage = CResourceManager.Instance.GetSpriteForKey("Sprites/Sample/back01");
        interactImage = CResourceManager.Instance.GetSpriteForKey("Sprites/Sample/jrm2");
    }

    public void ChangeImage()
    {
        if (isChangingImage)
        {
            attackButton.image.sprite = interactImage;
        }

        else
        {
            attackButton.image.sprite = originImage;
        }
    }
}