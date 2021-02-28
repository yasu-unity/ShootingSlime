using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerShipを方向キーで動かす
//・方向キーの入力を受け取り、Playerの位置を変更する

//弾を撃つ
//・弾を作り、弾の動きを作る。
//・発射ポイントを作る。
//・ボタンを押したときに弾を生成する。
public class PlayerShip : MonoBehaviour
{
    public Transform firePoint; //弾を発射する位置
    public GameObject bulletPrefab;
    AudioSource audioSource;
    public AudioClip shotSE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //約0.02秒に一回実行
    void Update()
    {
        Shot();
        Move();
    }
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            audioSource.PlayOneShot(shotSE);
        }
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition=transform.position+ new Vector3(x, y, 0) * Time.deltaTime * 4f;
        //移動できる範囲をMathf.Clampを使って制御
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x,-3.5f,3.5f),
            Mathf.Clamp(nextPosition.y,-6.5f,6.5f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }
}
