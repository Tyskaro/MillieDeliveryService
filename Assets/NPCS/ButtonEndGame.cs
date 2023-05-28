using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonEndGame : MonoBehaviour
{
    public NPC npcToLoop;
    public PlayerInteractSystem system;
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DontRestart()
    {
        gameObject.SetActive(false);
        system.interactable = npcToLoop.gameObject;
    }
}
