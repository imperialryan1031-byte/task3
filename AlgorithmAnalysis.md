# Algorithm Analysis Documentation

## Overview
This document provides detailed analysis of fundamental algorithms, including pseudocode implementations, complexity analysis using Big-O notation, and performance characteristics.

---

## 1. Finding Minimum Value

### Description
The algorithm to find the minimum value in a collection of elements by iterating through all elements and keeping track of the smallest value encountered.

### Pseudocode
```
function findMinimum(array)
    if array is empty
        return null or error
    
    min = array[0]
    
    for i = 1 to length(array) - 1
        if array[i] < min
            min = array[i]
        end if
    end for
    
    return min
end function
```

### Algorithm Explanation
1. Initialize `min` with the first element of the array
2. Iterate through the remaining elements starting from index 1
3. Compare each element with the current minimum value
4. Update `min` if a smaller value is found
5. Return the minimum value after traversing the entire array

### Complexity Analysis

#### Time Complexity
- **Best Case: O(n)** - Omega(n)
  - Even in the best case, we must examine all n elements to confirm we have found the minimum
  - No early termination is possible
  
- **Average Case: Θ(n)** - Theta(n)
  - On average, we perform n comparisons to find the minimum value
  - The position of the minimum element doesn't affect the total number of comparisons
  
- **Worst Case: O(n)** - Big-O
  - Same as average and best case, we must check all n elements
  - Occurs regardless of array order or value distribution

#### Space Complexity
- **O(1)** - Constant space
- Only uses a fixed amount of extra space (the `min` variable and loop counter)

### Key Insights
- This is a linear search algorithm that must examine every element
- Time complexity is not dependent on the order or distribution of elements
- Optimal for small datasets and when you need a guaranteed solution
- No optimization is possible for this problem variant

---

## 2. Linear Search

### Description
Linear Search is a simple searching algorithm that checks every element in a collection sequentially until the target value is found or all elements are examined.

### Pseudocode
```
function linearSearch(array, target)
    for i = 0 to length(array) - 1
        if array[i] == target
            return i  // Element found at index i
        end if
    end for
    
    return -1  // Element not found
end function
```

### Algorithm Explanation
1. Start at the first element of the array
2. Compare the current element with the target value
3. If a match is found, return the index of that element
4. If no match, move to the next element
5. Repeat until the target is found or the array is exhausted
6. Return -1 if the target is not found in the array

### Complexity Analysis

#### Time Complexity
- **Best Case: O(1)** - Omega(1)
  - The target element is at the first position (index 0)
  - Only one comparison is needed
  - Constant time regardless of array size
  
- **Average Case: Θ(n/2) = Θ(n)** - Theta(n)
  - On average, the target element is located near the middle of the array
  - Approximately n/2 comparisons are required
  - This simplifies to Θ(n) due to constant factor elimination
  
- **Worst Case: O(n)** - Big-O
  - The target is at the last position or not present in the array
  - All n elements must be examined
  - Maximum comparisons = n

#### Space Complexity
- **O(1)** - Constant space
- Uses only a fixed amount of extra space (loop counter and return value)

### Advantages & Disadvantages
**Advantages:**
- Simple to understand and implement
- Works on both sorted and unsorted arrays
- No preprocessing required

**Disadvantages:**
- Inefficient for large datasets
- Slower than binary search for sorted arrays
- Time complexity grows linearly with input size

---

## 3. Binary Search

### Description
Binary Search is an efficient searching algorithm that works on sorted arrays by repeatedly dividing the search space in half, eliminating half of the remaining elements with each comparison.

### Pseudocode
```
function binarySearch(sortedArray, target)
    left = 0
    right = length(sortedArray) - 1
    
    while left <= right
        mid = floor((left + right) / 2)
        
        if sortedArray[mid] == target
            return mid  // Element found
        else if sortedArray[mid] < target
            left = mid + 1  // Search right half
        else
            right = mid - 1  // Search left half
        end if
    end while
    
    return -1  // Element not found
end function
```

