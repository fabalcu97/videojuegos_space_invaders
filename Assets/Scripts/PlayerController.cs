﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  private Transform player;

  public int life = 3;
  public float speed;
  public float maxBound, minBound;

  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;

  private float nextFire;

  public List<Image> images;
  void Start()
  {
    player = GetComponent<Transform>();
  }

  public void DecreaseLife(){
    life -= 1;
    images[life].enabled = false;
    if (life == 0) {
      GameOver.isPLayerDead = true;
      Destroy(gameObject);
    }
    
  }

  void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal");

    if (player.position.x < minBound && h < 0)
    {

      h = 0;
    }
    else if (player.position.x > maxBound && h > 0)
    {
      h = 0;
    }
    player.position += Vector3.right * h * speed;
  }

  void Update()
  {
    if (Input.GetButton("Fire1") && Time.time > nextFire)
    {
      nextFire = Time.time + fireRate;
      Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
  }
}