using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite player, lawnmower, truck, temp;
    public PlayerMovement playmov;
    public bool isLawnmower;
    public PlayerWeapon pWeapon;
    public bool isTruck;
    public bool isNormal;
    public AudioSource source;
    public AudioClip powerupsound;

    // Start is called before the first frame update
    void Start()
    {
        pWeapon = gameObject.GetComponent<PlayerWeapon>();
        source = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        source.clip = powerupsound;
        playmov = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Lawnmower Pup")
        {
            TurnIntoLawnmower();
        }
        if (other.name == "Truck Pup")
        {
            TurnIntoTruck();
        }
        if (other.tag == "Weapon")
        {
            EquipWeapon(other.GetComponent<Weapon>().weaponname);
        }
        if (other.tag == "Weapon" || other.tag == "Powerup")
        Destroy(other.gameObject);
    }

    IEnumerator Transforming()
    {
        source.Play();
        Time.timeScale = 0;
        playmov.canMove = false;
        yield return new WaitForSecondsRealtime(0.5f);
        playmov.canMove = true;
        Time.timeScale = 1;
    }

    void EquipWeapon(string weaponname)
    {
        UnequipWeapon(pWeapon.currentWeapon);
        if (weaponname == "Baseball")
        {
            pWeapon.currentWeapon = "Baseball";
            pWeapon.baseball.SetActive(true);
        }
        //if (weaponname == "Torch")
        //{
        //    pWeapon.currentWeapon = "Torch";
        //    pWeapon.torch.SetActive(true);
        //}
        //if (weaponname == "Golden Hammer")
        //{
        //    pWeapon.currentWeapon = "Golden Hammer";
        //    pWeapon.goldenhammer.SetActive(true);
        //}
    }

    void UnequipWeapon(string weaponname)
    {
        if (weaponname == "Baseball")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.baseball.SetActive(false);
        }
        if (weaponname == "None")
        {
            return;
        }
    }

    void TurnIntoLawnmower()
    {
        StopAllCoroutines();
        StartCoroutine(Transforming());
        gameObject.GetComponent<SpriteRenderer>().sprite = lawnmower;
        TurnIntoBoomer();
        IEnumerator BeLawnmower()
        {
            isLawnmower = true;
            isNormal = false;
            yield return new WaitForSeconds(10);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            TurnIntoBoomer();
        }
        StartCoroutine(BeLawnmower());
    }

    void TurnIntoTruck()
    {
        StopAllCoroutines();
        StartCoroutine(Transforming());
        gameObject.GetComponent<SpriteRenderer>().sprite = truck;
        TurnIntoBoomer();
        IEnumerator BeTruck()
        {
            isTruck = true;
            isNormal = false;
            yield return new WaitForSeconds(10);
            gameObject.GetComponent<SpriteRenderer>().sprite = player;
            TurnIntoBoomer();
        }
        StartCoroutine(BeTruck());
    }

    void TurnIntoBoomer()
    {
        isTruck = false;
        isLawnmower = false;
        isNormal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLawnmower)
        {
            playmov.speed = 150;
        }
        if (isTruck)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            playmov.rb.mass = 25;
            playmov.rb.drag = 1f;
            playmov.speed = 4000;
        }
        if (isNormal)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            playmov.rb.drag = 10;
            playmov.rb.mass = 0.1f;
            playmov.speed = 100;
        }
    }
}
