using UnityEngine;

// handles selling of crops when they enter the sell bin trigger
// each crop type has a different value and it accounts for that
// adds to the money total depending on what crop is sold

public class SellBin : MonoBehaviour
{
    public int tomatoValue = 5;
    public int carrotValue = 2;
    public int cornValue = 8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tomato"))
        {
            MoneyManager.Instance.AddMoney(tomatoValue);

            Destroy(other.gameObject);

            Debug.Log("Sold Tomato!");
        }

        if (other.CompareTag("Carrot"))
        {
            MoneyManager.Instance.AddMoney(carrotValue);

            Destroy(other.gameObject);

            Debug.Log("Sold Carrot!");
        }

        if (other.CompareTag("Corn"))
        {
            MoneyManager.Instance.AddMoney(cornValue);

            Destroy(other.gameObject);

            Debug.Log("Sold Corn!");
        }
    }
}
