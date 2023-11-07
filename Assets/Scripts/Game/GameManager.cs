using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _goalText;
    [SerializeField] private Text _loadScreenGoal;
    [SerializeField] private Text _time;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _loadScreen;

    public bool gameStarted;
    public LeaderBoard leaderBoard;
    public SaveManager saveManager;
    public int score;
    public int goal;
    public int time;

    private int _timespeed = 0;
    private void Start()
    {
        _menu.SetActive(false); 
        _game.SetActive(false);
        StartCoroutine(LoadScreen());

    }
    private void Update()
    {
        if (time <= 0)
            ToMenu();
        if (score >= goal)
            GameOver();
    }
    private IEnumerator LoadScreen()
    {
        yield return new WaitForSeconds(3);
        _menu.SetActive(true);
        _game.SetActive(true);
        _loadScreen.SetActive(false);
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time--;
        TextsUpdate();
        StartCoroutine(Timer());
    }
    public void PauseChange()
    {
        Time.timeScale = _timespeed;
        if (_timespeed == 0)
            _timespeed++;
        else
            _timespeed = 0;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void TextsUpdate()
    {
        _scoreText.text = "Money $" + score.ToString();
        _loadScreenGoal.text = "$" + goal.ToString();
        _goalText.text = "Goal $" + goal.ToString();
        _time.text = "Time: " + time.ToString();
    }
    public void GameOver()
    {
        Save();
        ToMenu();
    }
    public void Save()
    {
        saveManager.SaveLeader(leaderBoard.GetLeaders());
        saveManager.SavePlayer();
    }
}
