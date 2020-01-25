using NUnit.Framework;

namespace BackendEngineer
{
    /**
     
     Moviholics are  movie obsessed and has collected a list of movie quality ratings. 
     They wants to watch the largest contiguous list of movies with the highest cumulative ratings possible. 
     To do this, they must calculate the sum of all contiguous subarrays in order to determine the maximum possible subarray sum.

    For example, ratings are arr = [-1,3,4,-2,5,-7]. 
    We can see that the highest value contiguous subarray runs from arr[1]-arr[4] and is 3 + 4 + -2 + 5 = 10.

    Complete the function MaximumSum below. 
    It must return an integer denoting the maximum sum for any contiguous subarray in arr.

    MaximumSum has the following parameter(s):
        arr[arr[0],...arr[n-1]]:  an array of integers

    Constraints
        1 ≤ n ≤ 10000000
      −100000000 ≤ arr[i] ≤ 100000000 
     */
    public class MaximumTest
    {
        /**
         * The maximum sum for any contiguous subarray in [−1, −2, 1, 3] is 1 + 3 = 4.
         */
        [Test]
        public void MaximumSum_Sample1()
        {
            var input = new[] { -1, -2, 1, 3 };
            var output = MaximumSum(input);
            Assert.AreEqual(4, output);
        }

        /**
         * The maximum sum for any contiguous subarray in [1, 2, 3, 4] is 1 + 2 + 3 + 4 = 10.
         */
        [Test]
        public void MaximumSum_Sample2()
        {
            var input = new[] { 1, 2, 3, 4 };
            var output = MaximumSum(input);
            Assert.AreEqual(10, output);
        }

        /**
          * The maximum sum for any contiguous subarray in [9, -5, 8, -7, 3, -1, 5, 1] is 9 - 5 + 8 = 12 or 9 - 5 + 8 - 7 + 3 - 1 + 5 + 1 = 13.
          */
        [Test]
        public void MaximumSum_Sample3()
        {
            var input = new[] { 9, -5, 8, -7, 3, -1, 5, 1 };
            var output = MaximumSum(input);
            Assert.AreEqual(13, output);
        }

        private static int MaximumSum(int[] input)
        {
            var size = input.Length;

            // 1 ≤ n ≤ 10000000.
            if (size == 0 || size > 10000000)
            {
                return 0;
            }

            var returnMax = -100000000;
            var tempMax = 0;

            foreach (var value in input)
            {
                //−100000000 ≤ arr[i] ≤ 100000000
                if (value < -100000000 || value > 100000000)
                {
                    return 0;
                }

                tempMax += value;

                // Check if the new sum is higher than the previous.
                if (returnMax < tempMax)
                {
                    returnMax = tempMax;
                }

                // Check for negatives values.
                if (tempMax < 0)
                {
                    tempMax = 0;
                }
            }

            return returnMax;
        }
    }
}