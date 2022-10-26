//#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText = default;
    [SerializeField]

    static int ScoreMax => 99999;

    static int score;
    static float time;
    static float StartTime => 10;
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        Instance = this;
        ClearScore();
        Item.ClearCount();
        time = StartTime;
        clear = false;
        gameover = false;



    }

    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToClear();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ToGameover();
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AddPoint(12345);
        }
#endif
    }
     void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }
   public static void AddPoint(int add)
    {
        /*
          score += add;
         
        上限チェックその1 手続き型
        if(score > ScoreMax)
        {
            score = ScoreMax;
        }
        */

        //上限チェックその2    手続き型の省略系            参考式　　?でifの代わりにダメだったら:の後が実行される
        // score = score > ScoreMax ? ScoreMax : score;

        //上限チェックその3 関数型で近代的
        score = Mathf.Min(score+add, ScoreMax);

        if (Instance != null)
        {
            Instance.UpdateScoreText();
        }
        
    }

    public static void ClearScore()
    {
        score = 0;
        if(Instance!=null)
        {
            Instance.UpdateScoreText();
        }
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;
        ToClear();
        Time.timeScale = 0;
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }
}
