using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);   
        
        //firstCard가 비었다면.
        if(GameManager.Instance.firstCard == null)
        {
            //firstCard에 내 정보를 넘겨준다.
            GameManager.Instance.firstCard = this;
        }
        //firstCard가 비어있지 않다면.
        else
        {
            //secondCard에 내 정보를 넘겨준다.
            GameManager.Instance.secondCard = this;
            //Mached 함수를 호출해 준다.
            GameManager.Instance.Matched();
        }

    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(this.gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
