using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button btnStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0.0f;
        btnStart = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameClick()
    {
        if (Time.timeScale == 0.0f)
        {
            btnStart.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
