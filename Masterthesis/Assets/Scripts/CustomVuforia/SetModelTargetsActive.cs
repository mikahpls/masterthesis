using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class SetModelTargetsActive : MonoBehaviour {

    public List<GameObject> ModelTargetList = new List<GameObject>();
    private ObjectTracker objTracker;
    private DataSet currentDataSet;
    private string nextTargetDSName;

	//laokoon 0
    //aphaia 1
    public void SetModelToActive(int i)
    {
        foreach(var obj in ModelTargetList)
        {
            obj.SetActive(false);
        }
        if(i == 0)
        {
            ModelTargetList[0].SetActive(true);
            //use database name you gave the database in the target model generator of vuforia, can be found on ARCamera
            nextTargetDSName = "laocoon_target";
        }
        else if(i == 1)
        {
            ModelTargetList[1].SetActive(true);
            nextTargetDSName = "aphaia";
        }

        //switch target model
        LoadNewTargetModel(nextTargetDSName);
    }

    private void LoadNewTargetModel(string dataBaseName)
    {
        TrackerManager tm = (TrackerManager)TrackerManager.Instance;
        objTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (objTracker == null) return;
        currentDataSet = objTracker.GetActiveDataSets().FirstOrDefault();
        objTracker.Stop();
        objTracker.DeactivateDataSet(currentDataSet);
        currentDataSet = objTracker.CreateDataSet();
        currentDataSet.Load(dataBaseName);
        objTracker.ActivateDataSet(currentDataSet);
        objTracker.Start();
    }
}
