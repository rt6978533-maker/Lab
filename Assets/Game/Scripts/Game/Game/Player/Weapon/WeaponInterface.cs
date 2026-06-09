using UnityEngine;

namespace Game.Player.Weapon {
    interface IFireable {
        void Fire();
    }

    interface IAddForceBulled {
        void AddForce(Vector3 dir);
    }
}
