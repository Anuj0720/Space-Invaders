using UnityEngine;

public class FireBullet : MonoBehaviour
{


    private float speed = 40;

    private float zRange = 27;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // move the buulet forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Check the boundaries
        if(transform.position.z > zRange){
            Destroy(gameObject);
        }
    }
    
}
