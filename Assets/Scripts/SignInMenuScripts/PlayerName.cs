using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;

    private void Start()
    {
        playerName = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = EditPlayerName.Instance.GetPlayerName();
    }
}
