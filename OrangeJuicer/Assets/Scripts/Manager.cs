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
    public int totalCubeCount = 0;
    public int collectedCubeCount = 0;

    [Header("Start-End Game")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject levelEndUI;
    [SerializeField]
    private GameObject levelUI;

    private bool isFirstTouch;

    private bool firstMove;

    public bool isLevelCompleted;

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
            if (!isLevelCompleted)
            {
                isFirstTouch = true;
                tutorial.SetActive(false);
            }
        }

        if (collectedCubeCount >= totalCubeCount)
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        // Debug.Log("LEVEL COMPLETED");
        StopAllCoroutines();
        if (!isLevelCompleted)
        {
            isLevelCompleted = true;
            levelEndUI.SetActive(true);
            levelUI.SetActive(false);
        }
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

    public void IncreaseCollectedCubeCount()
    {
        if (!isLevelCompleted)
        {
            // Debug.Log("Increase CollectedCube Count");
            collectedCubeCount++;
            progressBar.SetCurrentValue(collectedCubeCount);
        }
    }

    public void IncreaseTotalCubeCount()
    {
        if (!isLevelCompleted)
        {
            // Debug.Log("Increase TotalCube Count");
            totalCubeCount++;
            progressBar.SetMaxValue(totalCubeCount);
        }
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
