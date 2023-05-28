using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI npcWidget;
    public static GameObject npcPanel;
    public static TextMeshProUGUI npcText;
    public static GameObject player;
   // public static Sprite npcImage;
    public static Image imageNpc;
    public static AudioSource audioPlayer;
    [SerializeField] private Image imageNpcSerialize;
    [SerializeField] public Sprite npcImageSerialize;
    [SerializeField] private Image fadeTexture;
    public static Image fadeTextureStatic;
    [SerializeField] private TextMeshProUGUI npcWidgetSerialize;
    [SerializeField] private GameObject npcPanelSerialize;
    [SerializeField] private TextMeshProUGUI npcTextSerialize;
    [SerializeField] private GameObject playerSerialize;
    public static PlayerMovement Player;
    public static GameManager self;
    public static bool fadeCanDo = false;
    public static bool canWalk;
    [SerializeField] private PostProcessProfile[] profiles;
    [SerializeField] private PostProcessVolume postProcessVolume;
    private void Awake()
    {
        canWalk = true;
        self= this;
    }

    public static Sprite npcImage   // property
    {
        get { return self.npcImageSerialize; }   // get method
        set { self.npcImageSerialize = value; }  // set method
    }

    void Start()
    {
        postProcessVolume.profile = profiles[0];
        npcImage = npcImageSerialize;
        Player = playerSerialize.GetComponent<PlayerMovement>();
        fadeTexture.color = new Color(fadeTexture.color.r, fadeTexture.color.g, fadeTexture.color.b, 0);
        npcWidget = npcWidgetSerialize;
        npcPanel = npcPanelSerialize;
        npcText = npcTextSerialize;
        player = playerSerialize;
        ShowNpcHud(false);
        imageNpc = imageNpcSerialize;
        SetImage();
        audioPlayer = player.GetComponent<AudioSource>();
    }

    public static void CreateDialog()
    {

    }
    public static void SetImage()
    {
        if (imageNpc != null && npcImage != null)
        {
            imageNpc.sprite = npcImage;
        }
    }
    public static void ShowNpcHud(bool visible)
    {
        npcPanel.SetActive(visible);
        canWalk = false;
        if (visible == false)
        {
            canWalk = true;
        }
        SetImage();

    }
    public void Fade(float opacity, float intensity, bool finished)
    {
        StartCoroutine(FadeIn(opacity, intensity, finished));
    }
    public IEnumerator FadeIn(float opacity,float intensity, bool finished)
    {
        yield return 0;
        fadeTexture.color = new Color(fadeTexture.color.r,fadeTexture.color.g,fadeTexture.color.b, opacity);
        if (opacity >= 1)
        {
            finished = true;
            fadeCanDo = true;
        }
        if(finished == false)
        {
            StartCoroutine(FadeIn(opacity + intensity * Time.deltaTime, intensity, finished));
            fadeCanDo = false;
        }
        else if(opacity>0)
        {
            StartCoroutine(FadeIn(opacity - intensity * Time.deltaTime, intensity, finished));
        }else if (opacity <= 0)
        {
            Debug.Log("Fim");
            //GameManager.canWalk= true;
        }
    }

    // Update is called once per frame
    public static void FadeInFinal()
    {
        fadeTextureStatic.color = new Color(0,0,0,1);
    }
    void Update()
    {
        
    }
}
