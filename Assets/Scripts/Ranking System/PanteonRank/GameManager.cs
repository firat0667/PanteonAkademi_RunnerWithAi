using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    private IngameRanking ig;
    private GameObject[] runners;
    List<RaningSystem> sortArray = new List<RaningSystem>();
    public bool isGameEnding;
    public float HighScore = 1000;
    public float Timer;
    public Text TimerText;
    public Text HighScoreText;
   // public int IsHighScore;
    public int highScoreIsTrue=0;
    public List<float> BestScore = new List<float>();
   
    void Awake()
    {
        Instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<IngameRanking>();
        highScoreIsTrue =PlayerPrefs.GetInt("HighScoreTrue");

    }
    private void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        HighScoreText.text =  "Best: "+ HighScore.ToString("0.##");

        for (int i = 0; i < runners.Length; i++)
        {
            sortArray.Add(runners[i].GetComponent<RaningSystem>());
        }
    }
    void CalculateRank()
    {
        sortArray = sortArray.OrderBy(x => x.Distance).ToList();
        for (int i = 0; i <runners.Length; i++)
        {
            sortArray[i].Rank = i + 1;
        }
        ig.a = sortArray[0].name;
        ig.b = sortArray[1].name;
        ig.c = sortArray[2].name;
        ig.d = sortArray[3].name;
        ig.e = sortArray[4].name;
        ig.f = sortArray[5].name;
       // ig.g = sortArray[0].name;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateRank();

        if (!isGameEnding)
        {
            Timer += Time.deltaTime;
        }
        else
        {
         
        }
        TimerText.text =Timer.ToString("0.##");
    }
}
