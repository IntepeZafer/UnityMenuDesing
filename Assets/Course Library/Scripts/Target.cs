using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float minSpeed;
    public float maxSpeed;
    public float maxTorque;
    public float xRange;
    public float ySpawnPos;

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque() , ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    Vector3 RandomForce() // Uygulanacak random başlangıç hızı fonksiyonu
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() // Uygulanacak random dönüş hızı fonksiyonu
    {
        return Random.Range(-maxTorque, maxTorque);
    } 
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xRange, xRange), ySpawnPos);
    }
}
