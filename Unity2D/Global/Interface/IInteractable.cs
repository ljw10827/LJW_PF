using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	bool IsInteract { get; set; }
	void ShowInteractSprite();
	void ShowoffInteractSprite();
}