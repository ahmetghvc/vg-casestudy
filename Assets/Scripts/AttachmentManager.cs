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
    private Dictionary<string, GameObject[]> attachments;






    //PROCESS
    private Dictionary<string, GameObject[]> attachmentGroups;

    void Start()
    {
        attachmentGroups = new Dictionary<string, GameObject[]>
    {
        { "scope1", scope1 },
        { "scope2", scope2 },
        { "scope3", scope3 },
        { "mags1", mags1 },
        { "mags2", mags2 },
        { "mags3", mags3 },
        { "mags4", mags4 },
        { "mags5", mags5 },
        { "barrels1", barrels1 },
        { "barrels2", barrels2 },
        { "barrels3", barrels3 },
        { "tactical1", tactical1 },
        { "tactical2", tactical2 },
        { "stock1", stock1 },
        { "stock2", stock2 }

    };
    }


    //INPUT


    //METHODS
    public void ToggleAttachment(string name)
    {
        if (attachmentGroups.TryGetValue(name, out GameObject[] objects))
        {
            foreach (GameObject go in objects)
            {
                if (go != null)
                    go.SetActive(true);
            }
  
        }

    }


    public void HideAttachment(string name)
    {
        if (attachmentGroups.TryGetValue(name, out GameObject[] objects))
        {
            foreach (GameObject go in objects)
            {
                if (go != null)
                    go.SetActive(false);
            }


        }

    }


    //DEBUG METHODS











}
