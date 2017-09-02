using System;
using Xunit;
using csmatio.io;

namespace CSMatIO.Tests
{
  public class UnicodeTests
  {
    private const string TestDataDirectory = "test-data";

    private static string CorrectPath(string filename) {
      return System.IO.Path.Combine(TestDataDirectory, filename);
    }

    [Fact]
    public void TestASCII()
    {
      var reader = new MatFileReader(CorrectPath("ascii.mat"));
      var data = reader.Content["s"];
      Assert.True(data.IsChar);
      var text = data as csmatio.types.MLChar;
      Assert.Equal("abc", text.GetString(0));
    }

    [Fact]
    public void TestUnicode()
    {
      var reader = new MatFileReader(CorrectPath("unicode.mat"));
      var data = reader.Content["s"];
      Assert.True(data.IsChar);
      var text = data as csmatio.types.MLChar;
      Assert.Equal("\x5fc5\x30d5", text.GetString(0));
    }
    [Fact]
    public void TestUnicodeWide()
    {
      var reader = new MatFileReader(CorrectPath("unicode-wide.mat"));
      var data = reader.Content["s"];
      Assert.True(data.IsChar);
      var text = data as csmatio.types.MLChar;
      Assert.Equal("\xd83c\xdf46", text.GetString(0));      
    }
  }
}
