using CSharp.Experiments.FromDocumentation.DataStructures.CustomStackImplementation;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharp.Experiments.FromDocumentation.Tests.DataStructures.CustomStackImplementation;

public class CustomStackTests
{
    [Fact]
    public void Given_WhenCallCtor_ThenResultAsExpected()
    {
        CustomStack<int>? stack = null;
        var action = () => stack = new CustomStack<int>();
        using (new AssertionScope())
        {
            action.Should().NotThrow<Exception>();
            stack.Should().NotBeNull();
            stack!.IsEmpty.Should().BeTrue();
        }
    }

    [Fact]
    public void GivenSmallStackAndManyItems_WhenPush_ThenStackIsResized()
    {
        var stack = new CustomStack<int>(capacity: 10);
        var firstAction = () => Enumerable.Range(start: 0, count: 10).ToList().ForEach(stack.Push);
        var secondAction = () => Enumerable.Range(start: 10, count: 10).ToList().ForEach(stack.Push);
        using (new AssertionScope())
        {
            firstAction.Should().NotThrow<Exception>();
            stack.IsEmpty.Should().BeFalse();
            secondAction.Should().NotThrow<Exception>();
            stack.IsEmpty.Should().BeFalse();
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void GivenInvalidCapacity_WhenCallCtor_ThenArgumentOutOfRangeExceptionThrown(int capacity)
    {
        CustomStack<int>? stack = null;
        var action = () => stack = new CustomStack<int>(capacity);
        using (new AssertionScope())
        {
            action.Should().Throw<ArgumentOutOfRangeException>();
            stack.Should().BeNull();
        }
    }

    [Theory]
    [InlineData(int.MaxValue)]
    public void GivenEnormousCapacity_WhenCallCtor_ThenOutOfMemoryExceptionThrown(int capacity)
    {
        CustomStack<int>? stack = null;
        var action = () => stack = new CustomStack<int>(capacity);
        using (new AssertionScope())
        {
            action.Should().Throw<OutOfMemoryException>();
            stack.Should().BeNull();
        }
    }

    [Theory]
    [InlineData(1)]
    public void GivenCapacity_WhenCallCtor_ThenResultAsExpected(int capacity)
    {
        CustomStack<int>? stack = null;
        var action = () => stack = new CustomStack<int>(capacity);
        using (new AssertionScope())
        {
            action.Should().NotThrow<Exception>();
            stack.Should().NotBeNull();
            stack!.IsEmpty.Should().BeTrue();
        }
    }

    [Theory]
    [InlineData(1)]
    public void GivenItem_WhenPush_ThenResultAsExpected(int item)
    {
        var stack = new CustomStack<int>();
        var action = () => stack.Push(item);
        using (new AssertionScope())
        {
            action.Should().NotThrow<Exception>();
            stack.Should().NotBeNull();
            stack.IsEmpty.Should().BeFalse();
            stack.Peek().Should().Be(item);
        }
    }

    [Theory]
    [InlineData(1)]
    public void GivenItem_WhenPushAndPop_ThenResultAsExpected(int item)
    {
        var stack = new CustomStack<int>();
        int? poppedItem = null;
        var action = () =>
        {
            stack.Push(item);
            poppedItem = stack.Pop();
        };

        using (new AssertionScope())
        {
            action.Should().NotThrow<Exception>();
            stack.Should().NotBeNull();
            stack.IsEmpty.Should().BeTrue();
            poppedItem.Should().Be(item);
        }
    }

    [Theory]
    [InlineData(1)]
    public void GivenItem_WhenPushAndPeek_ThenResultAsExpected(int item)
    {
        var stack = new CustomStack<int>();
        int? peekedItem = null;
        var action = () =>
        {
            stack.Push(item);
            peekedItem = stack.Peek();
        };

        using (new AssertionScope())
        {
            action.Should().NotThrow<Exception>();
            stack.Should().NotBeNull();
            stack.IsEmpty.Should().BeFalse();
            stack.Peek().Should().Be(item);
            peekedItem.Should().Be(item);
        }
    }

    [Fact]
    public void GivenEmptyStack_WhenPop_ThenResultAsExpected()
    {
        var stack = new CustomStack<int>();
        var action = () => stack.Pop();
        using (new AssertionScope())
        {
            stack.IsEmpty.Should().BeTrue();
            action.Should().Throw<InvalidOperationException>();
            stack.IsEmpty.Should().BeTrue();
        }
    }

    [Fact]
    public void GivenEmptyStack_WhenPeek_ThenResultAsExpected()
    {
        var stack = new CustomStack<int>();
        var action = () => stack.Peek();
        using (new AssertionScope())
        {
            stack.IsEmpty.Should().BeTrue();
            action.Should().Throw<InvalidOperationException>();
            stack.IsEmpty.Should().BeTrue();
        }
    }
}
