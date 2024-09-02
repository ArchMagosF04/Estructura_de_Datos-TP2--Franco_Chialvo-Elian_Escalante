using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour
{
    [SerializeField] private List<TierText> entries = new List<TierText>();
    [SerializeField] private TierText tierTextPrefab;

    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField scoreField;
    [SerializeField] private Button confirmButton;

    [SerializeField] private bool startWithRandomEntries=true;

    [SerializeField] private int maxElementsInBoard = 10;

    private void Awake()
    {
        confirmButton.onClick.AddListener(EnterInformation);

        CreateTierBoxes();
    }

    private void Start()
    {
        if (startWithRandomEntries)
        {
            CreateRandomEntries();
        }
    }

    private void CreateTierBoxes()
    {
        for(int i = 0;i < maxElementsInBoard; i++)
        {
            TierText tier = Instantiate(tierTextPrefab, transform);
            string index = (i+1).ToString();
            tier.SetPlaceInIndex(index);
            entries.Add(tier);
        }
    }

    private void CreateRandomEntries()
    {
        for(int i = 0; i < maxElementsInBoard; i++)
        {
            string randomScore = Random.Range(1, 1000).ToString();
            AddValueToBoard("Player " + i, randomScore);
        }
    }

    private void OnDestroy()
    {
        confirmButton.onClick.RemoveAllListeners();
    }

    private void AddValueToBoard(string name, string score)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (int.Parse(score) >= int.Parse(entries[i].Score))
            {
                for (int j = 0; j < (maxElementsInBoard - 1) - i; j++)
                {
                    entries[(maxElementsInBoard - 1) - j].ChangeValues(entries[(maxElementsInBoard - 2) - j].PlayerName, entries[(maxElementsInBoard - 2) - j].Score);
                }

                entries[i].ChangeValues(name, score);
                Debug.Log(name + ": " + score);

                return;
            }
        }
    }

    public void EnterInformation()
    {
        AddValueToBoard(nameField.text, scoreField.text);

        nameField.text = "";
        scoreField.text = "";
    }
}

