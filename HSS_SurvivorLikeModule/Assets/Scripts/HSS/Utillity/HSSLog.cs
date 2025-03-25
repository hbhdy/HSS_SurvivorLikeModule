using UnityEngine;

namespace HSS
{
    // �ߺ� �÷� �� �帴�� ���� ���� 
    public enum LogColor
    {
        none,
        //aqua,
        //black,
        blue,
        //brown,
        cyan,
        //darkblue,
        //fuchsia,
        green,
        //grey,
        lightblue,
        //lime,
        magenta,
        maroon,
        //navy,
        //olive,
        orange,
        purple,
        red,
        //silver,
        teal,
        white,
        yellow,
    }

    public static class HSSLog
    {
        [System.Diagnostics.Conditional("SHOW_LOG")]
        public static void Log(string log, LogColor color = LogColor.none)
        {
            if (color == LogColor.none)
                Debug.Log($"{log}");
            else
                Debug.Log($"<color={color}>{log}</color>");
        }

        [System.Diagnostics.Conditional("SHOW_LOG")]
        public static void LogWarning(string log, LogColor color = LogColor.none)
        {
            if (color == LogColor.none)
                Debug.LogWarning($"{log}");
            else
                Debug.LogWarning($"<color={color}>{log}</color>");
        }

        [System.Diagnostics.Conditional("SHOW_LOG")]
        public static void LogError(string log, LogColor color = LogColor.none)
        {
            if (color == LogColor.none)
                Debug.LogError($"{log}");
            else
                Debug.LogError($"<color={color}>{log}</color>");
        }
    }
}