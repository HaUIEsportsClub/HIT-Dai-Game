using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpell : MonoBehaviour
{
    public Button myButton;
    public List<Image> buttonImages;
    public Color gray = Color.gray;

    private bool canInteract;

    public void SetInteractable(bool interactable)
    {
        canInteract = interactable;
        myButton.interactable = canInteract;
        foreach (Image image in buttonImages)
        {
            var color = interactable ? Color.white : gray;
            color.a = 1f;
            image.color = color;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameData.coin >= 50)
        {
            SetInteractable(true);
        }
        else
        {
            SetInteractable(false);
        }
    }
}