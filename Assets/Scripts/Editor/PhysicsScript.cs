using Assets.Scripts;
using UnityEditor;
using UnityEngine;
using static Assets.Scripts.PhysicsPreset;
using static Cinemachine.Editor.CinemachineLensPresets;

public class PhysicsScript : EditorWindow
{
    PhysicsPreset preset;

    [MenuItem("Tools/Physics Preset Applier")]
    public static void ShowWindow()
    {
        GetWindow<PhysicsScript>("Physics Preset Applier");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Physics Preset to Apply", EditorStyles.boldLabel);
        preset = (PhysicsPreset)EditorGUILayout.ObjectField("Preset", preset, typeof(PhysicsPreset), false);

        if (preset != null)
        {
            if (GUILayout.Button("Apply Preset"))
            {
                ApplyPreset();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Please assign a PhysicsPreset asset.", MessageType.Info);
        }
    }

    void ApplyPreset()
    {
        if (preset == null)
        {
            Debug.LogError("PhysicsPreset is not assigned!");
            return;
        }

        Physics.gravity = preset.gravity;
        Physics.defaultContactOffset = preset.defaultContactOffset;
        Physics.defaultSolverIterations = preset.solverIterationCount;
        Physics.defaultSolverVelocityIterations = preset.solverVelocityIterationCount;
        Physics.bounceThreshold = preset.bounceThreshold;

        Physics.defaultMaxDepenetrationVelocity = preset.defaultMaxDepenetrationVelocity;
        Physics.sleepThreshold = preset.sleepThreshold;
        Physics.queriesHitBackfaces = preset.queriesHitBackfaces;
        Physics.queriesHitTriggers = preset.queriesHitTriggers;
        Physics.autoSimulation = preset.simulationMode == PhysicsPreset.SimulationMode.FixedUpdate;
        Physics.autoSyncTransforms = preset.autoSyncTransforms;
        Physics.reuseCollisionCallbacks = preset.reuseCollisionCallbacks;
        Physics.invokeCollisionCallbacks = preset.invokeCollisionCallbacks;
        Physics.clothGravity = preset.clothGravity;
        Physics.improvedPatchFriction = preset.improvedPatchFriction;
        Physics.defaultMaxAngularSpeed = preset.defaultMaxAngularSpeed;

        Debug.Log("Physics Preset Applied!");
    }
}
