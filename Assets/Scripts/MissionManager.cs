using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class MissionManager : MonoBehaviour
{
    public static MissionManager current;


    private Boolean ambulanceCalled;
    public Boolean AmbulanceCalled { get => ambulanceCalled; set{
        ambulanceCalled = value;
        AmbulanceComplete(value);

    } 
    }

    private Boolean victimMoved;
    public Boolean VictimMoved { get => victimMoved; set{
        victimMoved = value;
        VictimMovedDone(value);

    } 
    }

    private Boolean heartChecked;
    public Boolean HeartChecked { get => heartChecked; set{
        heartChecked = value;
        CheckHeart(value);

    } 
    }

    private Boolean cprPerformed;
    public Boolean CprPerformed { get =>cprPerformed; set{
        cprPerformed = value;
        PerformCpr(value);

    } 
    }

    private Boolean heartChecked2;
    public Boolean HeartChecked2 { get => heartChecked2; set{
        heartChecked2 = value;
        CheckHeart2(value);

    } 
    }

    private int progressRate = 0;
    public int ProgressRate { get => progressRate; set{
        progressRate = value;
        MissionSuccess(value);

    } 
    }

    private void Awake()
    {
     if (current == null)
        {
          current = this;
        }
    else
        {
          Destroy(obj: this);
        }
    }

    public event Action<Boolean> OnAmbulanceCalled;
    public void AmbulanceComplete(Boolean newBool)
     {
       OnAmbulanceCalled?.Invoke(newBool);
     }

    public event Action<Boolean> OnVictimMoved;
    public void VictimMovedDone(Boolean newBool)
     {
       OnVictimMoved?.Invoke(newBool);
     }

     public event Action<Boolean> OnHeartChecked;
     public void CheckHeart(Boolean newBool)
     {
       OnHeartChecked?.Invoke(newBool);
     }

     public event Action<Boolean> OnCprPerformed;
     public void PerformCpr(Boolean newBool)
     {
       OnCprPerformed?.Invoke(newBool);
     }

     public event Action<Boolean> OnHeartChecked2;
     public void CheckHeart2(Boolean newBool)
     {
       OnHeartChecked2?.Invoke(newBool);
     }

     public event Action<int> OnMissionSuccess;
     public void MissionSuccess(int newBool)
     {
       OnMissionSuccess?.Invoke(newBool);
     }


}
