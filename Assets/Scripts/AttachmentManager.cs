using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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
    bool x = false;

    //STATE


    //METHODS


    //INPUT






    //DEBUG METHODS

    IEnumerator Switcher()
    {

        
        //yield return new WaitForEndOfFrame();
        
        yield return null;
        x = !x;

    }

    [ContextMenu("Debug Scopes")]
    void DebugIt()
    {
       
        

        foreach (GameObject item in scope1)
        {
            Debug.Log(item.name);
        }

    }

    
    public void HandleScope1()
    {
        
        if (!x)
        {
            ShowScope1();
        }
        if (x)
        {
            HideScope1();
        }

        HideScope2 ();
    }

    public void HandleScope2()
    {

        if (!x)
        {
            ShowScope2();
        }
        if (x)
        {
            HideScope2();
        }

        HideScope1 ();
    }

    private void HideScope2()
    {
        foreach (GameObject item in scope2)
        {
            item.SetActive(false);
        }

        StartCoroutine(Switcher());
    }

    private void ShowScope2()
    {
        foreach (GameObject item in scope2)
        {
            item.SetActive(true);
        }

        StartCoroutine(Switcher());
    }

    private void HideScope1()
    {
        foreach (GameObject item in scope1)
        {
            item.SetActive(false);
        }

        StartCoroutine(Switcher());
    }

    private void ShowScope1()
    {
        foreach (GameObject item in scope1)
        {
            item.SetActive(true);
        }

        StartCoroutine(Switcher());
    }

    







}
