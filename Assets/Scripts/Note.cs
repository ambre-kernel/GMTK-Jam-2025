using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] string listenTo = "Btn1";
    public float lifeTime = 4;

    private Animator anim;
    private string hit = "";

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(this);
        else if (lifeTime < 1.8f) hit = "miss";
        else if (lifeTime < 1.95f) hit = "good";
        else if (lifeTime < 2.05f) hit = "perfect";
        else if (lifeTime < 2.2f) hit = "good";

        if (Input.GetButtonDown(listenTo) && hit != "")
        {
            Vector3 trans = transform.position;
            anim.SetTrigger(hit);
        }
    }
}
