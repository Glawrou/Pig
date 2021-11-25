using UnityEngine;
using UnityEngine.UI;

public class ConstructScene : MonoBehaviour
{

    public Text PigScoreText;
    public Text DogScoreText;

    [Header("Cheackpoints")]
    public Transform StartPlayer;
    public Transform StratDog;

    [Header("Prifabs")]
    public GameObject PrifabPlayer;
    public GameObject PrifabDog;

    private GameObject Player;
    private GameObject Dog;

    private bool RestartScene = false;
    private int PigScore = 1;
    private int DogScore = 1;

    private void Start()
    {
        PigScoreText.text = "Pig Score " + (PigScore - 1);
        DogScoreText.text = "Dog Score " + (DogScore - 1);
        CriateScene();
    }

    private void CriateScene()
    {
        Player = Instantiate(PrifabPlayer, StartPlayer.position, Quaternion.identity);
        Dog = Instantiate(PrifabDog, StratDog.position, Quaternion.identity);
    }

    private void DelScene()
    {
        if(RestartScene == false)
        {
            RestartScene = true;
            if (Player != null) Destroy(Player);
            if (Dog != null) Destroy(Dog);
            RestartScene = false;
        }    
    }

    private void NextLvl()
    {
        DelScene();
        CriateScene();
    }

    public void PigWin()
    {
        PigScore++; PigScoreText.text = "Pig Score " + (PigScore - 1);
        NextLvl();
    }

    public void DogWin()
    {
        DogScore++; DogScoreText.text = "Dog Score " + (DogScore - 1);
        NextLvl();
    }

    public void SetBomb()
    {
        Player.GetComponent<PlayerMovement>().SetBomb();
    }
}
