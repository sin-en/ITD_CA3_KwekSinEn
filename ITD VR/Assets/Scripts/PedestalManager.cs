using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PedestalManager : MonoBehaviour
{
    [Header("References")]
    public XRSocketInteractor pedestalSocket;
    public GameObject completionUI;

    private bool completed = false;

    void Start()
    {
        if (completionUI != null)
            completionUI.SetActive(false);
    }

    public void OnObjectPlaced()
    {
        if (completed) return;

        completed = true;

        Debug.Log("[PedestalManager] Assembled object placed on pedestal! Activity complete!");

        if (completionUI != null)
            completionUI.SetActive(true);
    }
}
