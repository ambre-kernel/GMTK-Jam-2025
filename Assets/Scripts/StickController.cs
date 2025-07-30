using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] bool useMouse = false;
    [SerializeField] bool isLeftStick = true;
    [SerializeField] float deadZone = .5f;

    private Vector2 stickDir = Vector2.zero;
    private Vector2 mousePos = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useMouse)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
        }
        else
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
}
