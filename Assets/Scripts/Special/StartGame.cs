using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject _rollMenu;

    void OnEnable()
    {
        _rollMenu.SetActive(true);
    }
}
