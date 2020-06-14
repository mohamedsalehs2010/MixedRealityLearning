using System.IO;
using UnityEngine;

#if WINDOWS_UWP
using Windows.Storage;
#endif

namespace MRTK.Tutorials.AzureCloudPower
{
    public class DebugMenu : MonoBehaviour
    {
        private AnchorManager anchorManager;

        private void Start()
        {
            anchorManager = FindObjectOfType<AnchorManager>();
        }

        public void SaveAzureAnchorIdToDisk()
        {
            Debug.Log("__\nAnchorManager.SaveAzureAnchorIDToDisk()");

            const string filename = "SavedAzureAnchorID.txt";
            var path = Application.persistentDataPath;

#if WINDOWS_UWP
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        path = storageFolder.Path.Replace('\\', '/') + "/";
#endif

            var filePath = Path.Combine(path, filename);
            File.WriteAllText(filePath, anchorManager.CurrentAzureAnchorId);

            Debug.Log(
                $"Current Azure anchor ID '{anchorManager.CurrentAzureAnchorId}' successfully saved to path '{filePath}'");
        }

        public void GetAzureAnchorIdFromDisk()
        {
            Debug.Log("__\nAnchorManager.LoadAzureAnchorIDFromDisk()");

            const string filename = "SavedAzureAnchorID.txt";
            var path = Application.persistentDataPath;

#if WINDOWS_UWP
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        path = storageFolder.Path.Replace('\\', '/') + "/";
#endif

            var filePath = Path.Combine(path, filename);
            var anchorId = File.ReadAllText(filePath);

            Debug.Log($"Azure anchor ID '{anchorManager.CurrentAzureAnchorId}' successfully loaded from path '{path}'");

            anchorManager.FindAnchor(anchorId);
        }
    }
}
