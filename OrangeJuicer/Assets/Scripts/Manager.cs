using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Manager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField]
    private TextMeshProUGUI levelText;
    public int levelNumber = 1;

    [Header("Progress")]
    [SerializeField]
    private Bar progressBar;
    public int totalEnemyCount;
    public int currentEnemyCount;

    [Header("Economy")]
    [SerializeField]
    private TextMeshProUGUI silverCountText;

    [Header("Start-End Game")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject levelEndArea;
    [SerializeField]
    private GameObject levelEndUI;
    [SerializeField]
    private GameObject levelUI;

    private bool isFirstTouch;
    [HideInInspector]
    public bool firstMove;

    public bool isLevelCompleted;
    public bool isAllEnemiesDied;

    public static Manager manager;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        levelText.text = "LEVEL - " + levelNumber.ToString();
    }

    private void Update()
    {
        if (!isFirstTouch && firstMove)
        {
            isFirstTouch = true;
            tutorial.SetActive(false);
        }
    }

    public void CompleteLevel()
    {
        // Debug.Log("LEVEL COMPLETED");
        isLevelCompleted = true;
        levelEndUI.SetActive(true);
    }

    public void AllEnemiesDied()
    {
        levelEndArea.SetActive(true);
        isAllEnemiesDied = true;
    }

    public void DisplaySilver(int value)
    {
        silverCountText.text = value.ToString();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    public IEnumerator StartGameRoutine()
    {

        yield return new WaitForSeconds(1);
        firstMove = true;
        levelUI.SetActive(true);
    }

    public void IncreaseEnemyCount()
    {
        totalEnemyCount++;
        currentEnemyCount = totalEnemyCount;
        progressBar.SetMaxValue(totalEnemyCount);
        progressBar.SetCurrentValue(0);
    }

    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
        progressBar.SetCurrentValue(totalEnemyCount - currentEnemyCount);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(levelNumber - 1);
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings > levelNumber)
            SceneManager.LoadScene(levelNumber);
        else
            SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
