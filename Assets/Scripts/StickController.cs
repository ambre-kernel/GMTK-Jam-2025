using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] HulaController hula;
    [SerializeField] bool useMouse = false;
    [SerializeField] bool isLeftStick = true;
    [SerializeField] float deadZone = .5f;

    private Vector2 stickDir = Vector2.zero;
    private Vector2 mousePos = Vector2.zero;
    private float turnLastAngle = 0;
    private float turningSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useMouse)
        {
            float angle = Mathf.Atan2(-mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 2 - new Vector3(1, 1, 0);

            turningSpeed = turnLastAngle - angle;
            if (turningSpeed > 180) turningSpeed -= 360;

            turnLastAngle = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(0, 0, angle);
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

            if (stickDir.magnitude < deadZone)
            {
                stickDir = Vector2.zero;
                turningSpeed = 0;
                turnLastAngle = 0;
            }
            else
            {
                float stickAngle = Mathf.Atan2(-stickDir.x, stickDir.y) * Mathf.Rad2Deg;
                turningSpeed = turnLastAngle - stickAngle;
                if (turningSpeed > 180) turningSpeed -= 360;

                turnLastAngle = transform.eulerAngles.z;
                transform.eulerAngles = new Vector3(0, 0, stickAngle);
            }
        }
        hula.turningSpeed = Mathf.Abs(turningSpeed);
    }

    // FixedUpdate is called once per 1/60 seconds
    void FixedUpdate()
    {

    }
}
