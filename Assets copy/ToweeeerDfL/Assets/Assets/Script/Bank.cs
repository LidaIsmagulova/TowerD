using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 250;
    [SerializeField] private TextMeshProUGUI displayBalance;

    private int _currentBalance;
    public int CurrentBalance
    {
        get { return _currentBalance; }
    }
    private void Start()
    {
        _currentBalance = startingBalance;
        UpdateBalance();
    }
    public void Deposit(int value)
    {
        _currentBalance += Mathf.Abs(value);
        UpdateBalance();

        if (_currentBalance > 500)
            ReloadScene();
    }

    public void WithDraw(int value)
    {
        _currentBalance -= Mathf.Abs(value);
        UpdateBalance();

        if (_currentBalance <=0 )
            ReloadScene();
    }
    private void ReloadScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void UpdateBalance()
    {
        displayBalance.text = $"Gold: {_currentBalance}";
    }
}
