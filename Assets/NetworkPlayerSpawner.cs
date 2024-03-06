using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public GameObject player;

    [SerializeField] Transform _cam;
    [SerializeField] Transform _leftHand;
    [SerializeField] Transform _rightHand;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();   
        player = PhotonNetwork.Instantiate(player.name,transform.position,transform.rotation);

        player.GetComponent<NetworkPlayer>().XRHead = _cam;
        player.GetComponent<NetworkPlayer>().XRleftHand = _leftHand;
        player.GetComponent<NetworkPlayer>().XRrightHand = _rightHand;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}
