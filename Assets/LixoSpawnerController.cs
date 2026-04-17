using System.Collections;
using UnityEngine;
using TMPro;

public class LixoSpawnerController : MonoBehaviour
{
    public GameObject lixo;
    public Transform plano;

    public float alturaSpawn = 6f;
    public float timer = 1f;

    public int maxPoints = 20;
    public int points = 0;

    public TMP_Text pointsText;
    public TMP_Text victoryText;

    private float limiteX;

    void Start()
    {
        if (plano == null)
        {
            Debug.LogError("Arrasta o plano!");
            return;
        }

        Renderer r = plano.GetComponent<Renderer>();
        limiteX = r.bounds.extents.x;

        if (victoryText != null)
            victoryText.gameObject.SetActive(false);

        AtualizarTexto();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (points < maxPoints)
        {
            float randomX = Random.Range(
                plano.position.x - limiteX,
                plano.position.x + limiteX
            );

            Instantiate(lixo,
                new Vector3(randomX, plano.position.y + alturaSpawn, plano.position.z),
                Quaternion.identity);

            yield return new WaitForSeconds(timer);

            // 🔥 dificuldade aumenta
            if (timer > 0.3f)
                timer -= 0.02f;
        }
    }

    public void AddToPoints(int value)
    {
        points += value;
        AtualizarTexto();

        if (points >= maxPoints)
        {
            if (victoryText != null)
                victoryText.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    void AtualizarTexto()
    {
        if (pointsText != null)
            pointsText.text = "Pontos: " + points;
    }

    public float GetLimiteX()
    {
        return limiteX;
    }
}