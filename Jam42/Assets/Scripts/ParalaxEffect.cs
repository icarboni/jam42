using UnityEngine;
using UnityEngine.UI;

public class ParalaxEffect : MonoBehaviour
{
    public playerMovement playerMScript;
    public GameObject[] paralaxTransform;
    public Rigidbody2D lookVelocity;
    public Image[] paralaxImage;
    public float speed = 0;
    void Start()
    {
        
    }
    void Update()
    {
        parallax();
    }
    public void parallax() 
    {
        if (playerMScript.stunned == false && lookVelocity.velocity.x < 0)
        paralaxTransform[0].transform.position += Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
        if (playerMScript.stunned == false && lookVelocity.velocity.x < 0)
        paralaxTransform[1].transform.position += Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
        if (paralaxTransform[0].transform.localPosition.x <= -1920f && Input.GetAxis("Horizontal") > 0)
            paralaxTransform[0].transform.localPosition = new Vector3(1920f, paralaxTransform[0].transform.localPosition.y, paralaxTransform[0].transform.localPosition.z);
        if (paralaxTransform[1].transform.localPosition.x <= -1920f && Input.GetAxis("Horizontal") > 0)
            paralaxTransform[1].transform.localPosition = new Vector3(1920f, paralaxTransform[0].transform.localPosition.y, paralaxTransform[0].transform.localPosition.z);
        if (paralaxTransform[0].transform.localPosition.x >= 1920f && Input.GetAxis("Horizontal") < 0)
            paralaxTransform[0].transform.localPosition = new Vector3(-1920f, paralaxTransform[0].transform.localPosition.y, paralaxTransform[0].transform.localPosition.z);
        if (paralaxTransform[1].transform.localPosition.x >= 1920f && Input.GetAxis("Horizontal") < 0)
            paralaxTransform[1].transform.localPosition = new Vector3(-1920f, paralaxTransform[0].transform.localPosition.y, paralaxTransform[0].transform.localPosition.z);
    }

}
