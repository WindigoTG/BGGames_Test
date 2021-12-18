using UnityEngine;

namespace BGGames_Test
{
    public class Finish : MonoBehaviour
    {
        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponentInParent<Player>();

            if (player)
                player.TriggerFinish();
        }

        #endregion
    }
}