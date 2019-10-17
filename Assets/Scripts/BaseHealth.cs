using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
  public float health = 2;
  public Material brickWall, crackedWall;

  Renderer mRenderer;

  void Start()
  {
    mRenderer = GetComponent<Renderer>();
    mRenderer.material = brickWall;
  }

  // Called once per frame
  void Update()
  {
    if (health <= 1)
    {
      mRenderer.material = crackedWall;
    }
    if (health <= 0)
    {
      Destroy(gameObject);
    }

  }
}