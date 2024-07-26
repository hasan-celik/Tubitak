using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyGameStart : MonoBehaviour
{
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _startGameButton;

    private static LobbyGameStart instance;

    void Start()
    {
        instance = this;

        _cancelButton.onClick.AddListener(() => 
        {
            Hide_Static();
        });

        _startGameButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
    }
    public static void Show_Static()
    {
        instance.gameObject.SetActive(true);
    }

    public static void Hide_Static()
    {
        instance.gameObject.SetActive(false);
    }
}
