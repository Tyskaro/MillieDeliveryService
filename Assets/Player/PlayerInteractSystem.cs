using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    public GameObject interactable;
    public GameObject options;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 12") || Input.GetKeyDown("1"))
        {
            if(interactable!= null)
            {
                if(interactable.TryGetComponent(out InteractableInterface interactableNpc))
                {
                    interactableNpc.Interact();
                    Debug.Log("Interagiu");
                }
                
            }
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactable = collision.gameObject;
            Debug.Log("Encontrou NPC");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == interactable)
        {
            interactable = null;
        }
    }
}
