using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator transition;
    public void Play()
    {
        StartCoroutine(LoadLevelAnim());
    }

    IEnumerator LoadLevelAnim()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
