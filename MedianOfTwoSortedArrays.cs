using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MedianOfTwoSortedArrays
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int l1 = Math.Max(nums1.Length, nums2.Length);
        int len = nums1.Length + nums2.Length;

        if (len == 0)
        {
            return 0;
        }
        else if (len == 1)
        {
            int temp1 = (nums1.Length == 0) ? 0 : nums1[0];
            int temp2 = (nums2.Length == 0) ? 0 : nums2[0];

            return (Math.Min(temp1, temp2) + Math.Max(temp1, temp2)) / 2;
        }

        int[] merged = new int[len];
        
        int l = 0;
        bool odd;
        int oddNum = 0;

        if (len%2 != 0)
        {
            odd = true;
            oddNum = (int)(len / 2);
        }
        else
        {
            odd = false;
            oddNum = (int)(len / 2);
        }
        for (int i = 0; i < l1; i++)//Con este ciclo voy recorriendo el máximo de elementos de los dos arrays
        {
            if (nums1.Length > i && nums2.Length > i)
            {
                merged[l] = Math.Min(nums1[i], nums2[i]);                
                l++;
                merged[l] = Math.Max(nums1[i], nums2[i]);
            }
            else if (nums1.Length > i)
            {
                merged[l] = nums1[i];
            }
            else
            {
                merged[l] = nums2[i];
            }

            
            if (odd && l >= oddNum)
            {
                return merged[oddNum];
            }
            if(!odd && l >= oddNum) 
            {
                return (float)(merged[oddNum - 1] + merged[oddNum]) / (float)2;
            }

            l++;
        }


        return 0;


    }
}
