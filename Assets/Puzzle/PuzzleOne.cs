using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleOne : MonoBehaviour
{
    [SerializeField] private Image[] puzzlePieces;
    [SerializeField] private Image test;
    [SerializeField] private AudioClip[] testSound;
    [SerializeField] private AudioClip wrongSound;
    public PuzzleOneButtons[] buttons;
    private int[] puzzleOrder = {0, 1, 2, 1, 1, 0, 1};
    private int currentPuzzle = 0;
    [SerializeField] private Sprite selectColor;
    [SerializeField] private PuzzleOneButtons[] normalColor;
    [SerializeField] private Sprite wrongColor;
    public GameObject cadeado;
    public int correctStreak = 0;
    public bool canClick;
    private bool started;
    public WaterCrystal_NPC npcFinal;

    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
       // gameManager.npcImageSerialize
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        buttons[0].buttonNumber = 0;
        buttons[0].puzzleReference = this;
        buttons[1].buttonNumber = 1;
        buttons[1].puzzleReference = this;
        buttons[2].buttonNumber = 2;
        buttons[2].puzzleReference = this;
        cadeado.SetActive(false);
    }
    public void PuzzleStart()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(CreatePuzzle());
        }
    }
    public IEnumerator CreatePuzzle()
    {
        correctStreak = 0;
        cadeado.SetActive(true);
        canClick = false;
        currentPuzzle = 0;
        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(ShowPuzzle());
    }
    private void ChangeColor(Sprite i, Image imagem)
    {
        imagem.sprite = i;
    }
    private IEnumerator ShowPuzzle()
    {
        if (currentPuzzle < puzzleOrder.Length)
        {
            ChangeColor(selectColor, puzzlePieces[puzzleOrder[currentPuzzle]]);
            GameManager.audioPlayer.PlayOneShot(testSound[puzzleOrder[currentPuzzle]]);
            print(puzzleOrder[currentPuzzle]);
            yield return new WaitForSeconds(0.5f);
            ChangeColor(normalColor[puzzleOrder[currentPuzzle]].NormalColor(), puzzlePieces[puzzleOrder[currentPuzzle]]);
            yield return new WaitForSeconds(0.5f);
            currentPuzzle++;
            StartCoroutine(ShowPuzzle());
        }
        else
        {
            print("terminou");
            canClick = true;
            currentPuzzle = 0;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator SelectButton(int i)
    {
        canClick = false;
        if (correctStreak < puzzleOrder.Length)
        {

            print("Da pra clicar certo");
            if(i == puzzleOrder[correctStreak])
            {
                print("Acertou");
                ChangeColor(selectColor, puzzlePieces[i]);
                GameManager.audioPlayer.PlayOneShot(testSound[i]);
                yield return new WaitForSeconds(0.3f);
                ChangeColor(normalColor[puzzleOrder[currentPuzzle]].NormalColor(), puzzlePieces[i]);
                correctStreak++;
                canClick = true;
                if ((correctStreak >= puzzleOrder.Length))
                {
                    print("Venceu");
                    canClick = false;
                    cadeado.SetActive(false);
                    npcFinal.SetCanInteract(true);
                    //SceneManager.LoadScene("SampleScene");
                }
            }
            else
            {
                ChangeColor(wrongColor, puzzlePieces[i]);
                GameManager.audioPlayer.PlayOneShot(testSound[i]);
                yield return new WaitForSeconds(0.5f);
                ChangeColor(normalColor[puzzleOrder[currentPuzzle]].NormalColor(), puzzlePieces[i]);
                GameManager.audioPlayer.PlayOneShot(wrongSound);
                correctStreak = 0;
                canClick = false;
                yield return new WaitForSeconds(1f);
                StartCoroutine(ShowPuzzle());
            }
        }
        else
        {
            print("Venceu");
            canClick = false;
        }
        yield return new WaitForSeconds(0.2f);
    }

}
