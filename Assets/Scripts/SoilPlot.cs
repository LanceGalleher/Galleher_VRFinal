using UnityEngine;

// handles planting and managing soil plots in the game
// detects when a seed object enters the trigger and then spawns a crop

public class SoilPlot : MonoBehaviour
{
    public GameObject cropPrefab;

    private bool planted = false;
    private CropGrowth currentCrop;

    private void OnTriggerEnter(Collider other)
    {
        if (planted) return;

        if (other.CompareTag("seed"))
        {
            planted = true;

            GameObject cropObj = Instantiate(
                cropPrefab,
                transform.position + Vector3.up * 0.5f,
                Quaternion.identity
            );

            currentCrop = cropObj.GetComponent<CropGrowth>();

            if (currentCrop != null)
            {
                currentCrop.SetSoil(this);
            }

            Destroy(other.gameObject);
        }
    }

    public void ClearPlot()
    {
        planted = false;
        currentCrop = null;

        Debug.Log("Soil reset - ready for new seed");
    }
}