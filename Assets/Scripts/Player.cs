using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHP;
    public Material playerMaterial;
    private Renderer renderer;
    private CharacterController characterController;
    private Vector3 playerVelocity; 
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        renderer = this.GetComponent<Renderer>();
        playerMaterial = renderer.material;
        currentHP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void Move()
    {
        
        float verticalTranslation = Input.GetAxis("Vertical") * speed;
        float horTranslation = Input.GetAxis("Horrizontal") * speed;

        verticalTranslation *= Time.deltaTime;
        horTranslation *= Time.deltaTime;

        transform.Translate(verticalTranslation, horTranslation, 0);
    }

    public IEnumerator TakeDamage(float damage)
    {
        currentHP -= damage;

        float previousUV = playerMaterial.GetFloat("_UVSET");
        playerMaterial.SetFloat("_UVSET", 1f);

        yield return new WaitForSeconds(1);

        playerMaterial.SetFloat("_UVSET", previousUV);

        Debug.Log("Player took damage");
    }
}
