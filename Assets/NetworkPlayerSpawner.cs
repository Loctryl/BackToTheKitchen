using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public GameObject player;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();   
        player = PhotonNetwork.Instantiate(player.name,transform.position,transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}
