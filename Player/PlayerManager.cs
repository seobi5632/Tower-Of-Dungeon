using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject dmgText;
    public GameObject effect;
    public GameObject Arrow;

    public bool isPause;
    public bool isFinish;
    public void PlayerPositionReset()
    {
        isFinish = false;
        Invoke("resetPosition", 2.0f);
    }

    private void resetPosition()
    {
        print("dd");
        player.transform.position = new Vector3(0, 0, 0);
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
