using System.Collections.Generic;
using UnityEngine;

namespace Oliver
{
    /// <summary>
    /// 兩數之合，配合使用哈希表
    /// </summary>
    public class TwoSumSolver : MonoBehaviour
    {
        void Start()
        {
            int[] nums = { 3, 9, 6, 17, 21, 18, 31, 44 };
            int target = 34;

            int[] result = TwoSum(nums, target);
            if (result != null)
            {
                Debug.Log($"<color=#0f0>索引結果: [{result[0]}, {result[1]}]</color>");
            }
            else
            {
                Debug.Log("沒有找到解");
            }
        }

        int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numIndices.ContainsKey(complement))
                {
                    return new int[] { numIndices[complement], i };
                }

                numIndices[nums[i]] = i; // 儲存當前數字及其索引
            }

            return null; // 如果沒有找到解，返回 null
        }
    }
}


