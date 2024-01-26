using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour{
    [SerializeField] string characterName = "Player1";
    [SerializeField] int profBonus = 0;
    [SerializeField] bool hasF_Weapon = false;
    [SerializeField] int strMod = 0;
    [SerializeField] int dexmod = 0;
    private int hitMod = 0;
    private int lastD20Roll = 0;
    private int lastEnemyAC = 0;


    // Start is called before the first frame update
    void Start(){
        attack();
    }

    [ContextMenu ("Attack Enemy")]void attack(){
        //Get the hit modifier and then display the result of it on the console
        hitMod = getHitMod(hasF_Weapon, strMod, dexmod);
        Debug.Log(characterName + "\'s hit modifier is " + (hitMod > 0 ? "+" + hitMod: hitMod) );
        //Gets the enemy AC and displays the value
        lastEnemyAC = getEnemyAC();
        Debug.Log("The Enemy AC is " + lastEnemyAC);
        //get a random roll and display it on the console
        lastD20Roll = getD20Roll();
        Debug.Log(characterName + "rolled a " + lastD20Roll);
        //Says if the enemy hit
        int hitPower = hitMod + lastD20Roll;
        Debug.Log( (hitPower > lastEnemyAC ? characterName + "\'s attack landed.": "\'s attack missed") );

    }

    int getHitMod(bool hasFinesseWeapon, int strModifier, int dexModifier){
        int hitModifier;
        //Checks if the player has a finesse weapon
        if(hasFinesseWeapon == true){
            if(strModifier > dexModifier){
                hitModifier = profBonus + strModifier;
            }
            else{
                hitModifier = profBonus + dexModifier;
            }
        }
        //If they don't have a finesse weapon...
        else{
            hitModifier = profBonus + strModifier;
        }
        return hitModifier;
    }

    int getD20Roll(){
        int rRoll = Random.Range(1,20);
        lastD20Roll = rRoll;
        return rRoll;
    }
    int getEnemyAC(){
        int rEnemyAC = Random.Range(10,20);
        return rEnemyAC;
    }
}
