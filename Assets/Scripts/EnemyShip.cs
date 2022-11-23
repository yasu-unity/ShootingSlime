using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵を生成:生成工場を作る←EnemyGenerator
//敵とPlayerがぶつかったら爆発する
public class EnemyShip : MonoBehaviour
{
    public GameObject explosion; //破壊のプレファブ
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("GameController");
        //ヒエラルキー上のGameControllerという名前のオブジェクトを取得
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //敵の移動:真下に移動する
        transform.position -= new Vector3(0, Time.deltaTime, 0);
     }
    //敵に弾が当たったら爆発する
    //当たり判定を行うには、
    //両社にColliderがついていて、
    //どちらかにRigidbodyがついていなければならない。
    //敵か弾か←敵につけた
    //Playerと弾の差別化:Tag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collisionにぶつかった相手の情報が入っている。:Player Bullet
        if (collision.CompareTag("Player") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Bullet")== true)
        {
            gameController.AddScore();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("box") == true)
        {
            
        }
    }
}
