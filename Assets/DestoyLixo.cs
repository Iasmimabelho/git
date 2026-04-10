using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyLixo : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision) {
        // Optional: Check if the entering object is the Player
        if (collision.gameObject.CompareTag("Lixo")) {
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
