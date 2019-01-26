using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
    public bool right, left, leftHand, rightHand, isLeftGrabbed, isRightGrabbed;
    public Hand leftHandRef, rightHandRef;
    public float scrollSpeed = -1.5f;
    public List<int> remoteUsers;
    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }
    private void OnConnect(int device_id)
    {
        //Log to on-screen Console
        remoteUsers.Add(device_id);
        sendMessageToDevices();
       

    }

    void OnDisconnect(int device_id)
    {
        remoteUsers.Remove(device_id);
        sendMessageToDevices();
    }


    private void OnMessage(int DeviceID, JToken data)
    {
        leftHand |= (string)data == "leftHand";
        rightHand |= (string)data == "rightHand";
        isLeftGrabbed |= !leftHand;
        isRightGrabbed |= !leftHand;
        if ((string)data == "leftHandEnd")
        {
            leftHand = false;
            leftHandRef.BroadcastMessage("HandEnd");
        }
        if ((string)data == "rightHandEnd")
        {
            rightHand = false;
            rightHandRef.BroadcastMessage("HandEnd");
        }

        left |= (string)data == "leftBody";
        right |= (string)data == "rightBody";
        left &= (string)data != "leftBodyEnd";
        right &= (string)data != "rightBodyEnd";
    }

    void Start()
    {
    
        isLeftGrabbed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(remoteUsers.Count == 0)
        {
        
        right = left = leftHand = rightHand = false;
            left |= Input.GetKey("a");
            right |= Input.GetKey("d");
            leftHand |= Input.GetKey("k");
            rightHand |= Input.GetKey("l");
            if (Input.GetKeyUp("k"))
            {
                leftHandRef.BroadcastMessage("HandEnd");
            }
            if (Input.GetKeyUp("l"))
            {
                rightHandRef.BroadcastMessage("HandEnd");
            }
        }
    }
    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
            AirConsole.instance.onConnect -= OnConnect;
            AirConsole.instance.onDisconnect -= OnDisconnect;

        }
    }
    private void sendMessageToDevices()
    {
        List<int> ids = AirConsole.instance.GetControllerDeviceIds();
        foreach(int id in ids)
        {
            Dictionary<string, int> obj = new Dictionary<string, int>();
            obj.Add("index", ids.IndexOf(id));
            obj.Add("count", ids.Count);
            AirConsole.instance.Message(id, Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
       
    }
}