### Alternative: Recursive Binary Search
```
function binarySearchRecursive(sortedArray, target, left, right)
    if left > right
        return -1  // Element not found
    end if
    
    mid = floor((left + right) / 2)
    
    if sortedArray[mid] == target
        return mid
    else if sortedArray[mid] < target
        return binarySearchRecursive(sortedArray, target, mid + 1, right)
    else
        return binarySearchRecursive(sortedArray, target, left, mid - 1)
    end if
end function
```

### Algorithm Explanation
1. Initialize `left` pointer to the start and `right` pointer to the end of the array
2. Calculate the middle index: `mid = (left + right) / 2`
3. Compare the element at `mid` with the target value:
   - If equal, return the index
   - If target > mid element, search the right half (set `left = mid + 1`)
   - If target < mid element, search the left half (set `right = mid - 1`)
4. Repeat until the element is found or `left > right`
5. Return -1 if the target is not found

### Complexity Analysis

#### Time Complexity
- **Best Case: O(1)** - Omega(1)
  - The target is at the middle position on the first comparison
  - Only one comparison needed
  
- **Average Case: Θ(log n)** - Theta(log n)
  - On average, we perform log₂(n) comparisons
  - Search space is halved with each iteration
  - For 1 million elements, approximately 20 comparisons needed
  
- **Worst Case: O(log n)** - Big-O
  - The target is not in the array or at an extreme position
  - Maximum comparisons = log₂(n) + 1
  - Same as average case due to divide-and-conquer approach

#### Space Complexity
- **Iterative: O(1)** - Constant space
  - Uses only variables for pointers and mid calculation
  
- **Recursive: O(log n)** - Logarithmic space
  - Call stack depth is proportional to log₂(n) due to recursion

### Why Binary Search is Efficient
- Eliminates half of remaining elements with each comparison
- Number of iterations: log₂(n)
- For 1,000,000 elements: log₂(1,000,000) ≈ 20 comparisons
- Much faster than linear search for large sorted arrays

### Requirements
- **Array must be sorted** - This is a prerequisite for binary search
- Sorting takes O(n log n) time, but can be amortized across multiple searches

---

## 4. Bubble Sort

### Description
Bubble Sort is a simple comparison-based sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. This process continues until the list is sorted.

### Pseudocode
```
function bubbleSort(array)
    n = length(array)
    
    for i = 0 to n - 1
        swapped = false
        
        for j = 0 to n - i - 2
            if array[j] > array[j + 1]
                swap(array[j], array[j + 1])
                swapped = true
            end if
        end for
        
        // Optimization: if no swaps occurred, array is sorted
        if not swapped
            break
        end if
    end for
    
    return array
end function
```

### Algorithm Explanation
1. Start with the first element in the array
2. Compare each adjacent pair of elements
3. If the left element is greater than the right element, swap them
4. After one complete pass, the largest element "bubbles up" to the end
5. Repeat the process for the remaining unsorted portion
6. Optimization: If no swaps occur in a pass, the array is sorted and can terminate early
7. Continue until the entire array is sorted

### Visual Example
```
Initial:    [5, 2, 8, 1, 9]

Pass 1:     [2, 5, 1, 8, 9]  (9 bubbles to end)
Pass 2:     [2, 1, 5, 8, 9]  (8 in place)
Pass 3:     [1, 2, 5, 8, 9]  (5 in place)
Pass 4:     [1, 2, 5, 8, 9]  (2 in place)
Sorted:     [1, 2, 5, 8, 9]
```

### Complexity Analysis

#### Time Complexity
- **Best Case: O(n)** - Omega(n)
  - Array is already sorted
  - With the optimization flag, only one pass is needed
  - n comparisons, 0 swaps
  - Only achievable with the "swapped" optimization
  
- **Average Case: O(n²)** - Theta(n²)
  - Randomly ordered array
  - Approximately n²/4 comparisons and swaps
  - Typical performance on unsorted data
  
- **Worst Case: O(n²)** - Big-O
  - Array is sorted in reverse order
  - Requires maximum comparisons: 1 + 2 + 3 + ... + (n-1) = n(n-1)/2
  - Requires maximum swaps: n(n-1)/2
  - Every comparison results in a swap

