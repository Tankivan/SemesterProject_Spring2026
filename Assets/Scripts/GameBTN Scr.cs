using UnityEngine;

public class GameBTNScr : MonoBehaviour
{
    [Header("Кнопки")]
    public KeyCode pauseKey = KeyCode.Escape;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
            Pause();
    }

    private void Pause()
    { 

    }
}
