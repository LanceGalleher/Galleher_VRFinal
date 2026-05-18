using UnityEngine;

// detects when the player enters the harvest trigger area and triggers the ability to harvest a crop if it is ready to be harvested

public class CropHarvestTrigger : MonoBehaviour
{
    private CropGrowth crop;

    void Start()
    {
        crop = GetComponentInParent<CropGrowth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crop == null) return;

        if (!crop.readyToHarvest) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER TRIGGERED HARVEST");
            crop.Harvest();
        }
    }
}
