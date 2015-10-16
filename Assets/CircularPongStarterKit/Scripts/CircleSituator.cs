// Created 15.10.2015 
// Modified by Gorbach Alex 15.10.2015 at 14:35

namespace Assets.Scripts.Game.Bonuses.FortuneWheel.Controls.TimeVisualizers {
    #region References

    using System;
    using UnityEngine;

    #endregion

    internal class CircleSituator : MonoBehaviour {
        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private CircleCollider2D _collider;

        [SerializeField]
        private int _count;

        private void Awake() {
            var radius = _collider.radius;
            var itemAngle = 360f / _count;
            var angle = 0f;
            for (var i = 0; i < _count; i++) {
                var obj = Instantiate(_prefab) as GameObject;
                obj.transform.SetParent(transform);
                obj.transform.localPosition = new Vector2(
                    radius * Mathf.Cos(angle * Mathf.Deg2Rad),
                    radius * Mathf.Sin(angle * Mathf.Deg2Rad));
                obj.transform.localScale = Vector3.one;
                angle += itemAngle;
            }
        }
    }
}