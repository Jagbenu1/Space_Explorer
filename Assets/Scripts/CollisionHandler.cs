using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
        Debug.Log("This thing is friendly");
        break;
      case "Fuel":
        Debug.Log("You picked up some fuel");
        break;
      case "Finish":
        Debug.Log("You finished the game!!!");
        break;
      default:
        Debug.Log("Sorry, you blew up!");
        break;
    }
  }
}
