using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSuitScript : MonoBehaviour
{
    [SerializeField]
    Transform joueur;


    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float delais = 0.5f;
    [SerializeField]
    float vitesse = 5f;
    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position ,new Vector3(joueur.position.x,joueur.position.y,transform.position.z), Time.deltaTime * vitesse);
    }
}
