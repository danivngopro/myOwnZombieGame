using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public Transform firePoint; //that is an empyobject of where i want the bullet to shoot from
	public int damage = 25;
	//public GameObject impactEffect;
	public LineRenderer line;
	public float offset;
	void Update()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
		if (Input.GetButtonDown("Fire1"))
		{
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot()
	{
		RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, firePoint.right);
		if (hitinfo)
		{
			Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
			print(enemy);
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}
			//Instantiate(impactEffect, hitinfo.point, Quaternion.identity);

			line.SetPosition(0, firePoint.position);
			line.SetPosition(1, hitinfo.point);
		}
		else
		{
			line.SetPosition(0, firePoint.position);
			line.SetPosition(1, firePoint.position + firePoint.right * 100);
		}

		line.enabled = true;

		yield return new WaitForSeconds(0.02f);

		line.enabled = false;
	}

}