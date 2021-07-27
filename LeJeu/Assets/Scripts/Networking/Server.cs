
using UnityEngine;
using LiteNetLib;


public class Server : MonoBehaviour
{
    EventBasedNetListener netListener;
    NetManager netManager;

    void Start()
    {
        Debug.Log("starting server");
        netListener = new EventBasedNetListener();

        netListener.ConnectionRequestEvent += (request) => {
            request.Accept();
        };

        netListener.PeerConnectedEvent += (client) => {
            Debug.Log($"Client connected: {client}");
        };

        netManager = new NetManager(netListener);
        netManager.Start(9050);
    }

    void Update()
    {
        netManager.PollEvents();
    }



}
