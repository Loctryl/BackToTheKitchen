using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DirtyPlate : MonoBehaviour
{
    [SerializeField] private float elapsedTime = 30;
    [SerializeField] private Slider slider;
    [SerializeField] private MeshFilter filter;
    [SerializeField] private Mesh cleandishes;
    [SerializeField] private Image sliderFill;
    [SerializeField] private GameObject particuleSystem;

    private bool InTheSink = false;
    private GameObject player;
    private float maxElapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        maxElapsedTime = elapsedTime;
        player = GameObject.FindGameObjectWithTag("Player");
        slider.maxValue = elapsedTime;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
        slider.value = elapsedTime;
        sliderFill.color = Color.Lerp(Color.red, Color.green, slider.value / maxElapsedTime);

        if (InTheSink)
        {
            elapsedTime -= Time.deltaTime;
        }
        if (elapsedTime < 0)
        {
            particuleSystem.SetActive(true);
            filter.mesh = cleandishes;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            InTheSink = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            InTheSink = false;
        }
    }
}