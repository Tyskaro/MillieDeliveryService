using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRegion : MonoBehaviour
{
    [SerializeField]private GameObject Objective;
    [SerializeField] private bool bTeleporter;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (bTeleporter && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TestingTeleport(true));
        }
    }
    public void Teleport()
    {
        GameManager.player.transform.position = Objective.transform.position;
        TeleportExtra();
    }
    public void TeleportFade()
    {
        StartCoroutine(TestingTeleport(true));
    }
    private IEnumerator TestingTeleport(bool start)
    {
        Debug.Log("Teste");
        if (start)
        {
            GameManager.self.Fade(0, 3f, false);
            GameManager.canWalk = false;
            GameManager.Player.StopAllMovement();
        }
        yield return 0;
        if (GameManager.fadeCanDo)
        {
            Teleport();
        }
        else
        {
            StartCoroutine(TestingTeleport(false));
        }
    }
    public virtual void TeleportExtra()
    {

    }
}
