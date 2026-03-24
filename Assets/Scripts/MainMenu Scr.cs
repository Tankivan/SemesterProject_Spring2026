using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScr : MonoBehaviour
{
    [Header("Кнопки")]
    public Button playBTN;
    //public Button settingsBTN;
    public Button exitBTN;
    public Button cancelBTN;

    [Header("Кнопки уровней")]
    public Button firstLVLBTN;
    public Button secondLVLBTN;
    public Button thirdLVLBTN;
    public Button fourLVLBTN;
    public Button fiveLVLBTN;

    [Header("Панели меню")]
    public GameObject menuPanel;
    //public GameObject settingsPanel;
    public GameObject lvlChoicePanel;


    void Start()
    {
        playBTN.onClick.AddListener(Play);
        //settingsBTN.onClick.AddListener(Settings);
        exitBTN.onClick.AddListener(Exit);
        cancelBTN.onClick.AddListener(Cancel);
        firstLVLBTN.onClick.AddListener(firstLVL);
        secondLVLBTN.onClick.AddListener(secondLVL);
        thirdLVLBTN.onClick.AddListener(thirdLVL);
        fourLVLBTN.onClick.AddListener(fourLVL);
        fiveLVLBTN.onClick.AddListener(fiveLVL);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        menuPanel.SetActive(false);
        //settingsPanel.SetActive(false);
        lvlChoicePanel.SetActive(true);
        cancelBTN.gameObject.SetActive(true);
    }
    /*public void Settings()
    {
        menuPanel.SetActive(false);
        //settingsPanel.SetActive(true);
        lvlChoicePanel.SetActive(false);
        cancelBTN.gameObject.SetActive(true);
    }
    */
    public void Exit()
    {
        Application.Quit();
    }
    public void Cancel()
    {
        menuPanel.SetActive(true);
        //settingsPanel.SetActive(false);
        lvlChoicePanel.SetActive(false);
        cancelBTN.gameObject.SetActive(false);
    }
    public void firstLVL()
    {
        SceneManager.LoadScene(1);
    }
    public void secondLVL() 
    {
        SceneManager.LoadScene(2);
    }
    public void thirdLVL()
    {
        SceneManager.LoadScene(3);
    }
    public void fourLVL()
    {
        SceneManager.LoadScene(4);
    }
    public void fiveLVL()
    {
        SceneManager.LoadScene(5);
    }

}
