using System;
using FluentAssertions;
using NuGet.Frameworks;
using Xunit;

namespace cnb.test
{
    public class MinStackTest
    {
        [Fact]
        public void GetMin_method_should_return_the_minimum_value()
        {
            //  Arrange
            var min = new MinStack();
            min.Push(-2);
            min.Push(0);
            min.Push(-3);
            
            //  Act
            var minimum = min.GetMin();
            
            //  Assert
            minimum.Should().Be(-3);
        }
        
        [Fact]
        public void GetMin_method_should_return_the_minimum_value_to_all_positive_entry_values()
        {
            //  Arrange
            var min = new MinStack();
            min.Push(10);
            min.Push(5);
            min.Push(100);
            
            //  Act
            var minimum = min.GetMin();
            
            //  Assert
            minimum.Should().Be(5);
        }
        
        
        [Fact]
        public void GetMin_method_should_return_the_minimum_value_as_example_in_requirements()
        {
            //  Arrange
            var min = new MinStack();
            min.Push(-2);
            min.Push(0);
            min.Push(-3);
            
            //  Act
            var minimum = min.GetMin();

            min.Pop();
            var topValue = min.Top();

            var minimum2 = min.GetMin();
            
            //  Assert
            minimum.Should().Be(-3);
            topValue.Should().Be(0);
            minimum2.Should().Be(-2);
        }
        
        [Fact]
        public void GetMin_method_should_throw_an_error_on_empty_stacks()
        {
            //  Arrange
            var min = new MinStack();

            //  Act
            Action action = () => min.GetMin();
            
            //  Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Top_method_should_throw_an_error_on_empty_stacks()
        {
            //  Arrange
            var min = new MinStack();

            //  Act
            Action action = () => min.Top();
            
            //  Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Pop_method_should_throw_an_error_on_empty_stacks()
        {
            //  Arrange
            var min = new MinStack();

            //  Act
            Action action = () => min.Pop();
            
            //  Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Test_to_maximum_number_of_calls()
        {
            //  Arrange
            var top = 0;
            var maxCalls = Math.Pow(10, 4) * 3;
            var min = new MinStack();
            min.Push(2);
            
            //  Act
            for (var i = 0; i < maxCalls; i++)
                top = min.Top();

            top.Should().Be(2);
        }

        [Fact]
        public void Test_to_go_over_the_maximum_number_of_calls()
        {
            //  Arrange
            var top = 0;
            var maxCalls = (Math.Pow(10, 4) * 3)+1;
            var min = new MinStack();
            min.Push(2);
            
            //  Act
            Action action = () =>
            {
                for (var i = 0; i < maxCalls; i++)
                    top = min.Top();
            };

            action.Should().Throw<Exception>();
        }
    }
}