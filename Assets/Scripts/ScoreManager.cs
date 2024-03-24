using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{ 
    private static TextMeshProUGUI scoreText;
    private static int score;
    private static int scoreModifier;

    private static TextMeshPro scoreCountertext;
    private static Vector3 scoreCounterPosition;
    private static Transform scoreCounterparent;
    public TMP_Text puntosText, recordText; 
    private void Start()
    {
        score = 0;
        scoreModifier = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreCountertext = GameObject.Find("Score Counter").GetComponent<TextMeshPro>();
    }

    public static Vector3 ScoreCounterPosition
    {
        get
        {
            return scoreCounterPosition;
        }
        set
        {
            Vector3 counterPos = new Vector3(value.x , value.y + 0.001f , value.z);
            scoreCounterPosition = counterPos;
            scoreCountertext.transform.position = scoreCounterPosition;
            scoreCountertext.gameObject.GetComponent<Animator>().Play(0);
        }
    }

    public static Transform ScoreCounterParent
    {
        get
        {
            return scoreCounterparent;
        }
        set
        {
            scoreCounterparent = value;
            scoreCountertext.transform.SetParent(scoreCounterparent , true);
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value + scoreModifier;
            scoreText.text = score.ToString();
            int temp = 1+scoreModifier;
            scoreCountertext.text = " + "+temp.ToString();
            PlayerPrefs.SetInt("puntos" + temp, 0);
        }
    }

    public void Update()
    {
        puntosText.text = score.ToString();
        recordText.text = PlayerPrefs.GetInt("puntos", 0).ToString();
        if (score > PlayerPrefs.GetInt("puntos", 0))
        {
            PlayerPrefs.SetInt("puntos", score);
            recordText.text = PlayerPrefs.GetInt("puntos",0).ToString();
        }
    }

    public static int ScoreModifier
    {
        get
        {
            return scoreModifier;
        }
        set
        {
            scoreModifier = value;
        }
    }

    private void OnDestroy()
    {
        score = 0;
        scoreModifier = 0;
    }
}
