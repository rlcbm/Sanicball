using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

namespace Sanicball.UI
{
    public class MatchListItem : MonoBehaviour
    {
        private NetworkMatch matchFinder;
        private MatchDesc data;

        public Text serverNameText;
        public Text serverStatusText;
        public Text playerCountText;
        public Text pingText;
        public Image pingLoadingImage;

        //TODO: Implement pinging matches
        //private bool pingDone = false;
        //private float pingTimeout = 8f;

        public void SetData(NetworkMatch matchFinder, MatchDesc data)
        {
            this.matchFinder = matchFinder;
            this.data = data;
            //info = new ServerInfo(data);
            serverNameText.text = data.name;
            serverStatusText.text = "(STATUS GOES HERE)";
            playerCountText.text = data.currentSize + "/" + data.maxSize;
        }

        public void Join()
        {
            Debug.Log("Joining match '" + serverNameText.text + "'");

            matchFinder.JoinMatch(data.networkId, string.Empty, OnJoined);
            //NetworkClient client = new NetworkClient();
            //client.RegisterHandler(MsgType.Connect, OnConnected);
        }

        private void OnJoined(JoinMatchResponse response)
        {
            if (response.success)
            {
                Debug.Log("Joined server");
            }
            else
            {
                Debug.Log("Failed to join server");
            }
        }

        private void OnConnected(NetworkMessage msg)
        {
            Debug.Log("Probably connected");
        }
    }
}