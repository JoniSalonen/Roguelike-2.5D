using JS.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JS.Inventory{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        public int movementSpeedItem; // Represents the movement speed item

        [SerializeField]
        public int lifeItem; // Represents the life item

        [SerializeField]
        public int LifeRegenItem; // Represents the life regeneration item

        [SerializeField]
        public int DamageItem; // Represents the damage item

        [SerializeField]
        public int LifeSteal; // Represents the life steal item

        [SerializeField]
        public int AttackSpeedItem; // Represents the attack speed item

        [SerializeField]
        public int ArmourItem; // Represents the armour item

        [SerializeField]
        public int CritMultItem; // Represents the critical multiplier item

        [SerializeField]
        public int CritChanceItem; // Represents the critical chance item

        [SerializeField]
        public int coins; // Represents the number of coins



        // List<Sprite> images = new List<Sprite>();

        //public Sprite testSprite;
        //public Image imagePrefab;

        //private void Start()
        //{
        //    images.Add(testSprite);

        //    Image imageInstance = Instantiate(imagePrefab);

        //    imageInstance.transform.SetParent(transform, true);

        //    imageInstance.sprite = images[1];
        //}

        //public void AddSprite(int index)
        //{

        //}

    }
}
