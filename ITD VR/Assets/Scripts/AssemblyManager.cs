using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AssemblyManager : MonoBehaviour
{
    [Header("Assembly Sockets (assign all 3)")]
    public XRSocketInteractor[] assemblySockets;

    [Header("Assembled Object")]
    public GameObject assembledObject;

    private int partsPlaced = 0;
    private bool assemblyComplete = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError("[AssemblyManager] GameManager not found!");

        if (assembledObject != null)
            assembledObject.SetActive(false);
    }

    public void OnPartPlaced()
    {
        if (assemblyComplete) return;

        partsPlaced++;
        Debug.Log($"[AssemblyManager] Part {partsPlaced}/{assemblySockets.Length} placed.");

        if (partsPlaced >= assemblySockets.Length)
        {
            assemblyComplete = true;
            Debug.Log("[AssemblyManager] All parts assembled!");

            foreach (XRSocketInteractor socket in assemblySockets)
            {
                var socketed = socket.GetOldestInteractableSelected();
                if (socketed != null)
                    socketed.transform.gameObject.SetActive(false); // hides the placed part

                socket.gameObject.SetActive(false); // disables the socket too
            }

            if (assembledObject != null)
                assembledObject.SetActive(true);

            if (gameManager != null)
                gameManager.OnAssemblyComplete();
        }
    }
}