using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jalopyBusControl : MonoBehaviour
{
    public float speed = 1000f;
    public float turningSpeed = 90f;
    private Rigidbody rigid;
    public Transform vanStart;
    public bool driving = false;
    public GameObject player;
    public Camera myCam;
    public AudioClip InsideAduio;
    public AudioClip outsideAudio;
    public AudioClip GetItem;
    public AudioClip Hitsomething;
    public AudioClip Vanbreak;
    public AudioClip VanStart;
    public AudioSource audio;
    public GameObject smokeEffect;
    public GameObject Minigame;
    private GameObject thisMinigame;
    private BattleManager BM = null;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        GetIn();

    }

    // Update is called once per frame
    void Update()
    {
        if (driving)
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            if (xInput != 0)
            {
                Turn(xInput);
            }
            if (yInput != 0)
            {
                Move(yInput);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ResetVan();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GetOut();
            }
        }
        if(thisMinigame != null)
        {
            if(BM ==null)
            BM = thisMinigame.transform.GetChild(3).GetComponent<BattleManager>();
            if (BM != null)
            {
                if (BM.gameFinished)
                {
                    FixVan();
                }
            }
        }
    }

    public void StartQuest(string questItem)
    {
        Drummercontroller DC = player.GetComponent<Drummercontroller>();
        GetOut();
        DC.onQuest = true;
        DC.questItem = questItem;
        smokeEffect.SetActive(true);
        audio.PlayOneShot(Vanbreak);
    }

    public void GetOut()
    {
        driving = false;
        player.SetActive(true);
        player.GetComponent<Drummercontroller>().inPerson = true;
        player.transform.SetParent(null);
        myCam.gameObject.SetActive(false);
        float time = audio.time;
        audio.Stop();
        audio.clip = outsideAudio;
        audio.PlayScheduled(time);

    }

    public void FixVan()
    {
        Drummercontroller DC = player.GetComponent<Drummercontroller>();
        DC.onQuest = false;
        smokeEffect.SetActive(false);
        DC.inPerson = true;
        Destroy(thisMinigame);
        DC.myCam.gameObject.SetActive(true);
    }

    public void GetIn()
    {
        Drummercontroller DC = player.GetComponent<Drummercontroller>();
        Inventory Inv = player.GetComponent<Inventory>();
        if (DC.onQuest && Inv.HasItem(DC.questItem))
        {
            DC.myCam.gameObject.SetActive(false);
            DC.inPerson = false;
            if(thisMinigame==null)
                thisMinigame = Instantiate(Minigame);
            else
            {
                return;
            }
        }
        //Debug.Log($"On Quest:{DC.onQuest}, Waiting for Item:{DC.questItem}");

        if (!DC.onQuest)
        {
            driving = true;
            player.GetComponent<Drummercontroller>().inPerson = false;
            player.transform.SetParent(transform);
            player.SetActive(false);
            myCam.gameObject.SetActive(true);
            float time = audio.time;
            audio.Stop();
            audio.clip = InsideAduio;
            audio.PlayScheduled(time);
        }
    }
    private void ResetVan()
    {
        transform.position = vanStart.position;
        transform.rotation = vanStart.rotation;
    }

    private void Move(float yInput)
    {
        //rigid.AddForce()
        //rigid.AddForce((transform.forward * yInput) * speed * Time.deltaTime);
        transform.position += (transform.forward * yInput) * Time.deltaTime * speed;
    }

    private void Turn(float xInput)
    {
        transform.Rotate(0, (turningSpeed * xInput) * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetIn();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetIn();
            }
        }
    }


}
