using UnityEngine;

// This script manages the puzzle logic for the Echo system. When the player interacts with the puzzle, it will trigger the purification process and restore the echo zone if the puzzle is solved.
public class EchoPuzzle : MonoBehaviour
{
  [Header("Puzzle")]
  [SerializeField] private bool puzzleSolved = false;

  [Header("Echo Components")]
  [SerializeField] private EchoInteractable interactable;
  [SerializeField] private EchoPurification purification;
  [SerializeField] private EchoZone echoZone;

  private void Awake()
  {
    if (interactable == null)
    {
      interactable = GetComponent<EchoInteractable>();
    }

    if (purification == null)
    {
      purification = FindAnyObjectByType<EchoPurification>();
    }
  }

  private void OnEnable()
  {
    if (interactable != null)
    {
      interactable.OnInteracted += StartPuzzle;
    }
  }

  private void OnDisable()
  {
    if (interactable != null)
    {
      interactable.OnInteracted -= StartPuzzle;
    }
  }

  private void StartPuzzle(EchoInteractable sender)
  {
    Debug.Log("Puzzle Dimulai...");

    SolvePuzzle();
  }

  public void SolvePuzzle()
  {
    if (puzzleSolved)
    {
      return;
    }

    puzzleSolved = true;

    Debug.Log("Puzzle Selesai!");

    if (purification != null)
    {
      bool success = purification.Purify();

      if (success && echoZone != null)
      {
        echoZone.Restore();
      }
    }
  }

  public void ResetPuzzle()
  {
    puzzleSolved = false;
  }

  public bool IsSolved()
  {
    return puzzleSolved;
  }
}