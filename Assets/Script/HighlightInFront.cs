using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HighlightInFront : MonoBehaviour
{
    public Tilemap terreno;
    public Tile grama;
    public Tile estrada;
    public Tile basico;
    public Tilemap objetos;
    public Tile moto0;
    public Tile moto1;
    public Tile moto2;
    public Tile moto3;
    public Tile carro0;
    public Tile carro1;
    public Tile carro2;
    public Tile carro3;
    public Tilemap controle;
    public RuleTile linha;
    public Tile direcao0;
    public Tile direcao1;
    public Tile direcao2;
    public Tile direcao3;
    public Tile direcao4;
    public Tile direcao5;
    public Tile direcao6;
    public Tile direcao7;

    public Tilemap tmUso;
    public Tile tUso;
    public RuleTile rTUso;

    //public GameObject point;
    private Vector3 target;
    private int xP, yP;

    public GameObject panel1;

    public TextMeshPro tm;
    public TextMeshPro tmr;

    public Collider2D textcollider;

    int tileETexto = 0;
    bool maisTexto = true;
    bool deletar = false;
    bool delTexto = false;


    TouchScreenKeyboard keyboard;
    string textomobile = "";

    float mx;
    float my;

    //public Toggle pode;
    Animator animator;

    void Start()
    {
        animator = panel1.GetComponent<Animator>();
        //    StartCoroutine(GetText());
    }

    //IEnumerator GetText()
    //{
    //    UnityWebRequest www = UnityWebRequest.Get("http://api.plos.org/search?q=title:DNA");
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        // Show results as text
    //        Debug.Log(www.downloadHandler.text);

    //        // Or retrieve results as binary data
    //        byte[] results = www.downloadHandler.data;
    //    }
    //}

    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            MobileControls();
        }
        else
        {
            PCControls();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScreenShot();
            }
        }


    }



    public void PCControls()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        TransformPosition();
        //if (pode.isOn)
        //{
        if (Input.GetMouseButton(0) == true)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("outro");
                return;//n cria tile se clicar na UI
            }
            
            bool isOpen = animator.GetBool("Open");
            animator.SetBool("Open", false);
        }

        if (tileETexto == 0)
        {


            if (tUso == grama || tUso == estrada || tUso == basico)
            {
                if (Input.GetMouseButton(0) == true)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }


                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }

                    tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                    Debug.Log("tilemap");
                }
            }
            //if (tmUso == controle && rTUso == linha)
            //{
            //    if (Input.GetMouseButton(0) == true)
            //    {
            //        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //        Vector2 touchPos = new Vector2(wp.x, wp.y);
            //        if (EventSystem.current.IsPointerOverGameObject())
            //        {
            //            Debug.Log("outro");
            //            return;//n cria tile se clicar na UI
            //        }


            //        if (Physics2D.OverlapPoint(touchPos).tag == "texto")
            //        {
            //            Debug.Log("texto");//editar o texto que foi identificado

            //        }

            //        tmUso.SetTile(new Vector3Int(xP, yP, 0), rTUso);
            //        Debug.Log("tilemap");
            //    }
            //}
            if (tUso == carro0)
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    if (deletar == true)
                    {
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), null);
                        Debug.Log("deletado");
                    }
                    else
                    {
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                        {
                            Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro0")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro1);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro1")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro2);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro2")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro3);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro3")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro0);
                                return;
                            }
                        }
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                        Debug.Log("tilemap");
                    }
                }
            }
            if (tUso == moto0)
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }


                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                    {
                        Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto0")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto1);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto1")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto2);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto2")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto3);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto3")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto0);
                            return;
                        }
                    }
                    tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                    Debug.Log("tilemap");
                }
            }
            if (tUso == direcao0)
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }


                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    if (deletar == true)
                    {
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), null);
                        Debug.Log("deletado");
                    }
                    else
                    {
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                        {
                            Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao0")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao1);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao1")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao2);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao2")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao3);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao3")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao4);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao4")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao5);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao5")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao6);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao6")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao7);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao7")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao0);
                                return;
                            }
                        }
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                        Debug.Log("tilemap");
                    }
                    
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                if (delTexto == true)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado
                        Destroy(Physics2D.OverlapPoint(touchPos).gameObject);
                    }
                }
                else
                {
                    if (maisTexto == true)
                    {
                        if (EventSystem.current.IsPointerOverGameObject())
                        {
                            Debug.Log("outro");
                            return;//n cria tile se clicar na UI
                        }
                        if (tm == null)
                        {
                            tm = tmr;
                        }
                        mx = Input.mousePosition.x;
                        my = Input.mousePosition.y;
                        tm = Instantiate(tm);
                        tm.transform.position = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mx, my, 10.0f));
                        tm.text = "assim ta funcionando";
                        //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, true, false);
                        maisTexto = false;
                    }
                }

            }

        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            maisTexto = true;

        }
        //}
        //else
        //{
        //    Zoom(Input.GetAxis("Mouse ScrollWheel"));
        //}
    }

    public void MobileControls()
    {
        //if (pode.isOn)
        //{

        if (tileETexto == 0)
        {
            if (tUso == grama || tUso == estrada || tUso == basico)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);

                    if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
                    {
                        bool isOpen = animator.GetBool("Open");
                        animator.SetBool("Open", false);

                    }
                    
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {

                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));

                    TransformPosition();

                    tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);

                }
            }
            //if (tmUso == controle && rTUso == linha)
            //{
            //    if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            //    {
            //        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            //        {
            //            Debug.Log("outro");
            //            return;//n cria tile se clicar na UI
            //        }
            //        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //        Vector2 touchPos = new Vector2(wp.x, wp.y);

            //        if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
            //        {
            //            bool isOpen = animator.GetBool("Open");
            //            animator.SetBool("Open", false);

            //        }

            //        if (Physics2D.OverlapPoint(touchPos).tag == "texto")
            //        {

            //            Debug.Log("texto");//editar o texto que foi identificado

            //        }
            //        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));

            //        TransformPosition();

            //        tmUso.SetTile(new Vector3Int(xP, yP, 0), rTUso);

            //    }
            //}
            if (tUso == carro0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
                    {
                        bool isOpen = animator.GetBool("Open");
                        animator.SetBool("Open", false);

                    }   
                    
                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));
                    TransformPosition();

                    if (deletar == true)
                    {
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), null);
                        Debug.Log("deletado");
                    }
                    else
                    {
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                        {
                            Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro0")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro1);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro1")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro2);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro2")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro3);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Carro3")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), carro0);
                                return;
                            }
                        }
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                        Debug.Log("tilemap");
                    }
                }

            }
            if (tUso == moto0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
                    {
                        bool isOpen = animator.GetBool("Open");
                        animator.SetBool("Open", false);

                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));

                    TransformPosition();
                    if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                    {
                        Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto0")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto1);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto1")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto2);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto2")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto3);
                            return;
                        }
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Moto3")
                        {
                            //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            tmUso.SetTile(new Vector3Int(xP, yP, 0), moto0);
                            return;
                        }
                    }
                    tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                    Debug.Log("tilemap");
                }
            }
            if (tUso == direcao0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
                    {
                        bool isOpen = animator.GetBool("Open");
                        animator.SetBool("Open", false);

                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado

                    }
                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));

                    TransformPosition();
                    if (deletar == true)
                    {
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), null);
                        Debug.Log("deletado");
                    }
                    else
                    {                        
                        if (tmUso.GetTile(new Vector3Int(xP, yP, 0)) != null)// verificar e pegar qual tile foi criado
                        {
                            Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao0")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao1);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao1")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao2);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao2")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao3);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao3")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao4);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao4")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao5);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao5")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao6);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao6")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao7);
                                return;
                            }
                            if (tmUso.GetTile(new Vector3Int(xP, yP, 0)).name == "Direcao7")
                            {
                                //Debug.Log(tmUso.GetTile(new Vector3Int(xP, yP, 0)).name);
                                tmUso.SetTile(new Vector3Int(xP, yP, 0), direcao0);
                                return;
                            }
                        }
                        tmUso.SetTile(new Vector3Int(xP, yP, 0), tUso);
                        Debug.Log("tilemap");
                    }
                    
                }
            }
        }
        else
        {
            if (delTexto == true)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "cenario")
                    {
                        
                        bool isOpen = animator.GetBool("Open");
                        animator.SetBool("Open", false);
                   
                        //if (deletar == true)
                        //{
                        //    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));
                        //    TransformPosition();
                        //    tmUso.SetTile(new Vector3Int(xP, yP, 0), null);
                        //    Debug.Log("deletado");
                        //}
                    }
                    if (Physics2D.OverlapPoint(touchPos).tag == "texto")
                    {
                        Debug.Log("texto");//editar o texto que foi identificado
                        Destroy(Physics2D.OverlapPoint(touchPos).gameObject);
                        
                    }
                }
            }
            else
            {
                if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
                {
                    textomobile = keyboard.text;
                    tm.text = textomobile;
                    maisTexto = true;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Debug.Log("outro");
                        return;//n cria tile se clicar na UI
                    }
                    if (maisTexto == true)
                    {
                        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                        maisTexto = false;
                    }
                    mx = Input.GetTouch(0).position.x;
                    my = Input.GetTouch(0).position.y;

                    if (tm == null)
                    {
                        tm = tmr;
                    }
                    tm = Instantiate(tm);
                    tm.transform.position = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mx, my, 10.0f));
                    tm.text = "Nome";

                }
            }
        }
        //}
        //else
        //{
        //    if (Input.touchCount == 2)
        //    {
        //        Touch touchZero = Input.GetTouch(0);
        //        Touch touchOne = Input.GetTouch(1);

        //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //        float difference = currentMagnitude - prevMagnitude;

        //        Zoom(difference * 0.05f);

        //    }
        //}
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 4, 10);
    }

    public void ScreenShot()
    {
        ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
    }

    public void TransformPosition()
    {
        xP = Mathf.FloorToInt(target.x);
        yP = Mathf.FloorToInt(target.y);
    }

    public void OpCloMenu1()
    {
        if (animator != null)
        {
            bool isOpen = animator.GetBool("Open");

            animator.SetBool("Open", !isOpen);
        }
    }

    public void Grama()
    {
        tmUso = terreno;
        tUso = grama;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Estrada()
    {
        tmUso = terreno;
        tUso = estrada;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Basico()
    {
        tmUso = terreno;
        tUso = basico;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Carro()
    {
        tmUso = objetos;
        tUso = carro0;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Moto()
    {
        tmUso = objetos;
        tUso = moto0;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Caminho()
    {
        tmUso = controle;
        rTUso = linha;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Direcao()
    {
        tmUso = controle;
        tUso = direcao0;
        rTUso = null;
        tileETexto = 0;
        deletar = false;
        delTexto = false;
    }
    public void Texto()
    {
        delTexto = false;
        tileETexto = 1;
    }
    public void RemoverObj()
    {
        tmUso = objetos;
        tUso = carro0;
        tileETexto = 0;
        deletar = true;
        delTexto = false;
    }
    public void RemoverCon()
    {
        tmUso = controle;
        tUso = direcao0;
        tileETexto = 0;
        deletar = true;
        delTexto = false;
    }
    
    public void RemoverTexto()
    {
        deletar = true;
        delTexto = true;
        tileETexto = 1;
    }
}
