using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    //[SerializeField] GameObject[] sprites;
    [SerializeField] GameObject straightNail;
    [SerializeField] BoxCollider2D collider;
    private bool missed = false;
    private bool wasHit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Hitter")
        {
            straightNail.transform.localPosition = new Vector2(straightNail.transform.localPosition.x, -1.55f);
            collider.enabled = false;
            wasHit = true;
            collision.GetComponentInParent<SimpleController>().SetHit(true);
        }
        /*else if (collision.transform.tag == "DeadZone")
        {
            int rnd = Random.Range(0, sprites.Length);
            straightNail.SetActive(false);
            sprites[rnd].SetActive(true);
            collider.enabled = false;
        }*/
    }

    private void Update()
    {
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 4f && !missed && !wasHit)
        {
            missed = true;
            FindObjectOfType<ScoreManager>().InstantiateNoHitText();
        }
    }
}
