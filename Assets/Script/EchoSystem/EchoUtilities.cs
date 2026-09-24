using UnityEngine;

// This script provides utility functions for the Echo system, including value clamping, chance calculations, and percentage calculations. These functions can be used throughout the Echo system to perform common operations related to Echo Energy, Memory, and other properties.
public static class EchoUtilities
{
  public static float ClampValue(float value, float min, float max)
  {
    return Mathf.Clamp(value, min, max);
  }

  public static int ClampValue(int value, int min, int max)
  {
    return Mathf.Clamp(value, min, max);
  }

  public static bool Chance(float percent)
  {
    float randomValue = Random.Range(0f, 100f);

    return randomValue <= percent;
  }

  public static float Percentage(float current, float max)
  {
    if (max <= 0)
    {
      return 0;
    }

    return (current / max) * 100f;
  }
}