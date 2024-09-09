using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//helpURL
[HelpURL("https://docs.unity3d.com/")]
//AddComponentMenu
[AddComponentMenu("Game/Player Behaviour")]
[ExecuteAlways]
public class NewBehaviourScript : MonoBehaviour
{
        //stats
        [Header("Player Stats")]
        [Range(0,100)]
        public float health;
        
        [Range(0,50)]
        public float attackPT;
        
        //descriptions
        [Header("Player Description")]
        [Multiline(4)]
        public string shortDescription;
        
        [TextArea(4,6)]
        public string longDescription;
        
        //tooltips
        [Space, Tooltip("Should we use the long description...")]
        public bool useLongDescription;
        
        //HiddenValues
        [HideInInspector]
        public bool hiddenBool;
        
        //Serialization
        [Space, SerializeField]
        private bool privateSerializedField;
        
        //Context Menus
        [ContextMenu("Randomize Player Stats")]
        public void RandomizePlayerStats()
        {
        health = Random.Range(0,101);
        attackPT = Random.Range(0,51);
        }
        
        private void Start()
        {
        OnValidate();
}
        //Editor Messages
        
        //OnValidate
        private void OnValidate()
        {
        //Example validation use case
        if (attackPT > health)
        {
            Debug.Log("HP can't be larger than attack point.");
}
}
        //OnDrawGizmos
        private void OnDrawGizmos()
        {
        //always draw a sphere
        Gizmos.DrawWireSphere(transform.position, 5);
}
        //OnDrawGizmosSelected
        private void OnDrawGizmosSelected()
        {
        Gizmos.DrawSphere(transform.position, 2);
}
        //Reset
        private void Reset()
        {
        health = 10;
        attackPT = 5;
        shortDescription = "Default Description";
}
        
}
