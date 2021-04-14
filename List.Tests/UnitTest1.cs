using System;
using NUnit.Framework;

namespace List.Test
{
    [TestFixture("ArrayList")]
    [TestFixture("LinkedList")]
    [TestFixture("DLinkedList")]
    public class ListTests
    {
        public IList actual;
        public IList listForAdding;
        public IList expected;

        public string listType = string.Empty;

        public ListTests(string type)
        {
            listType = type;
        }

        public void Setup(int[] inputArray = null, int[] arrayForAdding = null, int[] expectedArray = null)
        {
            switch (listType)
            {
                case "ArrayList":
                    if (!(inputArray is null))
                    {
                        actual = new ArrayList(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new ArrayList(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new ArrayList(expectedArray);
                    }
                    break;

                case "LinkedList":
                    if (!(inputArray is null))
                    {
                        actual = new LinkedList(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new LinkedList(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new LinkedList(expectedArray);
                    }
                    break;

                case "DLinkedList":
                    if (!(inputArray is null))
                    {
                        actual = new DoubleLinkedList(inputArray);
                    }
                    if (!(arrayForAdding is null))
                    {
                        listForAdding = new DoubleLinkedList(arrayForAdding);
                    }
                    if (!(expectedArray is null))
                    {
                        expected = new DoubleLinkedList(expectedArray);
                    }
                    break;
            }
        }

        [TestCase(new[] { 1, 2, 5, 3 }, 6, new[] { 1, 2, 5, 3, 6 })]
        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 9, 11 }, 1, new[] { 1, 9, 11, 1 })]
        public void AddTests_WhenAddElementInList_ListWithNewElementInTheEndReturned(int[] input, int value,
           int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 666, new[] { 666, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirstTests_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int[] input,
            int value, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, 666, new[] { 666 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 1, 2, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 0, 666, new[] { 666, 1, 3, 4, 5, 6, 7 })]
        public void AddByIndexTests_WhenAddElementByIndexInList_ListWithNewElementInTheIndexPositionReturned(
            int[] input, int index, int value, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 })]
        [TestCase(new[] { 3, 4 }, new[] { 4 })]
        [TestCase(new[] { 4 }, new int[] { })]

