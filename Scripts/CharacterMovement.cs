using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterMovement : MonoBehaviour
    {
        private ElevatorController elevator = new ElevatorController();
        [SerializeField] private GameObject player;
        [SerializeField] private float timeInsideBuilding;
        public bool insideBuilding { get; set; }
        public bool elevatorChecked { get; set; }
        public bool canEnterBuilding { get; set; }
        public float currentTimeInsideBuilding { get; set; }
            
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
                if (Input.GetKeyDown(KeyCode.W))
                {
                    elevator.Elevate(player);
             
                    this.elevatorChecked = false;
                }
            }
        }

        protected void MoveNPC(float speed, GameObject entity)
        {
            float horizontalMove = speed * Time.deltaTime;
            entity.transform.position = new Vector2(entity.transform.position.x + horizontalMove, entity.transform.position.y);
        }
        
        
        
    }
}