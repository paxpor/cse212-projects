using System;
using System.Collections.Generic;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Step 1: Create a new double array that has the same size as the length parameter.
        // Step 2: Use a loop to go through each index in the array.
        // Step 3: For each index, multiply the original number by the multiple position.
        // Step 4: Since array indexes start at 0, use i + 1 to get the correct multiple.
        // Step 5: Store each calculated multiple in the array.
        // Step 6: Return the finished array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Step 1: Find the index where the last "amount" numbers begin.
        // Step 2: Copy that right-side section because it needs to move to the front.
        // Step 3: Copy the left-side section because it needs to move after the right-side section.
        // Step 4: Clear the original list so it can be rebuilt in the correct rotated order.
        // Step 5: Add the right-side section first.
        // Step 6: Add the left-side section second.

        int startIndex = data.Count - amount;

        List<int> rightSide = data.GetRange(startIndex, amount);
        List<int> leftSide = data.GetRange(0, startIndex);

        data.Clear();

        data.AddRange(rightSide);
        data.AddRange(leftSide);
    }
}