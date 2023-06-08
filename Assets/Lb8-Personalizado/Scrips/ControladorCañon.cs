using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCañon : MonoBehaviour
{


    Vector3 direction;
    public GameObject prefabBullet;
    public Transform disparador;
    public float velocidadinicial = 5.0f;
    public GameObject Trayectoria;
    public GameObject[] puntosTrayectoria;
    [SerializeField] private int pointsCount;
    [SerializeField] private float separacion;

    float VoX;
    float VoY;

    void Start()
    {
        puntosTrayectoria = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            puntosTrayectoria[i] = Instantiate(Trayectoria, disparador.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = hit.point;
            direction = mousePosition - transform.position;
            direction.z = 0f;
            transform.right = direction.normalized;
        }




        for (int i = 0; i < pointsCount; i++)
        {
            puntosTrayectoria[i].transform.position = CurrentPosition(i * separacion);


        }

        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparo();
        }
    }
    private Vector2 CurrentPosition(float t)
    {
        Vector2 xBola =  direction * velocidadinicial * t;
        Vector2 yBola = 0.5f * Physics.gravity * (t * t);
        return (Vector2)disparador.position + xBola + yBola;
    }
     
    void Disparo()
    {

        GameObject bullet = Instantiate(prefabBullet, disparador.position, disparador.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = direction * velocidadinicial;

    }
}
