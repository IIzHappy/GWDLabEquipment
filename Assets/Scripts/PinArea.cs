using UnityEngine;

public class PinArea : MonoBehaviour
{
    public bool IsInsideZone(Collider col)
    {
        return col.bounds.Intersects(GetComponent<Collider>().bounds);
    }
}
