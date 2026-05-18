using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// manages end of day sequence
// tracks the overall earnings, listens for when the night starts, and then displays the end game panel

public class EndDayManager : MonoBehaviour
{
    public GameObject endDayPanel;
    public TextMeshProUGUI moneyText;

    private int totalMoney;
    private int cropsSold;

    private bool ended = false;

    void OnEnable()
    {
        TimeController.OnNightStarted += EndDay;
    }

    void OnDisable()
    {
        TimeController.OnNightStarted -= EndDay;
    }

    public void AddSale(int money)
    {
        totalMoney += money;
        cropsSold++;
    }

    void EndDay()
    {
        if (ended) return;

        ended = true;

        Debug.Log("END DAY TRIGGERED");

        Time.timeScale = 0f;

        if (endDayPanel != null)
            endDayPanel.SetActive(true);

        if (moneyText != null)
            moneyText.text = "Money Earned: $" + totalMoney;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
        }
}
