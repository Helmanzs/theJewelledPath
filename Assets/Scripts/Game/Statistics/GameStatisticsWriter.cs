using UnityEngine;
using TMPro;

public class GameStatisticsWriter : MonoBehaviour
{
    [Header("Enemies")]

    public TextMeshProUGUI totalEnemies;
    public TextMeshProUGUI normals;
    public TextMeshProUGUI tanks;
    public TextMeshProUGUI sprinters;
    public TextMeshProUGUI bosses;

    [Header("Buildings")]

    public TextMeshProUGUI totalBuildings;
    public TextMeshProUGUI towers;
    public TextMeshProUGUI amplifiers;
    public TextMeshProUGUI lanterns;
    public TextMeshProUGUI traps;

    [Header("Gems")]

    public TextMeshProUGUI totalGems;
    public TextMeshProUGUI fireGems;
    public TextMeshProUGUI iceGems;
    public TextMeshProUGUI poisonGems;
    public TextMeshProUGUI lightningGems;
    public TextMeshProUGUI manaGems;
    public TextMeshProUGUI vulnerabilityGems;

    void Update()
    {
        FillText();
    }

    private void FillText()
    {
        totalBuildings.text = GameStatisticsData.Instance.PlacedBuildings.ToKMB();
        towers.text = GameStatisticsData.Instance.PlacedTowers.ToKMB();
        amplifiers.text = GameStatisticsData.Instance.PlacedAmplifiers.ToKMB();
        traps.text = GameStatisticsData.Instance.PlacedTraps.ToKMB();
        lanterns.text = GameStatisticsData.Instance.PlacedLanterns.ToKMB();

        totalEnemies.text = GameStatisticsData.Instance.KilledEnemies.ToKMB();
        tanks.text = GameStatisticsData.Instance.KilledTanks.ToKMB();
        sprinters.text = GameStatisticsData.Instance.KilledFasts.ToKMB();
        bosses.text = GameStatisticsData.Instance.KilledBosses.ToKMB();
        normals.text = GameStatisticsData.Instance.KilledNormals.ToKMB();

        totalGems.text = GameStatisticsData.Instance.GemsInserted.ToKMB();
        fireGems.text = GameStatisticsData.Instance.FireGemsInserted.ToKMB();
        iceGems.text = GameStatisticsData.Instance.IceGemsInserted.ToKMB();
        poisonGems.text = GameStatisticsData.Instance.PoisonGemsInserted.ToKMB();
        lightningGems.text = GameStatisticsData.Instance.LightningGemsInserted.ToKMB();
        manaGems.text = GameStatisticsData.Instance.ManaGemsInserted.ToKMB();
        vulnerabilityGems.text = GameStatisticsData.Instance.CritGemsInserted.ToKMB();

    }
}
