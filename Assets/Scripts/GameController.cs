using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//スコアの実装
//・敵と弾がぶつかった時にスコア加算+更新

//ゲームオーバーの実装
//・Uiの作成→敵とPlayerがぶつかった時にUIを表示
//・リトライの実装→スペースを押したらシーンを再読み込み

//音をだすには
//・スピーカー:AudioSouce
//・音の素材:AudioClip
//両方がないとならない
public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    int score =0;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "欠片:" + score;
    }
    private void Update()
    {
        if (gameOverText.activeSelf==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene("Stage1");
                RestartThisScene();
            }
        }
       
    }
    public void AddScore()
    {
        score += 1;
        scoreText.text = "欠片:" + score;
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);

    }
    void RestartThisScene()
    {
        Scene ThisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ThisScene.name);
    }
}
