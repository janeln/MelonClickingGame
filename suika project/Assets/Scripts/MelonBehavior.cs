using TMPro;
using UnityEngine;

public class MelonBehavior : MonoBehaviour
{
    // Melon physics component & split melon prefab
    [SerializeField] private GameObject halfMelon;
    Rigidbody rbMelon;

    // Particle system object (slice animation)
    [SerializeField] private GameObject sliceParticles;
    private GameObject slice;

    // Variables for orientation of split melon pieces -- edit in Inspector
    private Vector3 splitOffset = new Vector3(-0.15f, 0f, -1.5f);

    // Variables for behavior of split melon halves
    private GameObject leftHalf;
    private GameObject rightHalf;
    private Vector3 splitRotation = new Vector3(7f, 107f, 4f);


    private void Start()
    {
        // Fetch the Rigidbody from the GameObject with this script attached
        rbMelon = GetComponent<Rigidbody>();
        // Shoots up the melon from the bottom of the screen 
        rbMelon.AddForce(new Vector3(Random.Range(-3,3),16,0), ForceMode.Impulse);
    }

    void OnMouseDown()
    {
        // For testing purposes
        Debug.Log("Melon clicked");

        // Particles for slice animation play
        slice = Instantiate(sliceParticles, transform.position, transform.rotation);
        Destroy(slice, 1); // Animation has completed by 1 second later

        // Two half melons split and fall
        Destroy(gameObject);
        leftHalf = Instantiate(halfMelon, transform.position, transform.rotation);
        rightHalf = Instantiate(halfMelon, transform.position + splitOffset, transform.rotation);

        // Rotation of two split pieces
        leftHalf.transform.Rotate(splitRotation, Space.World);
        rightHalf.transform.Rotate(8f, -108f, 0f, Space.World);

        // Small jump when they split apart
        leftHalf.GetComponent<Rigidbody>().AddForce(new Vector3(1, 3, 0), ForceMode.Impulse);
        rightHalf.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 3, 0), ForceMode.Impulse);

        // Destroy splits after a while
        Destroy(leftHalf, 4);
        Destroy(rightHalf, 4);

        // Trigger points counter
        ScoreCounter.Instance.AddPoint();

        Debug.Log("OnMouseDown complete");
    }

    private void Update()
    {
        // Destroys instance of melon object after an arbitrary time by which it's fallen off-camera
        Destroy(gameObject, 5);

        // If colliders are on, change that number to something else!
    }
}
