using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveDown : MonoBehaviour
{
    private float speed = 15.0f;
    private float zBound = -34;

    public AudioClip destroySound;
    private AudioSource enemyAudioSource;

    public ParticleSystem destroyParticle;


    void Start()
    {  
        enemyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move the enemies downward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy enemies if they go out of bounds
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Collision of "Enemy" and "Bullets"
        if (other.gameObject.CompareTag("bullet"))
        {
            ScoreUpdate.score += 1;
            PlayDestroySound();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        // Collision of "Player" and "Enemy"
        if (other.gameObject.CompareTag("Player"))
        {   
            PlayDestroySound();

            SceneManager.LoadScene(0);
           
            // Destroy the "player" after the sound starts playing
            Destroy(other.gameObject, 1f);
        }
    }

    

    // Play the Destroy Sound
    void PlayDestroySound()
    {
        if (destroySound != null)
        {
            // Create a temporary GameObject to play the sound
            GameObject tempAudioObject = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
            tempAudioSource.clip = destroySound;
            tempAudioSource.Play();

            // Instantiate the particle effect at the enemy's position before destroying
            if (destroyParticle != null)
            {
                ParticleSystem tempParticle = Instantiate(destroyParticle, transform.position,transform.rotation);
                Destroy(tempParticle.gameObject, tempParticle.main.duration);            
            }

            // Destroy the temporary object after the sound finishes
            Destroy(tempAudioObject, destroySound.length);
        }
    }

}
