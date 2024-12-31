using System;
using ProjectFeatures.ZenjectModule.Runtime;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Zenject;
using UEditor = UnityEditor.Editor;

namespace ProjectEditor
{
    [CustomEditor(typeof(ProjectContext))]
    public class ProjectContextEditor : UEditor
    {
        private const string MonoInstallersPropName = "_monoInstallers";

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Sort installers"))
            {
                SortScripts();
                CollapseComponents();
            }

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            base.OnInspectorGUI();
        }

        private void SortScripts()
        {
            var context = target as ProjectContext;
            if (context == null)
                return;

            var installers = context.gameObject.GetComponents<MonoInstaller>();

            SortAndMoveComponents(installers);
            SetMonoInstallers(installers);
        }

        private void SortAndMoveComponents(MonoInstaller[] components)
        {
            var arraySize = components.Length;
            var lastElementName = nameof(ZenjectLastController);

            for (int i = 0; i < arraySize - 1; i++)
            {
                bool swapRequired = false;
                for (int j = 0; j < arraySize - i - 1; j++)
                {
                    var sourceName = components[j].GetType().Name;
                    var targetName = components[j + 1].GetType().Name;

                    int result = 0;
                    if (lastElementName == sourceName)
                    {
                        result = 1;
                    }
                    else if (lastElementName == targetName)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = String.Compare(sourceName, targetName, StringComparison.OrdinalIgnoreCase);
                    }

                    if (result > 0)
                    {
                        var toMove = components[j];
                        components[j] = components[j + 1];
                        components[j + 1] = toMove;
                        swapRequired = true;

                        ComponentUtility.MoveComponentDown(toMove);
                    }
                }

                if (swapRequired == false)
                    break;
            }
        }

        private void SetMonoInstallers(MonoInstaller[] installers)
        {
            if (target == null)
                return;

            var so = new SerializedObject(target);
            var installersProperty = so.FindProperty(MonoInstallersPropName);
            if (installersProperty == null)
            {
                Debug.LogError($"Can't find property '{MonoInstallersPropName}' on {typeof(ProjectContext)}");
                return;
            }

            installersProperty.arraySize = installers.Length;
            for (int i = 0; i < installers.Length; i++)
            {
                var serializedProperty = installersProperty.GetArrayElementAtIndex(i);
                serializedProperty.objectReferenceValue = installers[i];
            }

            so.ApplyModifiedProperties();
        }

        private void CollapseComponents()
        {
            // source code:
            // https://discussions.unity.com/t/expand-collapse-all-components-in-a-gameobject-refresh-issue/692006/7

            var context = target as ProjectContext;
            if (context == null)
                return;

            var installerComponents = context.gameObject.GetComponents<MonoInstaller>();
            foreach (var installerComponent in installerComponents)
            {
                InternalEditorUtility.SetIsInspectorExpanded(installerComponent, false);
            }

            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }
    }
}