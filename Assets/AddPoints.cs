using UnityEngine;

public class AddPoints : MonoBehaviour
{
    private LixoSpawnerController controller;

    public GameObject efeitoPrefab; // efeito +1
    public AudioSource som;

    void Start()
    {
        controller = FindObjectOfType<LixoSpawnerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lixo"))
        {
            Vector3 pos = collision.transform.position;

            Destroy(collision.gameObject);

            if (controller != null)
                controller.AddToPoints(1);

            // 🔥 efeito visual
            if (efeitoPrefab != null)
                Instantiate(efeitoPrefab, pos, Quaternion.identity);

            // 🔊 som
            if (som != null)
                som.Play();
        }
    }
}