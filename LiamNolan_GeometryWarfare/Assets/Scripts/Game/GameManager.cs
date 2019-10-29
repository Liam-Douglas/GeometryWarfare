using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameUI, deadUI;

    public void PlayerDied()
    {
        Debug.Log("Player Died");
        deadUI.SetActive(true);
        gameUI.SetActive(false);

    }
}
