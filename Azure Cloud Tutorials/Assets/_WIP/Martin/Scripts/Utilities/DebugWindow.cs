﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MRTK.Tutorials.AzureCloudPower
{
    public class DebugWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI debugText;

        private ScrollRect scrollRect;

        private void Start()
        {
            scrollRect = GetComponentInChildren<ScrollRect>();

            Application.logMessageReceived += HandleLog;

            debugText.text = "Debug messages will appear here.\n\n";
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void HandleLog(string message, string stackTrace, LogType type)
        {
            debugText.text += message + " \n";
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0;
        }
    }
}
