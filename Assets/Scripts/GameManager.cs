using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // make game manager public static so can access this from other scripts
    public static GameManager gm;

    // public variables
    public int score = 0;
    public int health = 100;

    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public float startTime = 5.0f;

    public Text mainScoreDisplay;
    public Text healthDisplay;
    public Text mainTimerDisplay;

    public GameObject gameOverScoreOutline;

    public AudioSource musicAudioSource;

    public bool gameIsOver = false;

    public GameObject exitButton;

    public GameObject playAgainButtons;
    public string playAgainLevelToLoad;

    public GameObject restartButtons;
    public string restartLevelToLoad;

    public GameObject nextLevelButtons;
    public string nextLevelToLoad;

    private float currentTime;



    // Use this for initialization
    void Start () {

        currentTime = startTime;

        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();

        // init scoreboard to 0
        mainScoreDisplay.text = "0";

        // inactivate the gameOverScoreOutline gameObject, if it is set
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(false);

        // inactivate the playAgainButtons gameObject, if it is set
        if (playAgainButtons)
            playAgainButtons.SetActive(false);

        // inactivate the nextLevelButtons gameObject, if it is set
        if (nextLevelButtons)
            nextLevelButtons.SetActive(false);

        if (exitButton)
            exitButton.SetActive(false);

        if (restartButtons)
            restartButtons.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (!gameIsOver)
        {
            if (canBeatLevel && (score >= beatLevelScore))
            {  // check to see if beat game
                BeatLevel();
            }
            else if (currentTime < 0)
            { // check to see if timer has run out
                EndGame();
            }
            else if (health < 1)
            {
                EndGame();
            }
            else
            { // game playing state, so update the timer
                currentTime -= Time.deltaTime;
                mainTimerDisplay.text = currentTime.ToString("0.00");
            }
            
        }

    }
    void EndGame()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "GAME OVER";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // activate the playAgainButtons gameObject, if it is set 
        if (playAgainButtons)
            playAgainButtons.SetActive(true);

        if (restartButtons)
            restartButtons.SetActive(true);

        if (exitButton)
            exitButton.SetActive(true);

        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    }

    void BeatLevel()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "LEVEL COMPLETE";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);
        if (playAgainButtons)
            playAgainButtons.SetActive(true);

        if (restartButtons)
            restartButtons.SetActive(true);

        if (exitButton)
            exitButton.SetActive(true);


        // activate the nextLevelButtons gameObject, if it is set 
        if (nextLevelButtons)
            nextLevelButtons.SetActive(true);

        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    }

    public void damagehit(int damageAmount)
    {
        
            health = health - damageAmount;
        if (health > 100) {
            int rem = health % 100;
            health = health - rem;
        }
        healthDisplay.text = health.ToString();

    }

    // public function that can be called to update the score or time
        public void targetHit(int scoreAmount, float timeAmount)
    {
        // increase the score by the scoreAmount and update the text UI
        score += scoreAmount;
        mainScoreDisplay.text = score.ToString();

        // increase the time by the timeAmount
        currentTime += timeAmount;
        if(currentTime>90)
        {
            float rem = currentTime % 90;
            currentTime = currentTime - rem;
        }

        // don't let it go negative
        if (currentTime < 0)
            currentTime = 0.0f;

        // update the text UI
        mainTimerDisplay.text = currentTime.ToString("0.00");
    }

    
    // public function that can be called to restart the game
    public void RestartGame()
    {
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        //Application.LoadLevel(playAgainLevelToLoad);
    }
    public void RestartGamefromStart()
    {
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        //Application.LoadLevel(restartLevelToLoad);
    }

    // public function that can be called to go to the next level of the game
    public void NextLevel()
    {
        // we are just loading the specified next level (scene)
        //Application.LoadLevel(nextLevelToLoad);
    }
}
