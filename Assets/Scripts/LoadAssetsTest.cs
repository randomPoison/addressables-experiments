using System.Collections.Generic;
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
                Debug.LogError("Failed to download all assets ;__;");
            }
        };

        Addressables.LoadAssetsAsync<Sprite>(
            new List<string>() {
                "adventurer-attack1-00",
                "adventurer-attack1-00",
                "adventurer-attack1-00",
                "adventurer-attack1-00",
                "adventurer-attack1-00",
            },
            null,
            Addressables.MergeMode.Union)
            .Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("Successfully loaded those sprites");
                }
                else
                {
                    Debug.LogError("The sprites didn't load good ;__;");
                }
            };
    }
}
