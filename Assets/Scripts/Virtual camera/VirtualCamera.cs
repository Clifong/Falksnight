using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    void Start()
    {
        GameObject player = GameObject.FindWithTag("MC");
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player.transform;
    }

}
