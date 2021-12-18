using UnityEngine;

namespace BGGames_Test
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponentInParent<Player>();

            if (player)
                player.TriggerFinish();
        }
    }
}