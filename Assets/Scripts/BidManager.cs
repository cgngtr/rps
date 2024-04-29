using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BidManager : MonoBehaviour
{
    [SerializeField] private ObjectCounter _objectCounter;
    [SerializeField] private Slider slider;
    [SerializeField] private int bidAmount;
    public int balance = 5000;
    public string currentBid = null; // Object placed bids to.

    void Start()
    {
        _objectCounter = GetComponent<ObjectCounter>();
        StartCoroutine(Checker());
    }

    void Update()
    {

    }

    public void UpdateBalance()
    {
        if ((_objectCounter.DecideWinner() == currentBid) && _objectCounter.winnerAvailable)
        {
            Debug.Log("You win.");
            balance += bidAmount;
        }
        else if (_objectCounter.DecideWinner() != currentBid)
        {
            Debug.Log("You lose.");
            balance -= bidAmount;    
        }
        
    }

    public void SelectRock()
    {
        currentBid = "Rock";
    }

    public void SelectPaper()
    {
        currentBid = "Paper";
    }

    public void SelectScissors()
    {
        currentBid = "Scissors";
    }

    public void PlaceBid()
    {
        bidAmount = (int)slider.value;
    }
    IEnumerator Checker()
    {
        //

        yield return new WaitForSeconds(1f);
    }

}
