using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float minSpeed = 12f;
    public float maxSpeed = 16f;
    public float maxTorque = 10f;
    public float xRange = 4f;
    public float ySpawnPos = -6f;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque() , ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.updateScore(pointValue);
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce() // Uygulanacak random başlangıç hızı fonksiyonu
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() // Uygulanacak random dönüş hızı fonksiyonu
    {
        return Random.Range(-maxTorque, maxTorque);
    } 

    Vector3 RandomSpawnPos() // Uygulanacak random başlangıç konum fonksiyonu
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
