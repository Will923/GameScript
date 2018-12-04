using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NzingaController : MonoBehaviour {

	public Animator animator;
    public float InputY;
    public float turnSpeed = 100.0f;

    public float playerLife = 100f;
    public Slider lifebar;

    public Text dinheiro;

    public GameObject pauseMenu;
    private float xDeg;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        dinheiro.text = GlobalControl.Instance.cash.ToString();
        lifebar.value = playerLife;
        Cursor.visible = false;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKeyDown(KeyCode.P) ){
            paused = !paused;

            if ( paused){
                Time.timeScale = 0f;
                pauseMenu.gameObject.SetActive(true);
                Cursor.visible = true;
            }else{
                Time.timeScale = 1f;
                pauseMenu.gameObject.SetActive(false);
                Cursor.visible = false;
            }

        }

        if(paused == false){

            InputY = Input.GetAxis("Vertical");
            if (Input.GetMouseButtonDown(1) && InputY == 0){
                    animator.SetBool("run", false);
                    animator.SetBool("Apontar", true);
            }else{

                if(InputY != 0){
                    if( Input.GetKey(KeyCode.LeftShift) ){
                        animator.SetBool("Apontar", false);
                        animator.SetBool("run", true);
                        transform.Translate(Vector3.forward * 8 * Time.deltaTime);
                    }else{
                        animator.SetBool("Apontar", false);
                        animator.SetBool("run", false);
                        animator.SetFloat("InputY", InputY);
                        transform.Translate(Vector3.forward * 6 * Time.deltaTime);
                    }
                }

            }
    
            xDeg += Input.GetAxis("Mouse X") * 1 * 2;
            transform.rotation = Quaternion.Lerp( transform.rotation, Quaternion.Euler( 0, xDeg, 0 ), Time.deltaTime * 6 );

        }


/*
        if(Input.GetKey(KeyCode.LeftArrow))
           transform.rotation = Quaternion.Lerp(  );
           // transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
  */

    }


    public void hit(float hit){

        playerLife -= hit;
        lifebar.value = playerLife;

    }

	
}
