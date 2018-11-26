using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterMovement : MonoBehaviour
    {
        private ElevatorTriggerHandler elevator = new ElevatorTriggerHandler();
        [SerializeField] private GameObject player;
        [SerializeField] private float timeInsideBuilding;
        public bool insideBuilding { get; set; }
        public bool ElevatorChecked { get; set; }
        public bool canEnterBuilding { get; set; }
        public float currentTimeInsideBuilding { get; set; }
        public bool FirstLevel { get; set; }
        public bool LastLevel { get; set; }
        public float movementSpeed;
        protected SpriteRenderer rend;

        protected void MoveRobber(float speed, bool elevatorChecked, bool insideBuilding,
            bool canEnterBuilding, SpriteRenderer rend)
        {
            
            if (!insideBuilding)
            {
                float horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
                transform.position = new Vector2(transform.position.x + horizontalMove, transform.position.y);
            }


            if (insideBuilding)
            {

                currentTimeInsideBuilding -= Time.deltaTime;
               
                if (currentTimeInsideBuilding < 0)
                {
                    rend.sortingLayerName = "Character";
                    this.insideBuilding = false;
                }
            }
            if (canEnterBuilding)
            {

                if (Input.GetKeyDown(KeyCode.W) && !insideBuilding)
                {
                    this.currentTimeInsideBuilding = timeInsideBuilding;
                    rend.sortingLayerName = "Background";
                    this.insideBuilding = true;

                }
                else if (Input.GetKeyDown(KeyCode.S))
                {

                    rend.sortingLayerName = "Character";
                    this.insideBuilding = false;
                }

            }


            if (elevatorChecked)
            {
                if (Input.GetKeyDown(KeyCode.W) && !LastLevel)
                {
                    elevator.Elevate(player);
                    this.LastLevel = true;
                    this.FirstLevel = false;
                }
                else if (Input.GetKeyDown(KeyCode.S) && !FirstLevel) {
                    elevator.Lower(player);
                    this.LastLevel = false;
                    this.FirstLevel = true;

                }

            }
        }

        protected void MoveNPC(float speed , EntityMovement entity , Vector2 target, GameObject entityObject)
        {
            float horizontalMove = speed * Time.deltaTime;

            if ((target.y > Mathf.Ceil(entity.transform.position.y))) {
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Elevator").transform.position, horizontalMove);
            } else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, horizontalMove);
                    
            }
            
            
            if (entity.ElevatorChecked && (target.y > entity.transform.position.y))
            {
                elevator.Elevate(entity);
                entity.ElevatorChecked = false;
                Debug.Log("Entity was elevated");
                
                
            }
            //else if (entity.entityElevatorChecked && (target.y < entity.transform.position.y))
            //{
            //    elevator.Lower(entity);
            //}

            if (target.x == entity.transform.position.x)
            {
                DestroyImmediate(entityObject);
                Debug.Log("Another one bites the dust");
                Spawner.entityExists--;
            }
            
        }



    }
}