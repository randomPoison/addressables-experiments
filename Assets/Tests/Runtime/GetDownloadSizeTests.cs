using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.TestTools;

namespace AddressablesTests
{
    public class GetDownloadSizeTests
    {
        public static string[] TestCases => new string[]
        {
            // Scene asset.
            "SceneAsset",

            // Asset in `Resources`, referenced by address.
            "PrefabInResources",

            // Asset in `Resources`, referenced by GUID.
            "cb8d7e174dbc6fd4dbb7605dfcfb1e3b",

            // Standard prefab (i.e. not in `Resources`), referenced by GUID.
            "508a4633b1103e14fa86f384651b5771",
        };

        [UnityTest]
        public IEnumerator GetDownloadSize(
            [ValueSource(nameof(TestCases))]
            string address)
        {
            var handle = Addressables.GetDownloadSizeAsync(address);
            yield return handle;
            Assert.AreEqual(AsyncOperationStatus.Succeeded, handle.Status, handle.OperationException?.ToString());
        }

        [UnityTest]
        public IEnumerator GetDownloadSize_AllKeys()
        {
            yield return Addressables.InitializeAsync();
            var allKeys = Addressables
                .ResourceLocators
                .SelectMany(locator => locator.Keys);

            var handle = Addressables.GetDownloadSizeAsync(allKeys);
            yield return handle;
            Assert.AreEqual(AsyncOperationStatus.Succeeded, handle.Status, handle.OperationException?.ToString());
        }
    }
}
