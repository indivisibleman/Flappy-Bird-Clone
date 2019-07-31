using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance
    {
        get { return instance; }
    }

    public TMP_Text scoreText;
    public TMP_Text recordText;
    public GameObject startPanel;
    public GameObject flappy;
    public ColumnSpawner columnSpawner;

    private GameObject flappyInstance;
    private int score = 0;
    private int record = 0;
    private bool isRunning = false;

    private static GameController instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        record = PlayerPrefs.GetInt("Record");
        recordText.text = "Record " + record;
    }

    public void Score()
    {
        score++;
        scoreText.text = "Score " + score;

        if (score > record)
        {
            record = score;
            recordText.text = "Record " + record;
            PlayerPrefs.SetInt("Record", record);
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        score = 0;
        scoreText.text = "Score " + score;
        isRunning = true;
        flappyInstance = Instantiate(flappy, Vector3.zero, Quaternion.identity);
    }

    public void ResetGame()
    {
        startPanel.SetActive(true);
        isRunning = false;
        Destroy(flappyInstance);
        columnSpawner.ClearColumns();
        PlayerPrefs.Save();
    }
}
