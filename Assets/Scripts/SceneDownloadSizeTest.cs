using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneDownloadSizeTest : MonoBehaviour
{
    void Start()
    {
        Addressables.GetDownloadSizeAsync("CancelLoadTest").Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"Download size: {handle.Result}");
            }
            else
            {
                Debug.LogError($"Failed to get download size: {handle.OperationException}");
            }
        };
    }
}
