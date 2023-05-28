using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public bool correctOption;
    public Mushroom_1 npcMushroom;
    public NPC correctDialogNpc;
    public NPC wrongDialogNPC;
    public PlayerInteractSystem interactSystem;
    public string button;
    public void ClickOption()
    {
        if (correctOption)
        {
            npcMushroom.loopDialog = false;
            interactSystem.interactable = correctDialogNpc.gameObject;
            interactSystem.options.SetActive(false);
            correctOption = false;
            correctDialogNpc.CreateDialog();
        }
        else
        {
            correctOption = false;
            npcMushroom.canBeTalked = true;
            interactSystem.interactable = wrongDialogNPC.gameObject;
            interactSystem.options.SetActive(false);
            wrongDialogNPC.CreateDialog();
        }
    }
    public void Update()
    {
        if (Input.GetAxis(button) > 0)
        {
            ClickOption();
        }
    }
}
