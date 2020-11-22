using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public GameObject shootPistol;
    public GameObject shootSMG;
    public GameObject shootPUMP;
    public GameObject pistolAmmo1;
    public GameObject pistolAmmo2;
    public GameObject SMGAmmo1;
    public GameObject SMGAmmo2;
    public GameObject PUMPAmmo1;
    public GameObject PUMPAmmo2;
    public GameObject pistolIcon;
    public GameObject SMGIcon;
    public GameObject PumpIcon;
    public Button BPistol;
    public Button BSMG;
    public Button BPumpaction;
    public GameObject Pistol;
    public GameObject SMG;
    public GameObject Pumpaction;
    // Start is called before the first frame update
    void Start()
    {
        BPistol.onClick.AddListener(pistolTrue);
        BSMG.onClick.AddListener(SMGTrue);
        BPumpaction.onClick.AddListener(PumpTrue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void pistolTrue()
    {
        shootPistol.gameObject.SetActive(true);
        shootSMG.gameObject.SetActive(false);
        shootPUMP.gameObject.SetActive(false);
        pistolAmmo1.gameObject.SetActive(true);
        pistolAmmo2.gameObject.SetActive(true);
        SMGAmmo1.gameObject.SetActive(false);
        SMGAmmo2.gameObject.SetActive(false);
        PUMPAmmo1.gameObject.SetActive(false);
        PUMPAmmo2.gameObject.SetActive(false);
        pistolIcon.gameObject.SetActive(true);
        SMGIcon.gameObject.SetActive(false);
        PumpIcon.gameObject.SetActive(false);
        Pistol.gameObject.SetActive(true);
        SMG.gameObject.SetActive(false);
        Pumpaction.gameObject.SetActive(false);
    }
    void SMGTrue()
    {
        shootPistol.gameObject.SetActive(false);
        shootSMG.gameObject.SetActive(true);
        shootPUMP.gameObject.SetActive(false);
        pistolAmmo1.gameObject.SetActive(false);
        pistolAmmo2.gameObject.SetActive(false);
        SMGAmmo1.gameObject.SetActive(true);
        SMGAmmo2.gameObject.SetActive(true);
        PUMPAmmo1.gameObject.SetActive(false);
        PUMPAmmo2.gameObject.SetActive(false);
        pistolIcon.gameObject.SetActive(false);
        SMGIcon.gameObject.SetActive(true);
        PumpIcon.gameObject.SetActive(false);
        Pistol.gameObject.SetActive(false);
        SMG.gameObject.SetActive(true);
        Pumpaction.gameObject.SetActive(false);
    }
    void PumpTrue()
    {
        shootPistol.gameObject.SetActive(false);
        shootSMG.gameObject.SetActive(false);
        shootPUMP.gameObject.SetActive(true);
        pistolAmmo1.gameObject.SetActive(false);
        pistolAmmo2.gameObject.SetActive(false);
        SMGAmmo1.gameObject.SetActive(false);
        SMGAmmo2.gameObject.SetActive(false);
        PUMPAmmo1.gameObject.SetActive(true);
        PUMPAmmo2.gameObject.SetActive(true);
        pistolIcon.gameObject.SetActive(false);
        SMGIcon.gameObject.SetActive(false);
        PumpIcon.gameObject.SetActive(true);
        Pistol.gameObject.SetActive(false);
        SMG.gameObject.SetActive(false);
        Pumpaction.gameObject.SetActive(true);
    }
}
