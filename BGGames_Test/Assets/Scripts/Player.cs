using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class Player
    {
        private PlayerView _view;

        public Player()
        {
            var playerView = Object.Instantiate(Resources.LoadAll<PlayerView>("")[0].gameObject);
            _view = playerView.GetComponent<PlayerView>();
            _view.HidePlayer();
        }

        public void SetPosition(Vector3 position) => _view.RigidBody.position = position;

        public void Hide() => _view.HidePlayer();

        public void Show() => _view.ShowPlayer();

        public void StartMovingToPoint(Vector3 targetPoint)
        {
            _view.NavMeshAgent.SetDestination(targetPoint);
        }
    }
}