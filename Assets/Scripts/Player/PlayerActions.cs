using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerActions : MonoBehaviour
{
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] public Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	public CameraShake cameraShake;

	[Header("Events")]
	[Space]
	
	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public Animator animator;
	public ParticleSystem dust;

	public SoundManager sound;

	public PlayerMovement playerMovement;
	public WallClimbing wallClimbing;

	public Rock rockPrefab;
	public bool _rockActive;
	public int hp = 3;
	public int ammo = 5;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

    private void Start()
    {
		m_Rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
	}

	private void FixedUpdate()
	{
		GroundedCheck();
	}

	private void GroundedCheck()
    {
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;

				if (!wasGrounded)
					OnLandEvent.Invoke();

				//StartCoroutine(cameraShake.Shake(.15f, .4f));
				//StartCoroutine(cameraShake.Shaking());
			}
		}
	}

	public Transform kerek;
	public GameObject player;

	private void Update()
    {

		if (!(ammo <= 0))
		{
			if (Input.GetButtonDown("Fire1"))
			{
				ThrowSmol();
			}
			if (Input.GetButtonDown("Fire2"))
			{
				ThrowBig();
			}
		}

	}

	private void Reload()
	{
		ammo = 50;
		animator.SetTrigger("isReloading");
	}

	private void ThrowSmol() //brrrrr
	{
		if (!_rockActive)
		{
			Rock rock = Instantiate(this.rockPrefab, this.transform.position, Quaternion.identity); //no rotation = Quaternion.identity
            if(!playerMovement.m_FacingRight)
            {
				rock.direction = rock.direction * -1;
			}
			rock.destroyed += RockDestroyed;
			_rockActive = true;
			animator.SetTrigger("isThrowing");
			FindObjectOfType<SoundManager>().Play("Throwing");
		}
	}
	private void ThrowBig() //brrrrr
	{
		if (!_rockActive)
		{
			Rock rock = Instantiate(this.rockPrefab, this.transform.position, Quaternion.identity); //no rotation = Quaternion.identity
			rock.direction = rock.direction * 2;
			if (!playerMovement.m_FacingRight)
			{
				rock.direction = rock.direction * -1;
			}
			rock.destroyed += RockDestroyed;
			_rockActive = true;
			animator.SetTrigger("isThrowing");
			FindObjectOfType<SoundManager>().Play("Throwing");
		}
	}
	private void RockDestroyed()
	{
		_rockActive = false;
		ammo = ammo - 1;
	}

	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy") || collision.CompareTag("Beam"))
		{
			hp--;
			if (hp == 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
        if (collision.CompareTag("RockCollection"))
		{
			Reload();
			
		}
		if(collision.CompareTag("RockCollection") && ammo > 0)
        {
			GameObject.Find("Adam_Basic(Clone)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
    {
		//if (collision.CompareTag("RockCollection"))
		//{
		//	if (ammo > 0)
		//	{
		//		m_Rigidbody2D.constraints = RigidbodyConstraints2D.None;
		//		m_Rigidbody2D.isKinematic = false;
		//	}
		//}
	}

	void CreateDust()
    {
		dust.Play();
    }

}