using UnityEngine;

// handles crop growth, growth timer, and harvesting logic used by CropHarvestTrigger
// Controls the visual stage of a crops growth

public class CropGrowth : MonoBehaviour
{
    public GameObject[] growthStages;
    public SoilPlot plot;

    public float timeBetweenStages = 5f;

    public GameObject harvestItemPrefab;
    public Transform harvestSpawnPoint;

    private int currentStage = 0;
    private float timer = 0f;

    public bool readyToHarvest = false;

    private SoilPlot soil;

    void Start()
    {
        UpdateStage();
    }

    void Update()
    {
        Grow();
    }

    void Grow()
    {
        if (readyToHarvest) return;

        timer += Time.deltaTime;

        if (timer >= timeBetweenStages)
        {
            timer = 0f;
            currentStage++;

            if (currentStage >= growthStages.Length - 1)
            {
                currentStage = growthStages.Length - 1;
                readyToHarvest = true;

                Debug.Log("Crop Ready To Harvest!");
            }

            UpdateStage();
        }
    }

    void UpdateStage()
    {
        for (int i = 0; i < growthStages.Length; i++)
        {
            growthStages[i].SetActive(i == currentStage);
        }
    }

    public void Harvest()
    {
        Debug.Log("HARVESTED");

        Instantiate(
            harvestItemPrefab,
            harvestSpawnPoint.position,
            Quaternion.identity
        );

        if (soil != null)
        {
            soil.ClearPlot();
        }

        Destroy(gameObject);
    }

    public void SetSoil(SoilPlot plot)
    {
        soil = plot;
    }
}