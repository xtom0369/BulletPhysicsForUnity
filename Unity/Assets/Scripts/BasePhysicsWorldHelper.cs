﻿using BulletSharp;
using UnityEngine;

namespace BulletUnity
{
    public abstract class BasePhysicsWorldHelper : MonoBehaviour
    {

        internal int m__frameCount = 0;

        [HideInInspector]
        public BPhysicsWorld PhysicsWorld;
        internal BDefaultCollisionHandler m_collisionEventHandler = new BDefaultCollisionHandler();
        public void RegisterCollisionCallbackListener(BCollisionObject.BICollisionCallbackEventHandler toBeAdded)
        {
            if (m_collisionEventHandler != null) m_collisionEventHandler.RegisterCollisionCallbackListener(toBeAdded);
        }

        public void DeregisterCollisionCallbackListener(BCollisionObject.BICollisionCallbackEventHandler toBeRemoved)
        {
            if (m_collisionEventHandler != null) m_collisionEventHandler.DeregisterCollisionCallbackListener(toBeRemoved);
        }

        internal DiscreteDynamicsWorld m_ddWorld;
        internal CollisionWorld m_world;

        public float FixedTimeStep
        {
            get
            {
                return PhysicsWorld.fixedTimeStep;
            }
        }

        public float TimeStepRatio
        {
            get
            {
                return PhysicsWorld.timeStepRatio;
            }
        }

    }
}
