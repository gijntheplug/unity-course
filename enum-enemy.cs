public class Enemy : MonoBehaviour{
  public enum EnemyType {Zombie, Robot, Ghost}
  [SerializedField]
  private EnemyType type;

  private void Start(){
    switch(type){
        case: EnemyType.Zombie:
          Debug.Log("This is a Zombie.");
          break;
        case: EnemyType.Robot:
          Debug.Log("This is a Robot.");
          break;
        case: EnemyType.Ghost:
          Debug.Log("This is a Ghost.");
          break;
    }
  }
}
