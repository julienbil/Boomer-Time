using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite player, lawnmower, truck, temp;
    public PlayerMovement playmov;
    public bool isLawnmower;
    public PlayerWeapon pWeapon;
    public Rigidbody2D rb;
    public bool isTruck;
    public bool isNormal;
    public AudioSource source;
    public AudioClip powerupsound;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pWeapon = gameObject.GetComponent<PlayerWeapon>();
        source = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        source.clip = powerupsound;
        playmov = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Lawnmower Pup" || other.name == "Lawnmower Pup(Clone)")
        {
            TurnIntoLawnmower();
        }
        if (other.name == "Truck Pup" || other.name == "Truck Pup(Clone)")
        {
            TurnIntoTruck();
        }
        if (other.tag == "Weapon")
        {
            EquipWeapon(other.name);
            FindObjectOfType<AudioMAnager>().Play("weaponpick");
        }
        if (other.tag == "Weapon" || other.tag == "Powerup")
        Destroy(other.gameObject);
    }

    void EquipWeapon(string weaponname)
    {
        UnequipWeapon(pWeapon.currentWeapon);
        if (weaponname == "Baseball Pup" || weaponname == "Baseball Pup(Clone)")
        {
            
            pWeapon.currentWeapon = "Baseball";
            pWeapon.baseball.GetComponent<Weapon>().durability = 10;
            pWeapon.baseball.SetActive(true);
        }
        if (weaponname == "Torch Pup" || weaponname == "Torch Pup(Clone)")
        {
            pWeapon.currentWeapon = "Torch";
            pWeapon.torch.GetComponent<Weapon>().durability = 5;
            pWeapon.torch.SetActive(true);
        }
        if (weaponname == "Hammer Pup" || weaponname == "Hammer Pup(Clone)")
        {
            pWeapon.currentWeapon = "Hammer";
            pWeapon.hammer.GetComponent<Weapon>().durability = 5;
            pWeapon.hammer.SetActive(true);
        }
        if (weaponname == "TNT Pup" || weaponname == "TNT Pup(Clone)")
        {
            pWeapon.currentWeapon = "TNT";
            pWeapon.tnt.GetComponent<Weapon>().durability = 1;
            pWeapon.tnt.SetActive(true);
        }
        if (weaponname == "Grenade Launcher Pup" || weaponname == "Grenade Launcher Pup(Clone)")
        {
            pWeapon.currentWeapon = "Grenade Launcher";
            pWeapon.grenadelauncher.GetComponent<Weapon>().durability = 6;
            pWeapon.grenadelauncher.SetActive(true);
        }
    }

    void UnequipWeapon(string weaponname)
    {
        if (weaponname == "Baseball")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.baseball.SetActive(false);
        }
        if (weaponname == "Torch")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.torch.SetActive(false);
        }
        if (weaponname == "Hammer")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.hammer.SetActive(false);
        }
        if (weaponname == "TNT")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.tnt.SetActive(false);
        }
        if (weaponname == "Grenade Launcher")
        {
            pWeapon.currentWeapon = "None";
            pWeapon.grenadelauncher.SetActive(false);
        }
    }

    void TurnIntoLawnmower()
    {
        StopAllCoroutines();
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
            playmov.driving = true;
            anim.SetBool("isLawnmower", true);
            anim.SetBool("isNormal", false);
            anim.SetBool("isTruck", false);
            gameObject.GetComponents<CapsuleCollider2D>()[0].enabled = false;
            gameObject.GetComponents<CapsuleCollider2D>()[1].enabled = true;
            //rb.bodyType = RigidbodyType2D.Kinematic;
            playmov.rb.velocity = Vector3.zero;
            playmov.speed = 2;
            gameObject.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
        }
        if (isTruck)
        {
            anim.SetBool("isLawnmower", false);
            anim.SetBool("isNormal", false);
            anim.SetBool("isTruck", true);
            playmov.driving = true;
            gameObject.GetComponents<CapsuleCollider2D>()[1].enabled = false;
            gameObject.GetComponents<CapsuleCollider2D>()[0].enabled = true;
            //rb.bodyType = RigidbodyType2D.Kinematic;
            playmov.rb.velocity = Vector3.zero;
            playmov.rb.mass = 500;
            playmov.rb.drag = 1f;
            playmov.speed = 5;
            gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
        }
        if (isNormal)
        {
            anim.SetBool("isLawnmower", false);
            anim.SetBool("isTruck", false);
            anim.SetBool("isNormal", true);
            playmov.driving = false;
            gameObject.GetComponents<CapsuleCollider2D>()[0].enabled = false;
            gameObject.GetComponents<CapsuleCollider2D>()[1].enabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            playmov.rb.drag = 10;
            playmov.rb.mass = 0.1f;
            playmov.speed = 100;
            gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
    }
}
