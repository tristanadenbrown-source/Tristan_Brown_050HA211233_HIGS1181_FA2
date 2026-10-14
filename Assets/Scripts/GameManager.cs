using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI winScreen;
    public TextMeshProUGUI loseScreen;
    public PlayerController targetedScriptref;
    public bool Loss = false;
    public bool Win = false;

    public TextMeshProUGUI uiObjectWin;
    public TextMeshProUGUI uiObjectlose;

    public int score = 0;//this variable is referenced for player score//
    public int health = 3;//this variable is referenced as playerr health
    private bool death = false;




    void Update()
    {
        UpdateUI();

    }

    private void LateUpdate()
    {
        CheckWinCodition();
        CheckLoseConDition();
    }
    public void AddScore()
    {
        if (score <= 5)
        {
        string collectible = "Collectible found";//referece for dubug log message
        score += 1;
        Debug.Log(collectible);
        }

    }

    public void UpdateUI()
    {
        if (Loss == false || Win ==  false)
        {
            textScore.text = "Score: " + score.ToString();
            textHealth.text = "health: " + health.ToString();
        }

        if (Win == true )
        {
            uiObjectWin.enabled = true;
            Destroy(GetComponent<GameManager>());

        }

        if (Loss ==  true)
        {
            uiObjectlose.enabled = true;
            Destroy(GetComponent<GameManager>());
        }
    }

    void CheckWinCodition()
    {
        if(score >= 5)
        {
            Win = true;
            Debug.Log("You Win");
        }
    }

    void CheckLoseConDition()
    {
        if(health <=0)
        {
        Loss = true;
        Debug.Log("Youlose");
        }

    }

}
