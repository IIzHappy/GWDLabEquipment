using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    public bool Active = true;

    private List<Rigidbody> GravityItems = new List<Rigidbody>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Rigidbody[] rbs = FindObjectsOfType<Rigidbody>();




        foreach (Rigidbody rb in rbs) {

            if (rb.useGravity) {

                GravityItems.Add(rb);
            
            }
        
        
        
        }



    }

    // Update is called once per frame
    void Update()
    {

        foreach (Rigidbody rb in GravityItems)
        {

           rb.useGravity = Active;
            


        }



    }
}
