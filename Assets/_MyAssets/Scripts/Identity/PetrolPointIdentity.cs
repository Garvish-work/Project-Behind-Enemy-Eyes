using UnityEngine;

public class PetrolPointIdentity : MonoBehaviour
{
    [SerializeField] private PetrolPointIdentity nextPetrolPoint;

    public PetrolPointIdentity GetNextPetrolPoint()
    {
        return nextPetrolPoint;
    }
}
