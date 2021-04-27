
using UnityEngine;

public class Bullet : MonoBehaviour
{
  

    //assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //stats
    [Range (0f,1f)]
    public float bounciness;
    public bool useGravity;

    //damage
    public int explosionDamage;
    public float explosionRange;

    //LifeTime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if (collisions > maxCollisions) Explode();

        //CountDown lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }

    private void Explode()
    {
        //instantiate explosion
        //if (explosion! = null) Instantiate(explosion, transform.position, Quaternion.identity);

        //check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //example
            ////enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);
        }

        Invoke("Delay", 0.05f);

    }

    private void Delay()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //don't count collision with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //count up collision
        collisions++;

        //Explode if bullet hits an enemy directly and explode on touch is activated
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }

    private void Setup()
    {
        //create new physics material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        //assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //set gravity
        rb.useGravity = useGravity;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
