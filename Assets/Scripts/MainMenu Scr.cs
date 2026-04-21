using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScr : MonoBehaviour
{
    [Header("Панели")]
    public GameObject title;
    public GameObject buttonPanel;
    public GameObject levelSelectPanel;
    public GameObject settingsPanel;

    [Header("Камера")]
    public Camera mainCamera;
    public Transform zoomTarget;
    public float zoomedOrthographicSize = 2f;
    public float zoomDuration = 1f;

    private Vector3 originalCameraPos;
    private float originalOrthographicSize;


    void Start()
    {
        originalCameraPos = mainCamera.transform.position;
        originalOrthographicSize = mainCamera.orthographicSize;

        levelSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void OnPlayClick()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        title.SetActive(false);
        buttonPanel.SetActive(false);

        float elapsed = 0;
        Vector3 startPos = mainCamera.transform.position;
        float startSize = mainCamera.orthographicSize;

        while (elapsed < zoomDuration)
        {
            float t = elapsed / zoomDuration;
            t = Mathf.SmoothStep(0, 1, t);

            mainCamera.transform.position = Vector3.Lerp(startPos, zoomTarget.position, t);
            mainCamera.orthographicSize = Mathf.Lerp(startSize, zoomedOrthographicSize, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = zoomTarget.position;
        mainCamera.orthographicSize = zoomedOrthographicSize;

        levelSelectPanel.SetActive(true);
    }

    public void OnSettingsClick()
    {
        StartCoroutine(SettingsSequence());
    }

    IEnumerator SettingsSequence()
    {
        title.SetActive(false);
        buttonPanel.SetActive(false);

        float elapsed = 0;
        Vector3 startPos = mainCamera.transform.position;
        float startSize = mainCamera.orthographicSize;

        while (elapsed < zoomDuration)
        {
            float t = elapsed / zoomDuration;
            t = Mathf.SmoothStep(0, 1, t);
            mainCamera.transform.position = Vector3.Lerp(startPos, zoomTarget.position, t);
            mainCamera.orthographicSize = Mathf.Lerp(startSize, zoomedOrthographicSize, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        settingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        StopAllCoroutines();
        levelSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);

        StartCoroutine(ReturnCamera());
    }

    IEnumerator ReturnCamera()
    {
        float elapsed = 0;
        Vector3 startPos = mainCamera.transform.position;
        float startSize = mainCamera.orthographicSize;

        while (elapsed < zoomDuration)
        {
            float t = elapsed / zoomDuration;
            t = Mathf.SmoothStep(0, 1, t);
            mainCamera.transform.position = Vector3.Lerp(startPos, originalCameraPos, t);
            mainCamera.orthographicSize = Mathf.Lerp(startSize, originalOrthographicSize, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = originalCameraPos;
        mainCamera.orthographicSize = originalOrthographicSize;

        title.SetActive(true);
        buttonPanel.SetActive(true);
    }

    public void OnQuitClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelSequence(levelIndex));
    }

    IEnumerator LoadLevelSequence(int levelIndex)
    {
        levelSelectPanel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelByName(string sceneName)
    {
        StartCoroutine(LoadLevelByNameSequence(sceneName));
    }

    IEnumerator LoadLevelByNameSequence(string sceneName)
    {
        levelSelectPanel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }

}
