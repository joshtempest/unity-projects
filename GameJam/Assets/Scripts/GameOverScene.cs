using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public static int totalDays; //The total amount of days that the player has been through
    public static float totalEarnings; //The total amount of earnings that the player has earned
    public TextMeshProUGUI totalDaysText; //The text that shows the total amount of days
    public TextMeshProUGUI totalEarningsText; //The text that shows the total amount of earnings

    private void Start()
    {
        totalDaysText.text = "Total days: " + totalDays; //Sets the totalDaysText
        totalEarningsText.text = "Total earnings: " + totalEarnings; //Sets the totalEarningsText
        Time.timeScale = 1; //Makes sure time runs
    }

    //Loads the scene named "StartScene" in order to play again
    public void PlayAgain()
    {
        SceneManager.LoadScene("StartScene");
    }
}
