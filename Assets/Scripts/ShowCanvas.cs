using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    [SerializeField]private GameObject _canvas;

    private void Start()
    {
        _canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        _canvas.SetActive(true);
    }
}
