using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCave : MonoBehaviour
{
    public static int correctAnswer;
    public GameObject obstacleSerialize;
    public static GameObject obstacle;
    public void Start()
    {
        obstacle = obstacleSerialize;
    }
    public static void Correct()
    {
        correctAnswer++;
        Debug.Log("Acertou");
        if (correctAnswer == 3)
        {
            //Abrir caminho pra caverna
            obstacle.SetActive(false);
            
        }
    }
}
