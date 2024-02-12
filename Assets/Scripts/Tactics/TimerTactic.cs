using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerTactic : MonoBehaviour
{
    [SerializeField] float time = 60;
    public bool timeFinished = false;
    [SerializeField]
    TextMeshProUGUI txtEnd;

    void Start()
    {
        timeFinished = false;
        Invoke("FinishGame", time);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeFinished)
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex);
            Time.timeScale = 1;
            txtEnd.gameObject.SetActive(false);
        }
    }

    private void FinishGame()
    {
        timeFinished = true;
        txtEnd.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
