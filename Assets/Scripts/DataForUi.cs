using System;
using UnityEngine;

public struct DataForUi
{
    public string Message;
    public bool IsShowPopup;
    public bool IsFinish;
    public int Mistakes;
    public TimeSpan LearningTime;

    public DataForUi(
        string message,
        bool isShowPopup,
        bool isFinish,
        int mistakes,
        TimeSpan learningTime
    )
    {
        Message = message;
        IsShowPopup = isShowPopup;
        IsFinish = isFinish;
        Mistakes = mistakes;
        LearningTime = learningTime;
    }
}