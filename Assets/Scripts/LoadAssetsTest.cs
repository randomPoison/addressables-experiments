using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssetsTest : MonoBehaviour
{
    public void Start()
    {
        var allKeys = Addressables
            .ResourceLocators
            .SelectMany(locator => locator.Keys);
        Addressables.DownloadDependenciesAsync(allKeys, Addressables.MergeMode.Union).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Successfully downloaded all assets!");
            }
            else
            {
                Debug.LogException(handle.OperationException);
            }
        };
    }
}
