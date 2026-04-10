using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoSpawnerController : MonoBehaviour
{
  public float maximumX;
    public float fixedY;
    public float fixedZ;
    public float timer;

    public GameObject Lixo;
    public int MaxPoints;
    public int points = 0;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine() {
    while (points < MaxPoints) {
        Instantiate(Lixo,
            new Vector3(Random.Range(-maximumX, maximumX+1),
            fixedY,
            fixedZ),
            Quaternion.identity);
        yield return new WaitForSeconds(timer);
    }
}
}
