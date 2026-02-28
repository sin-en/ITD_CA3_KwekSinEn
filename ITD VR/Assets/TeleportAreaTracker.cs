using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class TeleportAreaTracker : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Index of this area: 0 = Area 1, 1 = Area 2")]
    public int areaIndex = 0;

    [Header("Visual Feedback (optional)")]
    public Renderer areaRenderer;
    public Color defaultColor = new(0f, 0.5f, 1f, 0.4f);
    public Color clearedColor = new(0f, 1f, 0f, 0.4f);

    private bool cleared = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError($"[TeleportAreaTracker {areaIndex}] GameManager not found!");

        if (areaRenderer != null)
            areaRenderer.material.color = defaultColor;
    }

    /// <summary>
    /// Call this from the Inspector's Teleporting event (no parameters).
    /// Interactable Events > Teleport > Teleporting > TeleportAreaTracker > OnPlayerTeleported
    /// </summary>
    public void OnPlayerTeleported()
    {
        if (cleared) return;

        cleared = true;

        if (areaRenderer != null)
            areaRenderer.material.color = clearedColor;

        Debug.Log($"[TeleportAreaTracker] Area {areaIndex + 1} cleared.");

        if (gameManager != null)
            gameManager.OnTeleportAreaCleared(areaIndex);
    }
}