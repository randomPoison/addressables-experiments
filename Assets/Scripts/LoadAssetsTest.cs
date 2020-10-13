using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssetsTest : MonoBehaviour
{
    public void Start()
    {
        Addressables.LoadAssetAsync<Sprite>("adventurer-attack1-00").Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Sprite loaded successfully!");
            }
            else
            {
                Debug.LogError("The sprite didn't load good ;__;");
            }
        };

        Addressables.LoadAssetAsync<GameObject>("Attack1-00").Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Prefab loaded successfully!");
            }
            else
            {
                Debug.LogError("The prefab didn't load good ;__;");
            }
        };
    }
}
