using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public GameObject retryButton;

    [SerializeField]
    private TextMeshProUGUI textGoal;

    [SerializeField]
    private int goal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textGoal.SetText(goal.ToString());
        retryButton.SetActive(false);
    }

    public void DecreaseGoal()
    {
        goal = goal - 1;
        if (goal <= 0)
        {
            SetGameOver(true);
        }
        textGoal.text = goal.ToString();
    }

    public void SetGameOver(bool success)
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            Camera.main.backgroundColor = success ? Color.green : Color.red;
        }
        Invoke("ShowRetryButton", 0.3f);
    }

    void ShowRetryButton()
    {
        retryButton.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
