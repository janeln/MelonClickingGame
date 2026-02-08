using UnityEngine;
using UnityEngine.InputSystem;

public class MelonController : MonoBehaviour
{
    public GameObject melonPrefab; // Selected in Unity Inspector

    // Timer variables
    private float spawnRate = 0.5f;
    private float timer = 0f;

    // Variables for random position/orientation of instantiated melons
    private Vector3 positionOffset = Vector3.zero;
   
    void Update()
    {
        // Spawn melons at random times and spots along a section below the screen
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; // Increases timer time until spawn rate
        }
        else
        {
            positionOffset = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 0);
            Instantiate(melonPrefab, transform.position + positionOffset, transform.rotation);
            spawnRate = Random.Range(0.3f, 1.5f); // Changes spawn rate for next timer round
            timer = 0;
        }

        // Some key options to leave the game
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.Quit();
        }

    }
}
