using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{



    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    public Animator LeftHandAnimator;
    public Animator RightHandAnimator;


    public Transform XRHead { get; set; }
    public Transform XRleftHand { get; set; }
    public Transform XRrightHand { get; set; }

    // Start is called before the first frame update
    void Start()
    {
       photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
    
        if (photonView.IsMine)
        {
            MapPosition();

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), LeftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), RightHandAnimator);
        }
      
        
    }
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    private void MapPosition()
    {
        head.position = XRHead.position;
        head.rotation = XRHead.rotation;

        leftHand.position = XRleftHand.position;
        leftHand.rotation = XRleftHand.rotation;

        rightHand.position = XRrightHand.position;
        rightHand.rotation = XRrightHand.rotation;
    }
}
