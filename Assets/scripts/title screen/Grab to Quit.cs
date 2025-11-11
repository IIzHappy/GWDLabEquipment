using UnityEngine;
using System.Collections;

public class GrabtoQuit : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {

            Application.Quit();
        

    }

   
}
