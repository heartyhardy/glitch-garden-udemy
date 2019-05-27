using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    [Header("Cost")]
    [SerializeField] int starCost = 100;

    public int getStarCost()
    {
        return starCost;
    }

    public void Die(HealthPoints hp)
    {
        Destroy(gameObject);
        PlayOnDeathVFX(hp);
    }

    public void Damaged(HealthPoints hp)
    {
        PlayOnHitVFX(hp);
    }

    private void PlayOnDeathVFX(HealthPoints hp)
    {
        GameObject onHit = Instantiate(
            hp.getOnDeathVFX(),
            gameObject.transform.position,
            gameObject.transform.rotation
        );
        Destroy(onHit, .5f);
    }

    private void PlayOnHitVFX(HealthPoints hp)
    {
        GameObject onHit = Instantiate(
            hp.getOnHitVFX(),
            gameObject.transform.position,
            gameObject.transform.rotation
        );
        Destroy(onHit, .5f);
    }

    #region Support functions

    public void AddStars(int points)
    {
        FindObjectOfType<StarDisplay>().AddStars(points);
    }

    #endregion
}
