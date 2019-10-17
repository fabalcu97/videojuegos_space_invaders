using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
  private Transform bullet;
  public float speed;
  private int level;

  void Start()
  {
    SetLevelSettings();
    bullet = GetComponent<Transform>();
  }
  void SetLevelSettings()
  {
    Scene scene = SceneManager.GetActiveScene();
    level = int.Parse(scene.name.Split('_')[1]);
  }

  void FixedUpdate()
  {
    bullet.position += Vector3.up * speed;

    if (bullet.position.y >= 10)
    {
      ScoreMultiplier.multiplier = 1;
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Enemy")
    {
      Destroy(other.gameObject);
      Destroy(gameObject);
      PlayerScore.playerScore += 10 * ScoreMultiplier.multiplier;
      ScoreMultiplier.multiplier++;
    }
    else if (other.tag == "Base")
    {
      if (level == 3) 
      {
        GameObject playerBase = other.gameObject;
        BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
        baseHealth.health -= 0.5f;
      }
      Destroy(gameObject);
    }

  }
}