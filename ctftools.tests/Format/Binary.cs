using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.tests.Format
{
    public class Binary
    {
        [Theory]
        [InlineData("01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101")]
        [InlineData("011001100110110001100001011001110111101100110001001100100011001101111101")]
        [InlineData("0110 0110 0110 1100 0110 0001 0110 0111 0111 1011 0011 0001 0011 0010 0011 0011 0111 1101")]
        [InlineData("0 1 1 0 0 1 1 0 0 1 1 0 1 1 0 0 0 1 1 0 0 0 0 1 0 1 1 0 0 11 1 0 1 1 1 1 0 1 1 0 0 1 1 0 0 0 1 0 0 1 1 0 0 1 0 0 0 1 1 0 0 1 1 0 1 1 1 1 1 0 1 ")]
        public void ToTextShouldConvertBinaryStringToText(string flag)
        {
            Assert.Equal("flag{123}", ctftools.Format.Binary.ToText(flag));
        }

        [Fact]
        public void ToText_ShouldReturnEmpty_ForEmptyOrWhitespace()
        {
            Assert.Equal(string.Empty, ctftools.Format.Binary.ToText(string.Empty));
            Assert.Equal(string.Empty, ctftools.Format.Binary.ToText(" "));
            Assert.Equal(string.Empty, ctftools.Format.Binary.ToText("\t\n"));
        }

        [Fact]
        public void ToText_ShouldThrowArgumentNullException_ForNull()
        {
            Assert.Throws<ArgumentNullException>(() => ctftools.Format.Binary.ToText(null));
        }

        [Theory]
        [InlineData("01010201")]
        [InlineData("01A01010")]
        [InlineData("2010")]
        public void ToText_ShouldThrowArgumentException_ForNonBinaryCharacters(string input)
        {
            Assert.Throws<ArgumentException>(() => ctftools.Format.Binary.ToText(input));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("010")]
        [InlineData("0100100001")] //10 bits
        [InlineData("01001000010")] // mixed with space, still not multiple of8
        public void ToText_ShouldThrowArgumentException_ForInvalidLength(string input)
        {
            Assert.Throws<ArgumentException>(() => ctftools.Format.Binary.ToText(input));
        }
    }
}