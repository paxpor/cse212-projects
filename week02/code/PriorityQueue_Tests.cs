using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities and remove them from the queue.
    // Expected Result: Items should be removed in order from highest priority to lowest priority.
    // Defect(s) Found: The last item in the queue was not checked when searching for the highest priority.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The item added first with the highest priority should be removed first (FIFO behavior).
    // Defect(s) Found: Items with the same priority were not following FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove items from the queue and verify they are actually removed.
    // Expected Result: Queue should become empty after all items are removed.
    // Defect(s) Found: Items were returned but not removed from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown with the correct message.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}