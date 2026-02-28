using UnityEngine;
using UnityEngine.UI;

public class CompletionUI : MonoBehaviour
{
    [Header("References")]
    public Button closeButton;

    [Header("Positioning")]
    public bool spawnInFrontOfCamera = true;
    public float distanceFromCamera = 1.5f;

    void OnEnable()
    {
        if (spawnInFrontOfCamera)
        {
            Camera cam = Camera.main;
            if (cam != null)
            {
                Vector3 spawnPos = cam.transform.position + cam.transform.forward * distanceFromCamera;
                transform.position = spawnPos;
                transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
            }
        }

        if (closeButton == null)
            closeButton = GetComponentInChildren<Button>();

        if (closeButton != null)
            closeButton.onClick.AddListener(Dismiss);
        else
            Debug.LogWarning("[CompletionUI] No close Button found!");
    }

    void OnDisable()
    {
        if (closeButton != null)
            closeButton.onClick.RemoveListener(Dismiss);
    }

    public void Dismiss()
    {
        gameObject.SetActive(false);
        Debug.Log("[CompletionUI] Dismissed.");
    }
}