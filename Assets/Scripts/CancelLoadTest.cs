// Experiments testing what happens if you release an `AsyncOperationHandle` before the
// underlying operation completes. In both cases Addressables seems to handle the early
// release just fine, and doesn't leak memory or game objects.

using UnityEngine;
using UnityEngine.AddressableAssets;

public class CancelLoadTest : MonoBehaviour
{
    void Start()
    {
        {
            var handle = Addressables.InstantiateAsync("Attack1-00");
            Debug.Log($"Status: {handle.Status}");
            Addressables.ReleaseInstance(handle);
        }

        {
            var handle = Addressables.LoadAssetAsync<Sprite>("adventurer-attack1-00");
            Debug.Log($"Status: {handle.Status}");
            Addressables.Release(handle);
        }
    }
}