#### Comparison and Swap Counts
- **Number of Comparisons:** n(n-1)/2 ≈ n²/2 in worst/average case
- **Number of Swaps:** 0 (best), n²/4 (average), n²/2 (worst)

#### Space Complexity
- **O(1)** - Constant space
- Sorts in-place without requiring additional data structures
- Only uses variables for loop counters and temporary swap storage

### Algorithm Characteristics

| Property | Value |
|----------|-------|
| Sorting Type | Comparison-based |
| In-place | Yes |
| Stable | Yes |
| Adaptive | Yes (with optimization) |
| Comparison Count (Worst) | n(n-1)/2 |
| Swap Count (Worst) | n(n-1)/2 |

**Definitions:**
- **Stable Sort:** Equal elements maintain their relative order
- **In-place Sort:** Requires O(1) extra space
- **Adaptive Algorithm:** Performs better on partially sorted data

### Advantages
- Very simple to understand and implement
- No extra space required (in-place sorting)
- Stable sorting algorithm
- Adaptive: performs better on nearly sorted arrays with optimization

### Disadvantages
- Very inefficient for large datasets (O(n²) time complexity)
- Not suitable for real-world applications with large data
- Much slower than advanced algorithms (merge sort, quick sort)
- Poor performance on reverse-sorted arrays

### When to Use Bubble Sort
- Educational purposes: teaching sorting concepts
- Very small datasets (< 10 elements)
- When simplicity is more important than efficiency
- When stability is required and array size is small
- When space is extremely limited

---

## Complexity Comparison Summary

### Big-O Notation Hierarchy
From fastest to slowest:
```
O(1) < O(log n) < O(n) < O(n log n) < O(n²) < O(n³) < O(2ⁿ) < O(n!)
```

### Algorithm Performance Comparison

| Algorithm | Best Case | Average Case | Worst Case | Space | Notes |
|-----------|-----------|--------------|-----------|-------|-------|
| Find Minimum | O(n) | Θ(n) | O(n) | O(1) | Must check all elements |
| Linear Search | O(1) | Θ(n) | O(n) | O(1) | Works on unsorted data |
| Binary Search | O(1) | Θ(log n) | O(log n) | O(1)* | Requires sorted array |
| Bubble Sort | O(n) | Θ(n²) | O(n²) | O(1) | Simple but inefficient |

*Recursive version uses O(log n) space for call stack

### Practical Performance (1,000,000 elements)
- **Linear Search:** ~500,000 comparisons (average)
- **Binary Search:** ~20 comparisons
- **Bubble Sort:** ~500 billion operations (worst case)
- **Finding Minimum:** 1,000,000 comparisons

---

## Asymptotic Notations Explained

### Big-O Notation (O)
- **Definition:** Upper bound on growth rate
- **Meaning:** Algorithm takes **at most** this long
- **Used for:** Worst-case analysis
- **Example:** Binary search is O(log n)

### Omega Notation (Ω)
- **Definition:** Lower bound on growth rate
- **Meaning:** Algorithm takes **at least** this long
- **Used for:** Best-case analysis
- **Example:** Linear search is Ω(1) in best case

### Theta Notation (Θ)
- **Definition:** Tight bound on growth rate
- **Meaning:** Algorithm takes **approximately** this long
- **Used for:** Average-case analysis when best and worst cases are the same
- **Example:** Find minimum is Θ(n)

### Visual Representation
```
Ω(n) ≤ Θ(n) ≤ O(n)
Lower Bound ≤ Average ≤ Upper Bound
```

---

## Conclusion

Understanding algorithm complexity is crucial for:
- Predicting performance on large datasets
- Choosing appropriate algorithms for specific problems
- Writing scalable code
- Optimizing applications for real-world use

Choose algorithms based on:
1. **Input size** - Small vs. large datasets
2. **Requirements** - Sorting stability, in-place operation
3. **Data characteristics** - Already sorted, reverse sorted, random
4. **Available resources** - Time vs. space trade-offs
5. **Worst-case scenarios** - What happens with worst input

For production systems, prefer algorithms with better time complexity (binary search, merge sort, quick sort) over simple algorithms like bubble sort.