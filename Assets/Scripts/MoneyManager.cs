using UnityEngine;
using TMPro;

// handles tracking the player money and updates the UI with current total

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int money = 0;

    public TextMeshProUGUI moneyText;

    void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: $" + money;
        }
    }
}
