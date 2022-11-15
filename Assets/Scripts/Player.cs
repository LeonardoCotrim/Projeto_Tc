using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _veloc ;
    [SerializeField]
    private GameObject _pfTiro;
    [SerializeField]
    private float _tempoDeDisparo = 0.3f;
    private float _podeDisparar = 0.0f;
    public int vidas = 1;
    // Start is called before the first frame update
    void Start()
    {
        _veloc = 1.5f ;
        transform.position = new Vector3(-3.5f,0,0);
    }
    // Update is called once per frame
    void Update()
    {
        Movimento();
        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
             Disparo();
        }
    }
    private void Movimento(){
        float entradaHorizontal = Input.GetAxis("Horizontal");
         transform.Translate(Vector3.right * entradaHorizontal * Time.deltaTime*_veloc);
        if ( transform.position.x > -5.0){
            transform.position = new Vector3(transform.position.x,-1.5f,0);
        } else if ( transform.position.y < -1.5f){
            transform.position = new Vector3(transform.position.x,-1.5f,1);
        }
    }
    private void Disparo(){
        if ( Time.time > _podeDisparar ){
             Instantiate(_pfTiro,transform.position + new Vector3 (0,0.5f,0),Quaternion.identity);
            _podeDisparar = Time.time + _tempoDeDisparo ;
             }
    }
    public void DanoAoPlayer()
    {
        vidas--;

    if (vidas <1)
    {
        Destroy(this.gameObject);
    }
   }
}