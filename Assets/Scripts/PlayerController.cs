using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player
    public GameObject bulletPrefab;
    public float horizontalInput;
    public float speed = 20;

    public float xRange = 58;

    // Bullets
    public bool isFiring = false;

    // Sounds
    public AudioClip bulletAudioClip;
    public AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check the Player Boundaries
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // Move the player in horizontal
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Start firing bullets when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isFiring)
        {
            // Play the firing Sound
            playerAudio.PlayOneShot(bulletAudioClip, 1.0f);
            StartCoroutine(FireBullets());
        }
    }

    // Fire Bullet
    IEnumerator FireBullets()
    {
        isFiring = true;

        while (Input.GetKeyDown(KeyCode.Space))
        {
            // Fire the bullet
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }

        isFiring = false;
    }
}
