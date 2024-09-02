using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TierText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI index;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI score;

    public string PlayerName => playerName.text;
    public string Score => score.text;

    public void SetPlaceInIndex(string index)
    {
        this.index.text = index;
    }

    public void ChangeValues(string name , string score)
    {
        playerName.text = name;
        this.score.text = score;
    }
}
