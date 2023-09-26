using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 1000f;
    public float rotationSpeed = 120f;

    public GameObject gun, bulletPrefab;

    public float xBorderLimit = 11;
    public float yBorderLimit = 6;
    public static int SCORE = 0;
    private Rigidbody _rigid;
    public static int lives = 3;
    public GameObject GameOverPanel;
    public GameObject Heart1, Heart2, Heart3;
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        GameOverPanel.SetActive(false);
        vidas();
        int anchoPantalla = Screen.width;
        int altoPantalla = Screen.height;

        // Imprime el tamaño de la pantalla en la consola
        Debug.Log("Tamaño de la pantalla: " + anchoPantalla + "x" + altoPantalla);
  
        
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit+1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit-1;
        if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit+1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit-1;
        transform.position = newPos;


        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustForce * thrustDirection * thrust);

        transform.Rotate(Vector3.forward, -rotationSpeed * rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }
    private void OnCollisionEnter (Collision collision) {

        if (collision.gameObject.tag == "Enemy") {
            if (lives > 1) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SCORE = 0;
                lives -= 1;
                vidas();
            } else {
                End();
            }
        }
        
    }
    public void End() {
        vidas();
        GameOverPanel.SetActive(true); // To show the panel
        Time.timeScale = 0; // To freeze the time

    }

    public void Continue() {
        GameOverPanel.SetActive(false); // To hide the panel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // To unfreeze the time
    }
    public void Restart() {
        GameOverPanel.SetActive(false); // To hide the panel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // To unfreeze the time
        SCORE = 0;
        lives = 3;
        vidas();
    }
    public void vidas() { // function that controls the heart that represent lives
        if (lives == 3) {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        } else if (lives == 2) {
            Heart1.SetActive(false);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        } else if (lives == 1) {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(true);
        } else if (lives == 0) {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
    }
}
