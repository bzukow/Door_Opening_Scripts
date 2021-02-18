using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZulController : MonoBehaviour
{
    Animator anim;
    Rigidbody rigidbody;

    public GameObject buttonTarget;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool stunned;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        rigidbody = transform.GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ExitGame());
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical");
        if (!stunned)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            anim.SetFloat("speed", Mathf.Abs(direction.magnitude));
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime);
            }
        }
        
        
    }

    public void ClickButton()
    {
        buttonTarget.transform.GetComponent<Animator>().SetBool("isClicked", true);
    }

    IEnumerator ExitGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }
}
