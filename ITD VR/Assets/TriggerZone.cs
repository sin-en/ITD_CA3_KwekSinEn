using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public int zoneIndex = 0;

    public string playerTag = "Player";

    public Renderer zoneRenderer;
    public Color defaultColor = new Color(1f, 1f, 0f, 0.4f);   // yellow
    public Color clearedColor = new Color(0f, 1f, 0f, 0.4f);   // green

    private bool cleared = false;
    private GameManager gameManager;

    void Start()
    {
        // Make sure the collider is a trigger
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;

        // Find the GameManager in the scene
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError($"[TriggerZone {zoneIndex}] TutorialManager not found in scene!");

        // Set default visual color
        if (zoneRenderer != null)
            zoneRenderer.material.color = defaultColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cleared) return;
        if (!other.CompareTag(playerTag)) return;

        cleared = true;

        // Visual feedback
        if (zoneRenderer != null)
            zoneRenderer.material.color = clearedColor;

        Debug.Log($"[TriggerZone] Zone {zoneIndex + 1} entered by player.");

        // Notify GameManager
        if (gameManager != null)
            gameManager.OnTriggerZoneCleared(zoneIndex);
    }
}