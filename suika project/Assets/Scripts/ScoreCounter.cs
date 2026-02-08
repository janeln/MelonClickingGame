using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Instance to be loaded in MelonBehavior when point is scored
    public static ScoreCounter Instance;

    // Current score
    [SerializeField] private TMP_Text scoreText;
    int score = 0;

    //// High score
    //public TextMeshProUGUI highscoreText;
    //int highscore = 0;

    private void Awake()
    {
        Instance = this; // Sets to ScoreCounter
    }

    void Start()
    {
        scoreText.text = score.ToString() + " slices";
        //highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score++;
        if (score == 1)
        {
            scoreText.text = "1 slice";
        }
        else
        {
            scoreText.text = score.ToString() + " slices";
        }
    }
}
