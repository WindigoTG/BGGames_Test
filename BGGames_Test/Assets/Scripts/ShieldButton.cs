using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BGGames_Test
{
    public class ShieldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Events

        public event Action ButtonPressed;
        public event Action ButtonReleased;

        #endregion


        #region Methods

        public void OnPointerDown(PointerEventData eventData)
        {
            ButtonPressed?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ButtonReleased?.Invoke();
        }

        #endregion
    }
}