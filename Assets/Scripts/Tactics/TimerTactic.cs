using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimerTactic : MonoBehaviour
{
    [SerializeField] float initialTime = 60;
    float currentTime;
    public bool timeFinished = false;
    [SerializeField]
    TextMeshProUGUI txtEnd;
    [SerializeField]
    TextMeshProUGUI txtTimer;
    [SerializeField]
    TextMeshProUGUI txtLevel;
    [SerializeField]
    TextMeshProUGUI txtScore;

    public UnityEvent OnTimeFinished;
    public UnityEvent OnGameRestarted;

    void Start()
    {
        timeFinished = false;
        currentTime = initialTime;
        UpdateTimerText();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerText();
        }

        FinishGame();
    }

    private void UpdateTimerText()
    {
        txtTimer.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
    }

    private void FinishGame()
    {
        timeFinished = true;
        txtEnd.gameObject.SetActive(true);
        Time.timeScale = 0;
        OnTimeFinished?.Invoke();
        var pickSystem = FindObjectOfType<PickSystem>();
        txtLevel.text = pickSystem.Level.ToString();
        txtScore.text = pickSystem.Experience.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeFinished)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
        Time.timeScale = 1;
        txtEnd.gameObject.SetActive(false);
        OnGameRestarted?.Invoke();
    }
}
