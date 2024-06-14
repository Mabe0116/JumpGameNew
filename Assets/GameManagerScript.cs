using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;
    public GameObject Coin;
    public static  int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int[,] map =
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,1,1,1,0,0,0,0,2,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,3,0,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };

        score = 0;
       
        Vector3 position = Vector3.zero;

        for (int y = 0; y < map.GetLength(0); y++)
        {
            position.y = -y + 5;

            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;

                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                //ゴール位置設定
                if (map[y, x] == 2)
                {
                    goal.transform.position = position;
                }

                //コイン
                if (map[y, x] == 3)
                {
                    Instantiate(Coin, position, Quaternion.identity);
                }

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ゲームクリアでスペースキーでタイトルへ移行
        if(GoalScript.isGameClear == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) || UnityEngine.Input.GetButton("Jump"))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        scoreText.text = "SCORE " + score;
    }
}
