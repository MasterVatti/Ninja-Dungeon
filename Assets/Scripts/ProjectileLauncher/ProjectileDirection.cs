using UnityEngine;

namespace ProjectileLauncher
{
    public struct ProjectileDirection
    {
        public Vector3 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }
        
        private Vector3 _direction;
        private Vector3 _position;
    }
}
