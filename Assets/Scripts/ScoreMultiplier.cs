using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{

  public static float multiplier = 1;
  private Text multiplierText;

  void Start()
  {
    multiplierText = GetComponent<Text>();
  }

  void Update()
  {
    multiplierText.text = "x " + multiplier;
  }
}

