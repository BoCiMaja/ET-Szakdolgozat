using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] public Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	public float jumpDelay = 0.5f;
	public bool doubleJumpReady = false;
	public CameraShake cameraShake;

	[Header("Events")]
	[Space]
	
	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public bool jump = false;
	private int extraJump;
	public int extraJumpValue;

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
		extraJump = extraJumpValue;
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
		jump = false;
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		animator.SetBool("isTurning", false);

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

	
	private void Update()
    {
		if (m_Grounded == true)
		{
			extraJump = extraJumpValue;			
        }

		Jump();

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
		//if (Input.GetButtonDown("Reload")){
		//	Reload();
		//}
	}

	private void Jump()
    {
		if (Input.GetButtonDown("Jump") && extraJump > 0)
		{
			CreateDust();
			FindObjectOfType<SoundManager>().Play("Jump"); //jump hang hivas
			FindObjectOfType<SoundManager>().Stop("Walking");
			FindObjectOfType<SoundManager>().Stop("Running");
			jump = true;
			animator.SetBool("isJumping", true);
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			if (doubleJumpReady)
			{
				DoubleJump();
			}
			else
			{
				PrepareJump();
			}
		}
	}

	private void Reload()
	{
		ammo = 5;
		animator.SetTrigger("isReloading");
	}

	private void ThrowSmol() //brrrrr
	{
		if (!_rockActive)
		{
			Rock rock = Instantiate(this.rockPrefab, this.transform.position, Quaternion.identity); //no rotation = Quaternion.identity
            if(!m_FacingRight)
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
			if (!m_FacingRight)
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
		if (collision.CompareTag("Enemy"))
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
	}


	void DoubleJump()
    {
		doubleJumpReady = false;
		m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce/4));
		animator.SetBool("isJumping", false);
		animator.SetBool("jumpedAlready", true);
		extraJump--;
		//cameraShake.start = true;
	}
	void PrepareJump()
    {
		//this is where the handling happens
		CancelInvoke("NoJump");
		Invoke("NoJump", jumpDelay);
		doubleJumpReady = true;
	}

	void NoJump()
    {
		doubleJumpReady = false;
	}

	void CreateDust()
    {
		dust.Play();
    }

}