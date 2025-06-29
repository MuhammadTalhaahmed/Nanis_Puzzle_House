using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    public GameObject _door;
    public GameObject character;
    public float moveDuration = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            _door = collision.gameObject;
            StartCoroutine(OpentheDoor());
        }
    }

    IEnumerator OpentheDoor()
    {
        // Open door by setting Y rotation to -81
        Vector3 newRotation = _door.transform.eulerAngles;
        newRotation.y = -81f;
        _door.transform.eulerAngles = newRotation;

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        // Move character forward 3 feet (approx 0.91m) and left 2 feet (approx 0.61m)
        Vector3 startPos = character.transform.position;
        Vector3 forwardTarget = startPos + character.transform.forward * 15.91f;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            character.transform.position = Vector3.Lerp(startPos, forwardTarget, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        character.transform.position = forwardTarget;
        // === Move left 2 feet ===
        Vector3 leftStart = character.transform.position;
        Vector3 leftTarget = leftStart + -character.transform.right * 5.81f;

        elapsed = 0f;
        while (elapsed < moveDuration)
        {
            character.transform.position = Vector3.Lerp(leftStart, leftTarget, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        character.transform.position = leftTarget;
        yield return new WaitForSeconds(2f);
        FindObjectOfType<GameManager>().PlayerEscaped();

    }

}
