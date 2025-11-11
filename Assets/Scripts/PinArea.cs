using UnityEngine;

public class PinArea : MonoBehaviour
{
    public bool IsInsideZone(Collider col)
    {
        return col.bounds.Intersects(GetComponent<Collider>().bounds);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawCube(transform.position, GetComponent<Collider>().bounds.size);
    }
}
