using UnityEngine;

public class Meteors : MonoBehaviour
{
    public float speed;
    public float damage;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame

    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        player.TakeDamage(damage);
        Destroy(gameObject);
    }
}
