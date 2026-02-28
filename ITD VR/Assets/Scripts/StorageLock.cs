using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class StorageLock : MonoBehaviour
{
    public XRSocketInteractor keySocket;
    public GameObject storedItem;
    public GameObject chestTop;
    private bool unlocked = false;

    void Start()
    {
        if (storedItem != null)
            storedItem.SetActive(false);
    }

    public void OnKeyInserted()
    {
        if (unlocked) return;
        unlocked = true;
        Debug.Log($"[StorageLock] {gameObject.name} unlocked!");
        if (storedItem != null)
            storedItem.SetActive(true);
        if (chestTop != null)
            chestTop.SetActive(false);
    }
}
