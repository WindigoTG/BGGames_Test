using UnityEngine;

namespace BGGames_Test
{
    public class Trap : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            var player = other.GetComponentInParent<Player>();

            if (player)
                player.GetDamaged();
        }
    }
}