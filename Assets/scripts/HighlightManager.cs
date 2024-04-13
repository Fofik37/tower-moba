using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightManager : MonoBehaviour
{
    private Transform highlightedObject;
    private Transform selecterObject;
    public LayerMask selectableLayer;

    private Outline highlightOutline;
    private RaycastHit hit;



    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        HoverHighlight();
    }
    public void HoverHighlight()
    {
        if(highlightedObject != null)
        {
            highlightOutline.enabled = false;
            highlightedObject = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit, selectableLayer))
        {
            highlightedObject = hit.transform;

            if (highlightedObject.CompareTag("Enemy") && highlightedObject != selecterObject)
            {
                highlightOutline = highlightOutline.GetComponent<Outline>();
                highlightOutline.enabled = true;
            }
            else
            {
                highlightedObject = null;
            }
        }

    }

    public void SelectedHighlight()
    {
        if (highlightedObject.CompareTag("Enemy"))
        {
            if (selecterObject != null)
            {
                selecterObject.GetComponent<Outline>().enabled = false;
            }

            selecterObject = hit.transform; 
            selecterObject.GetComponent<Outline>().enabled = true;

            highlightOutline.enabled = true;
            highlightedObject = null;

        }
    }

    public void DeselectHighlight()
    {
        selecterObject.GetComponent<Outline>().enabled = false;
        selecterObject = null;
    }

}
