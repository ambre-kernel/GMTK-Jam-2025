using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] bool isLeftStick = true;
    [SerializeField] float deadZone = .5f;

    private Vector2 stickDir = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftStick)
        {
            stickDir.x = Input.GetAxisRaw("Horizontal");
            stickDir.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            stickDir.x = Input.GetAxisRaw("Horizontal2");
            stickDir.y = Input.GetAxisRaw("Vertical2");
        }
        if (stickDir.magnitude < deadZone) stickDir = Vector2.zero;
        else transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-stickDir.x, stickDir.y) * Mathf.Rad2Deg);
    }
}
