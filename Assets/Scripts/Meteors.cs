using UnityEngine;

public class Meteors : MonoBehaviour
{
    public float speed;
    public float damage;
    public Player player;
    private Renderer renderer;
    private Material material;
    private Color materialColor;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        renderer = gameObject.GetComponent<Renderer>();
        material = renderer.material;
        materialColor = material.color;
    }

    void Update()
    {
        // Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),Random.Range(0f, 1f));
        // material.color = newColor;
    }
    // Update is called once per frame

    void OnTriggerEnter(Collider collider)
    {
        player = collider.GetComponent<Player>();
        player.TakeDamage(damage);
        if (player != null)
        {
            Debug.Log("Found player " + player);
        }
        Destroy(gameObject);
    }
}
