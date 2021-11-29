using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct Spawn
{
    public GameObject enemyPref;
    public int spawnNum;
    public float respawnRate;
}

public class SpawnManager : MonoBehaviour
{
    public GameObject prentObj;
    public Spawn[] spawns;

    public GameObject waveText;


    public int stageNum;
    bool check = false;
    public Transform[] from;
    public Transform[] to;
    public Transform point;
    void Start()
    {
        InvokeRepeating("Spawn", 2, spawns[stageNum].respawnRate);
    }
    void Spawn()
    {
        if (isDie() && !check && stageNum < 3)
        {
            StartCoroutine(WaveTextLoad());
            for (int i = 0; i < spawns[stageNum].spawnNum; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(from[stageNum].transform.position.x, to[stageNum].transform.position.x)
                , 0, Random.Range(from[stageNum].transform.position.z, to[stageNum].transform.position.z));
                GameObject Enemy = GameObject.Instantiate(spawns[stageNum].enemyPref, spawnPos, Quaternion.identity);
                Enemy.transform.parent = prentObj.transform;
            }
            check = true;
            stageNum++;
        }
        if(stageNum == 3 && !check && isDie())
        {
            StartCoroutine(WaveTextLoad());
            Vector3 spawnPos = new Vector3(point.position.x, point.position.y, point.position.z);
            GameObject Enemy = GameObject.Instantiate(spawns[stageNum].enemyPref, spawnPos, Quaternion.identity);
            Enemy.transform.parent = prentObj.transform;
            check = true;
            stageNum++;
        }
        if(stageNum > 3 && !check && isDie())
        {
            SceneLoader.LoadSceneHandle("GameSet", 4);
        }
    }

    IEnumerator WaveTextLoad()
    {
        GameObject waveTextClone = Instantiate(waveText);
        if (stageNum == 3)
        {
            waveTextClone.GetComponentInChildren<Text>().text = "BOSS WAVE";
        }
        else
        {
            waveTextClone.GetComponentInChildren<Text>().text = "WAVE " + (stageNum + 1);
        }
        Color temp = waveTextClone.GetComponentInChildren<Text>().color;
        temp.a = 0f;
        waveTextClone.GetComponentInChildren<Text>().color = temp;

        while (waveTextClone.GetComponentInChildren<Text>().color.a <1.0f)
        {
            temp = waveTextClone.GetComponentInChildren<Text>().color;
            temp.a+=0.05f;
            waveTextClone.GetComponentInChildren<Text>().color = temp;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        while (waveTextClone.GetComponentInChildren<Text>().color.a > 0.0f)
        {
            temp = waveTextClone.GetComponentInChildren<Text>().color;
            temp.a -= 0.05f;
            waveTextClone.GetComponentInChildren<Text>().color = temp;
            yield return null;
        }
        Destroy(waveTextClone);
    }

    bool isDie()
    {
        if (prentObj.transform.childCount == 0)
        {
            check = false;
            return true;   
        }
        else
        {
            return false;
        }
    }
}
