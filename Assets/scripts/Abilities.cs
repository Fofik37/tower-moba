using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown = 3;

    public Canvas ability1Canvas;
    public Image ability1;

    [Header("Ability 2")]
    public Image abilityImage2;
    public Text abilityText2;
    public KeyCode ability2Key;
    public float ability2Cooldown = 5;



    [Header("Ability 3")]
    public Image abilityImage3;
    public Text abilityText3;
    public KeyCode ability3Key;
    public float ability3Cooldown = 9;

    private bool isAbility1Cooldown = false;
    private bool isAbility2Cooldown = false;
    private bool isAbility3Cooldown = false;

    private float currentAbility1Cooldown;
    private float currentAbility2Cooldown;
    private float currentAbility3Cooldown;

    private Vector3 position;
    private RaycastHit hit;
    private Ray ray;

    public GameObject player;
    public GameObject Tower1;
    public GameObject Plane;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        abilityText1.text = "";
        abilityText2.text = "";
        abilityText3.text = "";

        ability1.enabled = false;

        ability1Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    

        Ability1Input();
        Ability2Input();
        Ability3Input();

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, abilityText3);

        Ability1Canvas();


        Build();
    }

    private void Build()
    {
        if (Input.GetKeyDown(KeyCode.B) && player.GetComponent<Stats>().money >= 10)
        {
            Plane.GetComponent<BuildingsGrid>().StartPlacingBuilding(Tower1.GetComponent<Building>());
        }


    }

    private void Ability1Canvas()
    {
        if (ability1.enabled)
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            Quaternion ab1Canvas = Quaternion.LookRotation(position - transform.position);
            ab1Canvas.eulerAngles = new Vector3(0,ab1Canvas.eulerAngles.y, ab1Canvas.eulerAngles.z);

            ability1Canvas.transform.rotation = Quaternion.Lerp(ab1Canvas, ability1Canvas.transform.rotation, 0);
        }

    }

    private void Ability1Input()
    {
        if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            ability1Canvas.enabled = true;
            ability1.enabled = true;

            Cursor.visible = true;
        }
        if (ability1.enabled && Input.GetMouseButtonDown(0))
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;

            ability1Canvas.enabled = false;
            ability1.enabled = false;
        }
    }

    private void Ability2Input()
    {
        if (Input.GetKeyDown(ability2Key) && !isAbility2Cooldown)
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
        }
    }

    private void Ability3Input()
    {
        if (Input.GetKeyDown(ability3Key) && !isAbility3Cooldown)
        {
            isAbility3Cooldown = true;
            currentAbility3Cooldown = ability3Cooldown;
        }
    }
    
   private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
