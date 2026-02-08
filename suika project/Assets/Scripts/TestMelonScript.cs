using System.Threading;
using UnityEngine;

public class TestMelonScript : MonoBehaviour
{
    [SerializeField] private GameObject fullMelon; // This is our test melon!
    [SerializeField] private GameObject halfMelon;

    // Particle system (slice animation)
    [SerializeField] private GameObject sliceParticles;

    // Variables for orientation of split melon pieces -- edit in Inspector
    private Vector3 splitOffset = new Vector3(-0.15f, 0f, -1.5f);

    // Variables for behavior of split melon halves
    private GameObject leftHalf;
    private GameObject rightHalf;
    private Vector3 splitRotation = new Vector3(7f, 107f, 4f);


    private void Start() 
    {
        // Shooting function would be here in the original melon script
    }

    void OnMouseDown()
    {
        // For testing purposes
        Debug.Log("Melon clicked");

        // Particles for slice animation play
        Instantiate(sliceParticles, transform.position, transform.rotation);
        Destroy(sliceParticles, 1); // Animation has completed by 1 second later

        // Two half melons split and fall
        Destroy(gameObject);
        leftHalf = Instantiate(halfMelon, transform.position, transform.rotation);
        rightHalf = Instantiate(halfMelon, transform.position + splitOffset, transform.rotation);

        // Rotation of two split pieces
        leftHalf.transform.Rotate(splitRotation, Space.World);
        rightHalf.transform.Rotate(8f, -108f, 0f, Space.World);

        // Small jump when they split apart
        leftHalf.GetComponent<Rigidbody>().AddForce(new Vector3(1,3,0), ForceMode.Impulse);
        rightHalf.GetComponent<Rigidbody>().AddForce(new Vector3(-1,3,0), ForceMode.Impulse);

        // Destroy splits after a while
        Destroy(leftHalf, 4);
        Destroy(rightHalf, 4);

        Debug.Log("OnMouseDown complete");
    }

    private void Update()
    {
        // Despawning function would be here in original script
    }
}
