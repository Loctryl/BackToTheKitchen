using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
       photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
 
            rightHand.gameObject.SetActive(true);
            leftHand.gameObject.SetActive(true);
            head.gameObject.SetActive(true);
            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
      
        
    }

    private void MapPosition(Transform Target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        Target.localRotation = rotation;
        Target.localPosition = position;
    }
}
