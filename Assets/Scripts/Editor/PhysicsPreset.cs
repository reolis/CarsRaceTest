using System;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "NewPhysicsPreset", menuName = "Physics/Physics Preset")]
    public class PhysicsPreset : ScriptableObject
    {
        public Vector3 gravity = new Vector3(0f, -20f, 0f);

        public PhysicsMaterial defaultMaterial = null;
        public float bounceThreshold = 2f;
        public float defaultMaxDepenetrationVelocity = 10f;
        public float sleepThreshold = 0.005f;
        public float defaultContactOffset = 0.01f;
        public int solverIterationCount = 6;
        public int solverVelocityIterationCount = 1;

        public bool queriesHitBackfaces = false;
        public bool queriesHitTriggers = false;

        public bool enableAdaptiveForce = true;
        public float clothInterCollisionDistance = 0.1f;
        public float clothInterCollisionStiffness = 0.2f;

        public SimulationMode simulationMode = SimulationMode.FixedUpdate;

        public bool autoSyncTransforms = false;

        public bool reuseCollisionCallbacks = false;
        public bool invokeCollisionCallbacks = true;

        public bool clothInterCollisionSettingsToggle = true;
        public Vector3 clothGravity = Vector3.zero;

        public ContactPairsMode contactPairsMode = ContactPairsMode.DefaultContactPairs;

        public BroadphaseType broadphaseType = BroadphaseType.SweepAndPrune;

        public FrictionType frictionType = FrictionType.Patch;

        public bool enableEnhancedDeterminism = false;
        public bool improvedPatchFriction = false;

        public SolverType solverType = SolverType.ProjectedGaussSeidel;

        public float defaultMaxAngularSpeed = 7f;
        public int scratchBufferChunkCount = 4;
        public long currentBackendId = 4072204805;
        public float fastMotionThreshold = 3.402823e+38F;

        public enum SimulationMode
        {
            FixedUpdate,
            Continuous
        }

        public enum ContactPairsMode
        {
            DefaultContactPairs,
            AllContactPairs
        }

        public enum BroadphaseType
        {
            SweepAndPrune,
            AxisSweep3D,
            DynamicBinning
        }

        public enum FrictionType
        {
            Patch,
            OneWayInteraction
        }

        public enum SolverType
        {
            ProjectedGaussSeidel,
            Temporal
        }
    }
}