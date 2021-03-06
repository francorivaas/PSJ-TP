using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController Player => player;
    private PlayerController player;

    public ShootingController PlayerWeapon => playerWeapon;
    private ShootingController playerWeapon;

    public static bool hasTools;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }

    public void SetPlayerWeapon(ShootingController playerWeapon)
    {
        this.playerWeapon = playerWeapon;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
