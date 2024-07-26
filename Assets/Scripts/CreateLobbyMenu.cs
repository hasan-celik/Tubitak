using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyMenu : MonoBehaviour
{
    private static CreateLobbyMenu instance;

    [SerializeField] private Button lobbyNameButton;
    [SerializeField] private Button maxPlayersButton;
    [SerializeField] private Button publicPrivateButton;
    [SerializeField] private Button BackToPlayMenuButton;
    [SerializeField] private Button createButton;

    [SerializeField] private TMP_Text lobbyNameText;
    [SerializeField] private TMP_Text _maxPlayerText;
    [SerializeField] private TMP_Text publicPrivateText;


    private string _lobbyName = "MyLobby";
    private int _maxPlayers = 10;
    private bool isGamePublic = true;

    private void Awake()
    {
        instance = this;
        Hide_Static();

        publicPrivateText.text = "Public";
        
        lobbyNameButton.onClick.AddListener(() =>
        {
            UI_InputWindow.Show_Static("","", "abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZ .,-",10, () =>
            {
                
            }, (string newLobbyName) =>
            {
                _lobbyName = newLobbyName;
                lobbyNameText.text = "Lobby Name: " + _lobbyName;
            });
        });
        
        maxPlayersButton.onClick.AddListener(() =>
        {
            UI_InputWindow.Show_Static("Max Player","", "0123456789",2, () =>
            {
                
            }, (string newMaxPlayer) =>
            {
                _maxPlayers = Convert.ToInt16(newMaxPlayer);
                _maxPlayerText.text = "Max Player: " + _maxPlayers.ToString();
            });
        });
        
        publicPrivateButton.onClick.AddListener(() =>
        {
            if (isGamePublic)
            {
                isGamePublic = false;
                publicPrivateText.text = "Private";
            }

            if (!isGamePublic)
            {
                isGamePublic = true;
                publicPrivateText.text = "Public";
            }
        });
        
        createButton.onClick.AddListener(() =>
        {
            try
            {
                LobbyManager.Instance.CreateLobby(_lobbyName, _maxPlayers, isGamePublic,
                    LobbyManager.GameMode.CaptureTheFlag);
                Loader.Load(Loader.Scene.LobbyScene);
                
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        });
        
        BackToPlayMenuButton.onClick.AddListener(() =>
        {
           Hide_Static(); 
        });
    }

    public static void Show_Static()
    {
        instance.gameObject.SetActive(true);
        instance.transform.SetAsLastSibling();
    }
    
    public static void Hide_Static()
    {
        instance.gameObject.SetActive(false);
    }
}
