using UnityEngine;

public class PinArea : MonoBehaviour
{
    public static PinArea Instance;
    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public bool IsInsideZone(Collider col)
    {
        return col.bounds.Intersects(GetComponent<Collider>().bounds);
    }
}
