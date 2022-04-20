using UnityEngine;
using TMPro;

public class StatisticsWriter : MonoBehaviour
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
        totalBuildings.text = Player.Instance.placedBuildings.ToKMB();
        towers.text = Player.Instance.placedTowers.ToKMB();
        amplifiers.text = Player.Instance.placedAmplifiers.ToKMB();
        lanterns.text = Player.Instance.placedTraps.ToKMB();
        traps.text = Player.Instance.placedLanterns.ToKMB();

        totalEnemies.text = Player.Instance.killedEnemies.ToKMB();
        normals.text = Player.Instance.killedTanks.ToKMB();
        tanks.text = Player.Instance.killedFasts.ToKMB();
        traps.text = Player.Instance.killedBosses.ToKMB();
        amplifiers.text = Player.Instance.killedNormals.ToKMB();

        totalGems.text = Player.Instance.gemsInserted.ToKMB();
        fireGems.text = Player.Instance.fireGemsInserted.ToKMB();
        iceGems.text = Player.Instance.iceGemsInserted.ToKMB();
        poisonGems.text = Player.Instance.poisonGemsInserted.ToKMB();
        lightningGems.text = Player.Instance.lightningGemsInserted.ToKMB();
        manaGems.text = Player.Instance.manaGemsInserted.ToKMB();
        vulnerabilityGems.text = Player.Instance.critGemsInserted.ToKMB();

    }
}
