using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private Button _quickPlayButton;
    [SerializeField] private Button _hostLobbyButton;
    [SerializeField] private Button _joinWithCodeButton;
    [SerializeField] private Button _quitButton;
    
    private static PlayMenu instance;

    private void Awake()
    {
        instance = this;
        
        Hide_Static();
        
        _quickPlayButton.onClick.AddListener(() =>
        {
            LobbyManager.Instance.QuickJoinLobby();
        });
        
        _hostLobbyButton.onClick.AddListener(() =>
        {
            CreateLobbyMenu.Show_Static();
        });
        
        _joinWithCodeButton.onClick.AddListener(() =>
        {
            UI_InputWindow.Show_Static("Code","Lobby Code","abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZ .,-",15, () =>
            {
                
            }, (string lobbyCode) =>
            {
                LobbyManager.Instance.JoinLobbyByCode(lobbyCode);
            });
        });
        
        _quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
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
