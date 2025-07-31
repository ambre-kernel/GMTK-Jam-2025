using UnityEngine;

public class UIWheel : MonoBehaviour
{
    [SerializeField] HulaController hula;

    void Update()
    {
        if (hula.stickDir.magnitude > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-hula.stickDir.x, hula.stickDir.y) * Mathf.Rad2Deg);
        }
    }
}
