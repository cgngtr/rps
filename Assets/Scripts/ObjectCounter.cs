using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public UIController _UIController;
    public GameObject[] objectsToCount;
    public GameManager _gameManager;
    public List<GameObject> rock = new List<GameObject>();
    public List<GameObject> paper = new List<GameObject>();
    public List<GameObject> scissors = new List<GameObject>();
    public bool isRockZero = false;
    public bool isPaperZero = false;
    public bool isScissorsZero = false;
    public bool winnerAvailable = false;
    public string winner;

    private int[] objectCounts;

    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _UIController = GetComponent<UIController>();
        objectCounts = new int[objectsToCount.Length];
        //StartCoroutine(CheckZeros());
    }

    public void Update()
    {
        HandleTransformation();
        DecideWinner();
    }

    void UpdateObjectCounts()
    {
        rock.Clear();
        paper.Clear();
        scissors.Clear();

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Rock");
        rock.AddRange(allObjects);

        allObjects = GameObject.FindGameObjectsWithTag("Paper");
        paper.AddRange(allObjects);

        allObjects = GameObject.FindGameObjectsWithTag("Scissors");
        scissors.AddRange(allObjects);
    }

    public string DecideWinner()
    {
        if (rock.Count == 0 && _gameManager.isPressed)
            isRockZero = true;
        else
            isRockZero = false;


        if (paper.Count == 0 && _gameManager.isPressed)
            isPaperZero = true;
        else
            isPaperZero = false;


        if (scissors.Count == 0 && _gameManager.isPressed)
            isScissorsZero = true;
        else
            isScissorsZero = false;

        if (isPaperZero && isScissorsZero)
        {
            winnerAvailable = true;
            
            winner = "Rock";
        }

        else if(isRockZero && isScissorsZero)
        {
            winnerAvailable = true;
            winner = "Paper";
        }

        else if (isRockZero && isPaperZero)
        {
            winnerAvailable = true;
            winner = "Scissors";
        }
        else
        {
            winnerAvailable = false;
        }
        return winner;
    }

    public void HandleTransformation()
    {
        UpdateObjectCounts();
    }

    IEnumerator CheckZeros()
    {
        Debug.Log(isRockZero);
        Debug.Log(isPaperZero);
        Debug.Log(isScissorsZero);

        yield return new WaitForSeconds(1f);
    }
}
