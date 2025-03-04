using UnityEngine;

public class Bird : MonoBehaviour
{
	public bool flying;

	public float flyTime;

	public Animator animator;

	public float rand;

	public float speed;

	public AudioSource wingFlaps;

	private void Start()
	{
		rand = Random.Range(2f, 5f);
		speed = Random.Range(1.5f, 2.5f);
		base.transform.eulerAngles = new Vector3(0f, (!(Random.value > 0.5f)) ? 180 : 0, 0f);
	}

	public void Update()
	{
		float num = float.PositiveInfinity;

		if (num < 1.5f && !flying)
		{
			Fly();
		}
		if (flying)
		{
			flyTime += Time.deltaTime;
			Vector3 right = base.transform.right;
			right.y += (Mathf.Sin(Time.time * rand + rand) + 1.1f) * 0.3f;
			right.y += Mathf.Sin(Time.time * 20f + rand * 10f) * 0.1f * rand;
			base.transform.right = right;
			base.transform.Translate(speed * Time.deltaTime * base.transform.right, Space.World);
			base.transform.forward = ((right.x < 0f) ? Vector3.back : Vector3.forward);
		}
		if (flyTime > 5f)
		{
			// Object.Destroy(base.gameObject);
		}
	}

	public void Fly()
	{
		flying = true;
		animator.Play("Fly");
		wingFlaps.Play();
		wingFlaps.pitch = Random.Range(1.2f, 1.5f);
	}
}
