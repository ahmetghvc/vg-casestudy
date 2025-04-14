using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentManager : MonoBehaviour
{
    // REFERENCES
    [Header("SCOPES")]
    
    [SerializeField] GameObject[] scope1;
    [SerializeField] GameObject[] scope2;
    [SerializeField] GameObject[] scope3;

    [Space(5)]

    [Header("MAGAZINES")]
    [SerializeField] GameObject[] mags1;
    [SerializeField] GameObject[] mags2;
    [SerializeField] GameObject[] mags3;
    [SerializeField] GameObject[] mags4;
    [SerializeField] GameObject[] mags5;

    [Space(5)]

    [Header("BARRELS")]
    [SerializeField] GameObject[] barrels1;
    [SerializeField] GameObject[] barrels2;
    [SerializeField] GameObject[] barrels3;

    [Space(5)]

    [Header("TACTICALS")]
    [SerializeField] GameObject[] tactical1;
    [SerializeField] GameObject[] tactical2;

    [Space(5)]

    [Header("STOCKS")]
    [SerializeField] GameObject[] stock1;
    [SerializeField] GameObject[] stock2;


    //PARAM


    //STATE


    //METHODS


    //INPUT






    //DEBUG METHODS
    [ContextMenu("Debug Scopes")]
    void DebugIt()
    {
       
        

        foreach (GameObject item in scope1)
        {
            Debug.Log(item.name);
        }

    }

    [ContextMenu("Show Attach")]
    void HideAttachment()
    {
        
     foreach (GameObject item in mags5)
     {
        item.gameObject.SetActive(true);
     }

    }

    [ContextMenu("Hide Attach")]
    void ShowAttachment()
    {
        foreach (GameObject item in mags5)
        {
            item.gameObject.SetActive(false);
            
        }
    }





}
