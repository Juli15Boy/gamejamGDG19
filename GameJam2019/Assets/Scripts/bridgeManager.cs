using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeManager : MonoBehaviour
{
    public GameObject firstBridgeLog;
    public GameObject secondBridgeLog;
    public GameObject thirdBridgeLog;

    public void updateBridge(int droppedLogs)
    {
        switch (droppedLogs)
        {
            case 1:
                firstBridgeLog.SetActive(true);
                break;

            case 2:
                secondBridgeLog.SetActive(true);
                break;

            case 3:
                thirdBridgeLog.SetActive(true);
                break;
        }
    }
}
