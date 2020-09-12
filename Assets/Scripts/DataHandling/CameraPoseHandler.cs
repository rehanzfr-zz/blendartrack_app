﻿using UnityEngine;
using System.Collections.Generic;

namespace ArRetarget
{
    public class CameraPoseHandler : MonoBehaviour
    {
        [HideInInspector]
        public List<PoseData> cameraPoseList = new List<PoseData>();
        private GameObject mainCamera;
        private DataManager dataManager;

        private void Start()
        {
            dataManager = GameObject.FindGameObjectWithTag("manager").GetComponent<DataManager>();
            DeviceManager.Instance.SetDataType(DeviceManager.Capabilities.ArCore_CameraPose);
            dataManager.AssignDataType();
        }

        public void InitCamera()
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        public void GetCameraPoseData(int f)
        {
            var cameraPose = GetPoseData(mainCamera, f);
            cameraPoseList.Add(cameraPose);
        }

        public static PoseData GetPoseData(GameObject obj, int f)
        {
            var p = new Vector()
            {
                x = obj.transform.position.x,
                y = obj.transform.position.y,
                z = obj.transform.position.z
            };

            var r = new Vector()
            {
                x = obj.transform.eulerAngles.x,
                y = obj.transform.eulerAngles.y,
                z = obj.transform.eulerAngles.y,
            };

            var tmp = new PoseData()
            {
                pos = p,
                rot = r,

                frame = f
            };

            return tmp;
        }
    }
}
