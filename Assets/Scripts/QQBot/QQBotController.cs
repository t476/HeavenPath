using UnityEngine;

public class QQBotController : MonoBehaviour
{
    protected ConfigFile config;
    protected string logStr = "";
    protected bool logMessage = true;

    public void AddLog(string str)
    {
        if (!logMessage) return;
        if (str.Length > 100) str = str.Substring(0, 100) + "...";
        logStr += str + "\n";
        if (logStr.Length > 22 * 1024)
        {
            logStr = logStr.Substring(logStr.Length - 22 * 1024);
        }
        Debug.Log(logStr);
        ClearLog();
    }

    public void ClearLog()
    {
        logStr = "";
    }
}