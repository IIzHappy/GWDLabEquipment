using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    private AudioSource AudioSource;
    private Rigidbody rb;
    private AudioListener Listener;
    public AudioClip clip;
    public float pitchRandomness;
    public float basePitch;
    public float volumeMultiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Listener = FindFirstObjectByType<AudioListener>();
        rb = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.pitch = basePitch + Random.Range(-pitchRandomness, pitchRandomness);
        AudioSource.PlayOneShot(clip, collision.relativeVelocity.magnitude * volumeMultiplier);
    }
}
