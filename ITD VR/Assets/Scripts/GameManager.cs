using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Trigger Zones (assign in order: 1, 2, 3)")]
    public GameObject[] triggerZones;       

    [Header("Teleport Areas (assign in order: 1, 2)")]
    public GameObject[] teleportAreas;       

    [Header("Congrats UI")]
    public GameObject congratsCanvas;


    [Header("Storage Spaces (assign in order: 1, 2, 3)")]
    public GameObject[] storageSpaces;

    [Header("Keys (assign in order: 1, 2, 3)")]
    public GameObject[] keys;

    [Header("Assembly Platform")]
    public GameObject assemblyPlatform;

    [Header("Pedestal")]
    public GameObject pedestal;

    private int triggersCleared = 0;
    private int teleportsCleared = 0;
    private bool tutorialComplete = false;


    void Start()
    {
        // Disable all CA4 zones
        foreach (var zone in triggerZones)
            zone.SetActive(false);
        foreach (var area in teleportAreas)
            area.SetActive(false);
        if (congratsCanvas != null)
            congratsCanvas.SetActive(false);

        // Disable all CA5 objects until tutorial is complete
        foreach (var storage in storageSpaces)
            storage.SetActive(false);
        foreach (var key in keys)
            key.SetActive(false);
        if (assemblyPlatform != null)
            assemblyPlatform.SetActive(false);
        if (pedestal != null)
            pedestal.SetActive(false);

        // Start tutorial
        if (triggerZones.Length > 0)
            triggerZones[0].SetActive(true);

        Debug.Log("[Tutorial] Started. Walk into Trigger Zone 1.");
    }

    
    public void OnTriggerZoneCleared(int zoneIndex)
    {
        if (zoneIndex != triggersCleared) return; 

        triggersCleared++;
        Debug.Log($"[Tutorial] Trigger Zone {triggersCleared} cleared!");

        if (triggersCleared < triggerZones.Length)
        {
            triggerZones[triggersCleared].SetActive(true);
            Debug.Log($"[Tutorial] Walk into Trigger Zone {triggersCleared + 1}.");
        }
        else
        {
            Debug.Log("[Tutorial] All trigger zones cleared! Teleport areas unlocked.");
            if (teleportAreas.Length > 0)
                teleportAreas[0].SetActive(true);
        }
    }

    public void OnTeleportAreaCleared(int areaIndex)
    {
        if (areaIndex != teleportsCleared) return; 

        teleportsCleared++;
        Debug.Log($"[Tutorial] Teleport Area {teleportsCleared} cleared!");

        if (teleportsCleared < teleportAreas.Length)
        {
            teleportAreas[teleportsCleared].SetActive(true);
            Debug.Log($"[Tutorial] Teleport to Area {teleportsCleared + 1}.");
        }
        else
        {
            Debug.Log("[Tutorial] All done! Showing congrats UI.");
            ShowCongrats();
        }
    }

    private void ShowCongrats()
    {
        if (congratsCanvas != null)
            congratsCanvas.SetActive(true);

        Invoke(nameof(EnableCA5), 2f);
    }

    private void EnableCA5()
    {
        tutorialComplete = true;

        foreach (var storage in storageSpaces)
            storage.SetActive(true);
        foreach (var key in keys)
            key.SetActive(true);
        if (assemblyPlatform != null)
            assemblyPlatform.SetActive(true);
        Debug.Log("[CA5] Tutorial complete! Storage spaces and keys are now active.");
    }

    public void OnAssemblyComplete()
    {
        if (pedestal != null)
            pedestal.SetActive(true);

        Debug.Log("[CA5] Assembly complete! Grab the object and teleport it to the pedestal.");
    }
}
