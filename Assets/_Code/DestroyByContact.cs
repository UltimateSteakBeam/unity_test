using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController ctrl;
    public int scoreIncr;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            ctrl = gameControllerObject.GetComponent<GameController>();
        } else
        {
            Debug.Log("Cannot find game controller");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            ctrl.GameOver();
        }
        ctrl.AddScore(scoreIncr);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
