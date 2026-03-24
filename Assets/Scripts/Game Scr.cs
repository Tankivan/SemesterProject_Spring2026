using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameScr : MonoBehaviour
{
    [Header("Кнопки")]
    public Button performBTN;
    public Button nextLvlBTN;
    public Button toMenuBTN;
    public Button exitBTN;
    public Button resetBTN;
    public Button resetLvlBTN;

    [Header("Панели")]
    public GameObject gameFramePanel;
    public GameObject successFramePanel;
    public GameObject failFramePanel;
    void Start()
    {
        performBTN.onClick.AddListener(Perform);
        nextLvlBTN.onClick.AddListener(nextLVL);
        toMenuBTN.onClick.AddListener(toMenu);
        exitBTN.onClick.AddListener(Exit);
        resetBTN.onClick.AddListener(Reset);
        resetLvlBTN.onClick.AddListener(resLvl);
    }



    void Update()
    {
        
    }

    private void Perform()
    {
        //Кнопка выполнить поменять функционал сейчас окно успеха
        successFramePanel.SetActive(true);
        gameFramePanel.SetActive(false);
        failFramePanel.SetActive(false);
    }
    private void Reset()
    {
        //Кнопка сбросить поменять функционал сейчас окно провала
        failFramePanel.SetActive(true);
        gameFramePanel.SetActive(false);
        successFramePanel.SetActive(false);
        
    }
    private void Exit() 
    {
        Application.Quit();
    }
    private void nextLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void toMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void resLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
