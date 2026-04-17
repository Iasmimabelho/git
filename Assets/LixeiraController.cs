using UnityEngine;

public class LixeiraController : MonoBehaviour
{
    public float velocidade = 35f;

    private float limiteX;
    private LixoSpawnerController controller;

    void Start()
    {
        controller = FindObjectOfType<LixoSpawnerController>();

        if (controller != null)
            limiteX = controller.GetLimiteX();
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(input * velocidade * Time.deltaTime, 0, 0);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -limiteX, limiteX),
            transform.position.y,
            controller.transform.position.z
        );
    }
}