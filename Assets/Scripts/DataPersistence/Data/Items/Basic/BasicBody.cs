using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
namespace ssm.data.item.basic{
    public class BasicBody : ItemData
    {
        public float[] hpMax;
        public float[] hpCurrent;
        public float[] epMax;
        public float[] epCurrent;

        public BasicBody(int grade = 0) : base(){

        }
    }
}