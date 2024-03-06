using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingSteak : MonoBehaviour
{
    [SerializeField] private MeshFilter filter;
    [SerializeField] private Mesh cookedMesh;
    [SerializeField] private Mesh trashMesh;
    [SerializeField] private GameObject particuleSystem;
    [SerializeField] private float elapsedTime = 3;

    private bool Cooking = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cooking)
        {
            TimerCooking();
        }
    }

    private void TimerCooking()
    {
        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
        }
        if (elapsedTime < 60)
        {
            filter.mesh = cookedMesh;
        }
        if (elapsedTime < 0)
        {
            particuleSystem.SetActive(true);
            filter.mesh = trashMesh;
            Cooking = false;
        }
    }
}
