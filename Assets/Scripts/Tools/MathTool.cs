using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class MathTool
{
    // startRange ~ endRange 사이 정수 반환(포함)
    public static int GetRandomIntRange(int startRange, int endRange){
        float startVal = (float)startRange;
        float endVal = (float)endRange;
        if(startVal > endVal){
            startVal = (float)endRange;
            endVal = (float)startRange;
        }
        float range = endVal - startVal +1f;
        float randomVal = startVal + Mathf.Floor(Random.value * range);
        if(randomVal > endVal) randomVal = endVal;
        return (int)randomVal;
    }
    public static List<int> GetShuffledInts(int count){
        List<int> returnVal = new List<int>();
        for (int i = 0; i < count; i++)
        {
            returnVal.Add(i);
        }
        System.Random random = new System.Random();
        returnVal.Sort((a, b) => random.Next(-1,2));
        return returnVal;
    }
    public static int GetRandomWeightedIndex(params float[] w){
        float range = 0f;
        for (int i = 0; i < w.Length; i++){
            w[i] += range;
            range = w[i];
        }
        float rand = Random.value  * range;
        for (int i = 0; i < w.Length; i++)
        {   
            if(i == 0){
                if(rand <= w[0] ) return 0;
            }else if(i ==  w.Length -1  ){
                return i;
            }else{
                if(rand > w[i-1] && rand <= w[i]) return i;
            }
        }
        Debug.LogError("MathTool.GetRandomWeightedIndex : fail to find index" );
        return -1;
    }

    //파라미터에 제시된 숫자들 중 무작위로 하나 반환
    public static int GetRandomIntWithin(params int[] n){
        return n[GetRandomIndex(n.Length)];
    }
    //파라미터에 제시된 숫자들 중 무작위로 하나 반환
    public static int GetRandomIntWithin(List<int> n){
        return n[GetRandomIndex(n.Count)];
    }
    //지정된 범위 내에서 무작위 정수 반환 ex. 3이면 0,1,2반환
    public static int GetRandomIndex(int count){
        int index = (int)Mathf.Floor(Random.value * count);
        if(index >= count) index = count-1;
        return index;
    }
    //파라미터에 제시된 숫자들 중 무작위로 count개 반환
    public static int[] GetRandomInts(List<int> n, int count){
        List<int> source = new List<int>();
        for (int i = 0; i < n.Count; i++)
        {
            source.Add(n[i]);
        }

        int maxCount = Mathf.Min(n.Count, count);
        int[] values = new int[maxCount];
        for (int i = 0; i < values.Length; i++)
        {
            int index = GetRandomIndex(source.Count);
            values[i] = source[index];
            source.RemoveAt(index);
        }
        return values;
    }
    //sourceCount 까지 숫자들 중 무작위로 count개 반환
    public static int[] GetRandomInts(int sourceCount, int count){
        if(sourceCount < count){
            Debug.LogError("Mathtool.GetRandomInts(int,int) : count is higher than sourceCount");
            count = sourceCount;
        }
        List<int> source = new List<int>();
        for (int i = 0; i < sourceCount; i++)
        {
            source.Add(i);
        }
        int[] values = new int[count];
        for (int i = 0; i < values.Length; i++)
        {
            int index = GetRandomIndex(source.Count);
            values[i] = source[index];
            source.RemoveAt(index);
        }
        
        return values;
    }
}
