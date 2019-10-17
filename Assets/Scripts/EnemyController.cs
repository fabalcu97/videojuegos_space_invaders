using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

  private Transform enemyHolder;
  public float speed;

  public GameObject shot;

  public Text winText;
  public float fireRate;

  void Start()
  {
    SetLevelSettings();
    winText.enabled = false;
    InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
    enemyHolder = GetComponent<Transform>();
  }

  void SetLevelSettings()
  {
    Scene scene = SceneManager.GetActiveScene();
    switch (Int32.Parse(scene.name.Split('_')[1]))
    {
      case 1:
        fireRate = 0.997f;
        speed = 0.3f;
        break;
      case 2:
        fireRate = 0.995f;
        speed = 0.35f;
        break;
      case 3:
        fireRate = 0.7f;
        speed = 0.55f;
        break;
      default:
        fireRate = 0.997f;
        speed = 0.3f;
        break;
    }
  }

  void MoveEnemy()
  {
    enemyHolder.position += Vector3.right * speed;
    foreach (Transform enemy in enemyHolder)
    {
      if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
      {
        float speedIncreased = Mathf.Abs(speed) + 0.15f;
        speed = -Mathf.Sign(speed) * speedIncreased;
        enemyHolder.position += Vector3.down * 0.5f;
        return;
      }
      if (UnityEngine.Random.value > fireRate)
      {
        Instantiate(shot, enemy.position, enemy.rotation);
      }
      if (enemy.position.y <= -3.5)
      {
        GameOver.isPLayerDead = true;
        Time.timeScale = 0;
      }
    }
    if (enemyHolder.childCount == 1)
    {
      CancelInvoke();
      InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
    }
    if (enemyHolder.childCount == 0)
    {
      Scene scene = SceneManager.GetActiveScene();
      ScoreMultiplier.multiplier = 1;
      int level = Int32.Parse(scene.name.Split('_')[1]);
      string sceneName = "Scene_00" + (level + 1).ToString();
      Debug.Log(sceneName);
      Debug.Log(SceneManager.GetSceneByName(sceneName).IsValid());
      try
      {
        SceneManager.LoadScene(sceneName);
      }
      catch (System.Exception){}
      finally {
        winText.enabled = true;
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other.name);
  }

}
