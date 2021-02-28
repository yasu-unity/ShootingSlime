using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy生成工場

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //繰り返し関数を実行する
        InvokeRepeating("Spawn", 2f, 0.5f); //Spawn関数を２秒後に0.5刻みで実行する。
    }
    //生成する
    void Spawn()
    {
        //生成する位置(x)をランダムにしたい
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3.8f, 3.8f),
            transform.position.y,
            transform.position. z
            );
        Instantiate(enemyPrefab, //生成するオブジェクト
            spawnPosition,       //生成位置
            transform.rotation);     //生成時の向き
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
