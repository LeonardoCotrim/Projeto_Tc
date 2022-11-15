using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cogumelo : MonoBehaviour
{
    public float _velocidade = 3.0f;
    [SerializeField]
    private GameObject _explosaoCogumeloPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //5 , -4.5
        transform.Translate(Vector3.right * _velocidade * Time.deltaTime);

        if(transform.position.x < -5.0f)
        {
            transform.position = new Vector3(Random.Range(4.9f, 5.0f), -0.81f,0);
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Tiro")
            {

                Destroy(other.gameObject);
                Instantiate(_explosaoCogumeloPrefab, transform.position,Quaternion.identity);

                Destroy(this.gameObject);
            }
            else if (other.tag=="Player")
            {

                Player player = other.GetComponent<Player>();

                if (player != null)
                {
                    player.DanoAoPlayer();
                }
                Instantiate(_explosaoCogumeloPrefab, transform.position,Quaternion.identity);
                Destroy(this.gameObject);
                
            }
    }   

}
