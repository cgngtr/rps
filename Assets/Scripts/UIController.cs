using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rock;
    [SerializeField] private TextMeshProUGUI paper;
    [SerializeField] private TextMeshProUGUI scissors;
    [SerializeField] private TextMeshProUGUI objectWon;
    [SerializeField] private TextMeshProUGUI balance;
    [SerializeField] private ObjectCounter _objectCounter;
    [SerializeField] private BidManager _bidManager;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        UpdateRPS();
    }

    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _objectCounter = GetComponent<ObjectCounter>();
    }

    void Update()
    {
        UpdateRPS();
        if(_objectCounter.winnerAvailable && _gameManager.isPressed)
        {
            ShowWinner();
        }
    }

    void UpdateRPS()
    {
        rock.text = $"Rock : {_objectCounter.rock.Count}";
        paper.text = $"Paper : {_objectCounter.paper.Count}";
        scissors.text = $"Scissors : {_objectCounter.scissors.Count}";
    }

    public void ShowWinner()
    {
        objectWon.text = $"{_objectCounter.DecideWinner()} WON!";
        balance.text = $"Account balance : ${_bidManager.balance}";
    }

}
