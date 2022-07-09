using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tooltip : MonoBehaviour
{
    public GameObject myCanvas;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        myCanvas.transform.position = Input.mousePosition + offset;
    }
}
