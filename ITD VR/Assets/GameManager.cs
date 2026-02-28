using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Trigger Zones (assign in order: 1, 2, 3)")]
    public GameObject[] triggerZones;        // 3 TriggerZone GameObjects

    [Header("Teleport Areas (assign in order: 1, 2)")]
    public GameObject[] teleportAreas;       // 2 TeleportArea GameObjects

    [Header("Congrats UI")]
    public GameObject congratsCanvas;        // The World Space Canvas

    // Internal tracking
    private int triggersCleared = 0;
    private int teleportsCleared = 0;

    void Start()
    {
        // Disable all zones/areas at start
        for (int i = 0; i < triggerZones.Length; i++)
            triggerZones[i].SetActive(false);

        for (int i = 0; i < teleportAreas.Length; i++)
            teleportAreas[i].SetActive(false);

        if (congratsCanvas != null)
            congratsCanvas.SetActive(false);

        // Enable only the first trigger zone
        if (triggerZones.Length > 0)
            triggerZones[0].SetActive(true);

        Debug.Log("[Tutorial] Started. Walk into Trigger Zone 1.");
    }

    /// <summary>
    /// Called by TriggerZone script when the player enters a zone.
    /// </summary>
    public void OnTriggerZoneCleared(int zoneIndex)
    {
        if (zoneIndex != triggersCleared) return; // ignore if out of order

        triggersCleared++;
        Debug.Log($"[Tutorial] Trigger Zone {triggersCleared} cleared!");

        if (triggersCleared < triggerZones.Length)
        {
            // Enable next trigger zone
            triggerZones[triggersCleared].SetActive(true);
            Debug.Log($"[Tutorial] Walk into Trigger Zone {triggersCleared + 1}.");
        }
        else
        {
            // All trigger zones done — enable first teleport area
            Debug.Log("[Tutorial] All trigger zones cleared! Teleport areas unlocked.");
            if (teleportAreas.Length > 0)
                teleportAreas[0].SetActive(true);
        }
    }

    /// <summary>
    /// Called by TeleportAreaTracker script when the player teleports to an area.
    /// </summary>
    public void OnTeleportAreaCleared(int areaIndex)
    {
        if (areaIndex != teleportsCleared) return; // ignore if out of order

        teleportsCleared++;
        Debug.Log($"[Tutorial] Teleport Area {teleportsCleared} cleared!");

        if (teleportsCleared < teleportAreas.Length)
        {
            // Enable next teleport area
            teleportAreas[teleportsCleared].SetActive(true);
            Debug.Log($"[Tutorial] Teleport to Area {teleportsCleared + 1}.");
        }
        else
        {
            // All teleports done — show congrats!
            Debug.Log("[Tutorial] All done! Showing congrats UI.");
            ShowCongrats();
        }
    }

    private void ShowCongrats()
    {
        if (congratsCanvas != null)
            congratsCanvas.SetActive(true);
    }
}
