using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private Sprite npcImage;
    private bool b = false;
    private bool playerInteracting = false;
    private void Update()
    {
        if (playerInteracting && Input.GetMouseButtonDown(1) || playerInteracting && Input.GetMouseButtonDown(0))
        {
            ShowNpcHud(false);
            b = false;
            playerInteracting = false;
        }
    }
    private void OnMouseDown()
    {
        if (Vector2.Distance(GameManager.player.transform.position, gameObject.transform.position) < 2.4f)
        {
            if (!b)
            {
                ShowNpcHud(true);
                b = true;
                StartCoroutine(DelayInteract());
            }
            else
            {
                ShowNpcHud(false);
                b= false;
                playerInteracting= false;
            }
            print("Interacted");
        }
    }
    private IEnumerator DelayInteract()
    {
        yield return new WaitForSeconds(0.1f); ;
        playerInteracting = true;
    }
    public void ShowNpcHud(bool show)
    {
        if (show)
        {
            GameManager.npcText.text = text;
            GameManager.ShowNpcHud(true);
            GameManager.npcImage = npcImage;
            GameManager.canWalk = false;
        }
        else
        {
            GameManager.ShowNpcHud(false);
            GameManager.canWalk = true;
        }
    }
}
