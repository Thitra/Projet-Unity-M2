using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
	public Transform player;
	public Transform playerCam;

	// La force avec laquelle on lance l'objet. Personnalisable par objet portant ce script pour avoir différentes forces de lancer
	public float throwForce = 10;
	
	// S'il y a un joueur assez proche pour porter l'objet ayant ce script
	private bool hasPlayer = false;

	// Si l'objet est porté
	private bool beingCarried = false;

	// Détection entre objet porté et un mur ou autre collider
	private bool touched = false;

	void Update()
	{
		// vérifie la distance entre l'objet et le joueur
		float dist = Vector3.Distance(gameObject.transform.position, player.position);

		// si - ou = 1.9 unités de distance = on peut ramasser
		if(dist <= 1.9f)
		{
			hasPlayer = true;
		}
		else
		{
			hasPlayer = false;
		}

		// si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent< Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        // Si on porte l'objet
        if (beingCarried)
        {
            // si l'objet touche un mur / objet avec collider
            if (touched)
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            // Clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent< Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // Détection de contact grace au collider is trigger (car OnCollisionEnter ne fonctionne pas avec un isKinematic)
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}