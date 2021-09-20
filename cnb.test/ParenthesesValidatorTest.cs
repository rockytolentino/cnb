using System;
using FluentAssertions;
using Xunit;

namespace cnb.test
{
    public class ParenthesesValidatorTest
    {
        [Fact]
        public void Validate_curly_brackets()
        {
            //  Arrange
            const string curly = "{}";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void Validate_curly_inside_a_curly_brackets()
        {
            //  Arrange
            const string curly = "{{}}";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void Validate_square_bracket_inside_a_valid_parentheses_brackets()
        {
            //  Arrange
            const string curly = "[{}[]()]";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeTrue();
        }
        
        
        
        [Fact]
        public void Validate_parentheses_inside_a_valid_parentheses_brackets()
        {
            //  Arrange
            const string curly = "([]{}())";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeTrue();
        }
        
        
        
        [Fact]
        public void Validate_curly_inside_a_invalid_curly_brackets()
        {
            //  Arrange
            const string curly = "{[}}";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void Validate_square_bracket_inside_a_invalid_parentheses_brackets()
        {
            //  Arrange
            const string curly = "[[}[]()]";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeFalse();
        }
        
        
        
        [Fact]
        public void Validate_parentheses_inside_a_invalid_parentheses_brackets()
        {
            //  Arrange
            const string curly = "([][}())";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void Validate_curly_brackets_with_invalid_character()
        {
            //  Arrange
            const string curly = "{}2";
            var paran = new ParenthesesValidator();
            
            //  Act
            var action  = new Func<bool>(() => paran.Validate(curly));
            
            //  Assert
            action.Should().Throw<Exception>();
        }
        
        [Fact]
        public void Validate_curly_brackets_with_some_invalid_character()
        {
            //  Arrange
            const string curly = "a{}2";
            var paran = new ParenthesesValidator();
            
            //  Act
            var action  = new Func<bool>(() => paran.Validate(curly));
            
            //  Assert
            action.Should().Throw<Exception>();
        }
        
        [Fact]
        public void Validate_same_curly_bracket()
        {
            //  Arrange
            const string curly = "{{";
            var paran = new ParenthesesValidator();
            
            //  Act
            var result = paran.Validate(curly);
            
            //  Assert
            result.Should().BeFalse();
        }
        
        
        [Fact]
        public void Validate_empty_string()
        {
            //  Arrange
            var curly = string.Empty;
            var paran = new ParenthesesValidator();
            
            //  Act
            var action  = new Func<bool>(() => paran.Validate(curly));
            
            //  Arrange
            action.Should().Throw<Exception>();
        }
    }
}