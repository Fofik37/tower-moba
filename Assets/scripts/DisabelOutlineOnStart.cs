using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabelOutlineOnStart : MonoBehaviour
{
    private float delay = 0.01f;
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        Invoke("DisabelOutline", delay);
    }

    // Update is called once per frame
    private void DisabelOutline()
    {
        outline.enabled = false;
    }

}
