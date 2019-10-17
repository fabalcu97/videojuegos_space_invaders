using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

  private Transform bullet;

  public float speed;

  // Start is called before the first frame update
  void Start()
  {
    bullet = GetComponent<Transform>();
  }

  void FixedUpdate()
  {
    bullet.position += Vector3.up * -speed;

    if (bullet.position.y <= -10)
    {
      Destroy(bullet.gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
      playerController.DecreaseLife();
      Destroy(gameObject);
    }
    else if (other.tag == "Base")
    {
      GameObject playerBase = other.gameObject;
      BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
      baseHealth.health -= 0.5f;
      Destroy(gameObject);
    }
  }
}