        public void RemoveFirstTests_WhenRemoveFirstElementInList_ListWithoutElementInFirstPositionReturned(int[] input,
            int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new int[] { 1 })]
        public void RemoveLastTests_WhenRemoveLastElementInList_ListWithoutElementInLastPositionReturned(int[] input,
            int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void
                    RemoveRangeFromLastTests_WhenRemoveRangeOfElementsFromLastOfList_ListWithoutCountElementsInThisRangeFromEndReturned(
                        int[] input, int count, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveRangeFromLast(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2, 4 })]
        public void RemoveByIndexTests_WhenRemoveElementByIndexInList_ListWithoutElementInTheIndexPositionReturned(
            int[] input, int index, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, -3)]
        public void RemoveRangeFromLastTests_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
                int[] input, int count)
        {
            Setup(inputArray: input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromLast(count));
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromFirstTests_WhenRemoveRangeOfElementsFromFirstOfList_ListWithoutCountElementsInThisRangeFromBeginReturned(
                int[] input, int count, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveRangeFromFirst(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 2, new[] { 1, 2, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 5, 2, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromIndexTests_WhenRemoveRangeOfElementsFromIndexOfList_ListWithoutCountElementsInThisRangeFromIndexReturned(
                int[] input, int index, int count, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.RemoveRangeFromIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 2, 3)]
        [TestCase(new[] { 1, 2, 3, 5 }, 1, -1)]
        public void RemoveRangeFromIndexTests_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
            int[] input,
            int index, int count)
        {
            Setup(inputArray: input);

            Assert.Throws<System.ArgumentException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] { 1, 2, 3, 5 }, -2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 4, 1)]
        public void
            RemoveRangeFromIndexTests_WhenIndexLessThen0OrGreaterThatLastValueIndex_IndexOutOfRangeExceptionReturned(
                int[] input,
                int index, int count)
        {
            Setup(inputArray: input);

            Assert.Throws<System.IndexOutOfRangeException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] { 1, 1, 1, 1 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 7, 5)]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1, 1, 2, 3, 4, 6, 7, 8 }, 9, -1)]
        public void GetFirstIndexByValueTests_WhenArrayListsContainValues_IndexOfFirstFoundValueReturned(int[] input,
           int value, int expected)
        {
            Setup(inputArray: input);

            int actu = actual.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actu);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        [TestCase(new[] { 1, 2, 5, 3, 4 }, new[] { 4, 3, 5, 2, 1 })]
        [TestCase(new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 0 }, new[] { 0 })]
        public void ReverseTests_WhenArrayList_ReversedArrayListReturned(int[] input, int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 10, 5 }, 1)]
        [TestCase(new[] { 1, 10, 5, 14, 999 }, 4)]
        [TestCase(new[] { 0 }, 0)]
        public void FindIndexOfMaxValueTests_WhenFindListMaxValue_IndexOfMaxValueReturned(int[] input, int expected)
        {
            Setup(inputArray: input);

            int actu = actual.FindIndexOfMaxValue();

            Assert.AreEqual(expected, actu);
        }


        [TestCase(new[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 2)]
        public void FindIndexOfMinValueTests_WhenFindListMinValue_IndexOfMinValueReturned(int[] input, int expected)
        {
            Setup(inputArray: input);

            int actua = actual.FindIndexOfMinValue();

            Assert.AreEqual(expected, actua);
        }

        [TestCase(new[] { 1, 10, 15 }, 15)]
        [TestCase(new[] { 1, 15, 15 }, 15)]
        [TestCase(new[] { 1, 10, 5, 1 }, 10)]
        [TestCase(new[] { 0 }, 0)]
        public void FindMaxValueTests_WhenArrayListHasElements_MaxValueReturned(int[] input, int expected)
        {
            Setup(inputArray: input);

            int actua = actual.FindMaxValue();

            Assert.AreEqual(expected, actua);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new[] { 1, 2, 3, 4, 3, 7, 0 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 5)]
        public void FindMinValueTests_WhenArrayListHasElements_MinValueReturned(int[] input, int expected)
        {
            Setup(inputArray: input);

            int actua = actual.FindMinValue();

            Assert.AreEqual(expected, actua);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 5, 3)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, -1)]
        public void RemoveFirstByValueTests_WhenFirstValueFoundRemoveItFromList_IndexOfThatValueReturned(int[] input,
            int value, int expected)
        {
            Setup(inputArray: input);

            int actua = actual.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actua);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 5, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, 0)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, 10)]
        public void RemoveAllByValueTests_WhenValuesFoundRemoveItFromList_CountOfThatValuesReturned(int[] input,
            int value,
            int expected)
        {
            Setup(inputArray: input);

            int actua = actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actua);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 6, 7, 8, 9 }, new[] { 1, 2, 6, 7, 8, 9, 3, 4 })]
        [TestCase(new[] { 1, 2 }, 1, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 })]
        [TestCase(new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 }, 4, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 }, new[] { 1, 6, 7, 8, 1, 6, 7, 8, 9, 1, 2, 3, 4, 2, 9, 1, 2, 3, 4, 2 })]
        public void AddListByIndexTests_WhenToListAddAnotherListByIndex_ListWithInsertedInIndexListReturned(int[] input,
                     int index, int[] Elements, int[] output)
        {
            Setup(inputArray: input, expectedArray: output, arrayForAdding:Elements) ;

            actual.AddListByIndex(index, listForAdding);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4, 1, 2 })]
        public void AddListFirstTests_WhenToFirstListAddAnotherListInFirstPosition_ListWithInsertedInFirstPositionListReturned(int[] input,
             int[] Elements, int[] output)
        {
            Setup(inputArray: input, expectedArray: output, arrayForAdding: Elements);

            actual.AddListFirst(listForAdding);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 2, 6, 7, 8, 9, 1, 2, 3, 4 })]
        public void
            AddListLastTests_WhenToFirstListAddAnotherListInLastPosition_ListWithInsertedInLasttPositionListReturned(
                int[] input,
                int[] Elements, int[] output)
        {
            Setup(inputArray: input, expectedArray: output, arrayForAdding: Elements);

            actual.AddListLast(listForAdding);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 1, 3, 5, 7, 8 }, new[] { 1, 3, 5, 7, 8 })]
        [TestCase(new[] { 8, 7, 5, 3, 1 }, new[] { 1, 3, 5, 7, 8 })]
        public void SortTests_WhenArrayList_SortedArrayListByDescendingReturned(int[] input,
                    int[] output)
        {
            Setup(inputArray: input, expectedArray: output);

            actual.Sort();

            Assert.AreEqual(expected, actual);
        }
    }
}