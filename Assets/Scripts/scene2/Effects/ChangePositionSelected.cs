using UnityEngine;
using System.Collections;

public class ChangePositionSelected : MonoBehaviour
{
    float[] positions = { 3.7f, 1.9f, 0.2f, -1.3f };
    int index = 0;

    public void ChangePosition(int z)
    {
        index = z;
        if (transform.position.y == positions[index])
            return;
        MovingEffect();
    }

    private void MovingEffect() 
    {
        float offset = 0.5f;
        if (transform.position.y > positions[index])
            StartCoroutine(routine: downwardMovement(offset));
        else if (transform.position.y < positions[index])
            StartCoroutine(routine: upwardMovement(offset));
    }

    private IEnumerator upwardMovement(float offset)
    {
        while (transform.position.y + offset < positions[index])
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        transform.position = new Vector3(transform.position.x, positions[index], transform.position.z);
    }

    private IEnumerator downwardMovement(float offset)
    {
        while (transform.position.y - offset > positions[index])
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        transform.position = new Vector3(transform.position.x, positions[index], transform.position.z);
    }
}