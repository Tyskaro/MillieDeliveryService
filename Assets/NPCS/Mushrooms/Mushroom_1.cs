using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_1 : NPC
{
    [SerializeField] private GameObject optionsUi;
    [SerializeField] private OptionsScript[] options;
    [SerializeField] private int correctOption;
    public PlayerInteractSystem system;
    public bool canBeTalked = true;
    private void ShowOptions()
    {
        optionsUi.SetActive(true);
        options[correctOption].correctOption = true;
        system.options = optionsUi;
        canBeTalked = false;
    }
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        ShowOptions();
    }
    public override bool CanTalk()
    {
        return canBeTalked;
    }
}
