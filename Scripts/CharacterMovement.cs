using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterMovement : MonoBehaviour
    {
        private ElevatorController elevator = new ElevatorController();
        [SerializeField] private GameObject player;
        [SerializeField] private float timeInsideBuilding;
        public bool insideBuilding { get; set; }
        public bool playerElevatorChecked { get; set; }
        public bool entityElevatorChecked { get; set; }
        public bool canEnterBuilding { get; set; }
        public float currentTimeInsideBuilding { get; set; }
        public bool FirstLevel { get; set; }
        public bool LastLevel { get; set; }


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

        protected void MoveNPC(float speed, bool entityElevatorChecked , GameObject entity , Vector2 target)
        {
            float horizontalMove = speed * Time.deltaTime;

            if ((target.y > entity.transform.position.y) || (target.y < entity.transform.position.y)) {
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Elevator").transform.position, horizontalMove);
            } else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, horizontalMove);
                    
            }


            if (entityElevatorChecked && (target.y > entity.transform.position.y))
            {
                elevator.Elevate(entity);
                entityElevatorChecked = false;
                Debug.Log("Entity was elevated");
                
            }
            else if (entityElevatorChecked && (target.y < entity.transform.position.y))
            {
                elevator.Lower(entity);
            }

        }



    }
}