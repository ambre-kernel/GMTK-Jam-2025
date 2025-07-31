using UnityEngine;

public class HulaController : MonoBehaviour
{
    [SerializeField] float fallSpeed = 5f;
    [SerializeField] float groundHeight = 1.5f;
    public float turningSpeed = 0;
    public float targetSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (turningSpeed == 0)
        {
            transform.Translate(new Vector3(0, -fallSpeed * Time.deltaTime), 0);
        }
        else
        {
            transform.Translate(new Vector3(0, (turningSpeed - targetSpeed) / fallSpeed * Time.deltaTime), 0);
        }

        if (transform.position.y <= groundHeight)
        {
            transform.position = new Vector3(0, groundHeight, 0);
        }
    }
}
