using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CongratsUI : MonoBehaviour
{
    public Button closeButton;

    public bool spawnInFrontOfCamera = true;
    public float distanceFromCamera = 1.5f;

    private Transform cameraTransform;

    void OnEnable()
    {
        if (spawnInFrontOfCamera)
        {
            Camera cam = Camera.main;
            if (cam != null)
            {
                cameraTransform = cam.transform;
                transform.position = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
                transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
            }
        }

        if (closeButton == null)
            closeButton = GetComponentInChildren<Button>();

        if (closeButton != null)
            closeButton.onClick.AddListener(DismissMessage);
        else
            Debug.LogWarning("[CongratsUI] No close Button found! Add a Button child and assign it.");
    }

    void OnDisable()
    {
        if (closeButton != null)
            closeButton.onClick.RemoveListener(DismissMessage);
    }

    public void DismissMessage()
    {
        gameObject.SetActive(false);
        Debug.Log("[CongratsUI] Message dismissed.");
    }
}