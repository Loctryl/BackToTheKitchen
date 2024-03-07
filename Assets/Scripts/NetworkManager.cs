using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string RoomName;
    public int SceneIndex;
    public int MaxPlayer;
}
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public List<DefaultRoom> defaultRooms;
     public void ConnectedToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined lobby");
    }
    public void InitiallizeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSetting = defaultRooms[defaultRoomIndex];
        PhotonNetwork.LoadLevel(roomSetting.SceneIndex);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSetting.MaxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom(roomSetting.RoomName, roomOptions, TypedLobby.Default);
    }
            
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player entered room");
        base.OnPlayerEnteredRoom(newPlayer);
    }


}
