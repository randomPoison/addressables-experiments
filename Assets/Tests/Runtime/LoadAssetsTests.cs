using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.TestTools;

namespace AddressablesTests
{
    public class LoadAssetsTests
    {
        [UnityTest]
        public IEnumerator LoadAssetAsync_Sprite()
        {
            var handle = Addressables.LoadAssetAsync<Sprite>("adventurer-attack1-00");
            yield return handle;
            Assert.AreEqual(AsyncOperationStatus.Succeeded, handle.Status);
        }

        [UnityTest]
        public IEnumerator LoadAssetAsync_Prefab()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>("Attack1-00");
            yield return handle;
            Assert.AreEqual(AsyncOperationStatus.Succeeded, handle.Status);
        }
    }
}
