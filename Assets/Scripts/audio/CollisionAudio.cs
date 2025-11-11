using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    private AudioSource AudioSource;
    private Rigidbody rb;
    public AudioClip clip;
    public float pitchRandomness;
    public float basePitch;
    public float volumeMultiplier;
    public float sqrMagnitudeSoundMin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.pitch = basePitch + Random.Range(-pitchRandomness, pitchRandomness);
        AudioSource.PlayOneShot(clip, collision.relativeVelocity.magnitude * volumeMultiplier);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.relativeVelocity.sqrMagnitude >= sqrMagnitudeSoundMin)
        {
            AudioSource.pitch = basePitch + Random.Range(-pitchRandomness, pitchRandomness);
            AudioSource.PlayOneShot(clip, collision.relativeVelocity.magnitude * volumeMultiplier);
        }
    }
}
