using UnityEngine;

public class RampMovement : MonoBehaviour
{

    public GameObject Ramp;

    public bool Active = true;

    [Range(-4f,10f)]
    public float ZLocation=0f;

    [Range(4.5f, 80f)]
    public float Angle = 45f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Active)
        {

            Ramp.SetActive(true);

        }

        else {

            Ramp.SetActive(false);

        }

        Vector3 Location = Ramp.transform.position;

        Location.z = ZLocation;

        Ramp.transform.position = Location;

       

        Vector3 Rotation = Ramp.transform.eulerAngles;
        Rotation.x = Angle;
        Ramp.transform.rotation = Quaternion.Euler(Rotation);


    }
}
