using System.Collections;
using Xunit;

namespace Visoft.Collections.Tests;


public class FListTests
{
    [Fact]
    public void Constructor_ShouldInitializeFList_WhenProvidedAnArray()
    {
        // Arrange
        FList<int> fList;

        // Act
        fList = new FList<int>(new int[] { 1, 2, 3 });

        // Assert
        Assert.Equal(3, fList.Count);
    }
    
    [Fact]
    public void Add_ShouldAddItem()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        
        // Act
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Assert
        for (var i = 0; i < fList.Count; i++)
            Assert.Equal(i, fList[i]);
    }
    
    [Fact]
    public void Add_ShouldIncrementCount()
    {
        // Arrange
        FList<int> fList = new FList<int>();

        // Act
        for (var i = 0; i < 1000; i++)
            fList.Add(i);

        // Assert
        Assert.Equal(1000, fList.Count);
    }

    [Fact]
    public void FListGet_ShouldRetrieveItem_WhenValidIndex()
    {
        // Arrange
        FList<int> fList = new FList<int> { 1 };

        // Act
        int result = fList[0];

        // Assert
        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void FListGet_ShouldThrowIndexOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (int i = 0; i < 1000; i++)
            fList.Add(i);

        // Act
        object Function() => fList[index];

        // Assert
        Assert.Throws<IndexOutOfRangeException>((Func<object>)Function);
    }

    [Fact]
    public void FListSet_ShouldSetItem_WhenValidIndex()
    {
        // Arrange
        FList<int> fList = new FList<int> { 1 };

        // Act
        fList[0] = 2;
        
        // Assert
        Assert.Equal(2, fList[0]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void FListSet_ShouldThrowIndexOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (int i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        void Action() => fList[index] = 0;

        // Assert
        Assert.Throws<IndexOutOfRangeException>((Action)Action);
    }

    [Fact]
    public void FListEnumerator_ShouldEnumerateItems()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);

        // Act
        int count = 0;
        foreach (var _ in fList)
            count++;

        // Assert
        Assert.Equal(1000, count);
        for (var i = 0; i < 1000; i++)
            Assert.Equal(i, fList[i]);
    }

    [Fact]
    public void FListGetEnumerator_ShouldEnumerate_WithIEnumerableGetEnumerator()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        var count = TestGetEnumeratorHelperMethod(fList);

        // Assert
        Assert.Equal(1000, count);

        int TestGetEnumeratorHelperMethod(IEnumerable enumerator)
        {
            var counter = 0;
            foreach (var _ in enumerator)
                counter++;
            return counter;
        }
    }

    [Fact]
    public void Clear_ShouldClearFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        fList.Clear();
        
        // Assert
        Assert.Equal(0, fList.Count);
    }

    [Fact]
    public void Contains_ShouldReturnTrue_WhenItemExistsInFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        var result = fList.Contains(500);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenItemDoesNotExistInFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);

        // Act
        var result = fList.Contains(-1);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(500)]
    public void CopyTo_ShouldCopyFListToAnArray(int index)
    {
        // Arrange
        var array = new int[1000];
        var myList = new FList<int>();
        for (var i = 0; i < 1000; i++)
        {
            if (i < 100)
                myList.Add(i);
            array[i] = i;
        }

        // Act
        myList.CopyTo(array, index);
        
        // Assert
        for (var i = 0; i < myList.Count; i++)
            Assert.Equal(array[index + i], myList[i]);
    }

    [Fact]
    public void Remove_ShouldRemoveItemFromFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        fList.Remove(500);
        
        // Assert
        Assert.Equal(999, fList.Count);
        Assert.NotEqual(500, fList[500]);
    }

    [Fact]
    public void Remove_ShouldReturnTrue_WhenItemExistsInFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        var result = fList.Remove(500);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExistInFList()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        var result = fList.Remove(-1);
        
        // Assert
        Assert.Equal(1000, fList.Count);
        Assert.False(result);
    }

    [Fact]
    public void RemoveAt_ShouldRemoveItemAtSpecifiedIndex()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
            
        // Act
        fList.RemoveAt(500);
        
        // Assert
        Assert.False(fList.Contains(500));
        Assert.Equal(999, fList.Count);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void RemoveAt_ShouldThrowArgumentOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        void Action() => fList.RemoveAt(index);
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    [Theory]
    [InlineData(500, 500)]
    [InlineData(-1, -1)]
    [InlineData(1001, -1)]
    public void IndexOf_ShouldReturnIndexOfSpecifiedItem(int item, int expected)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (int i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        int index = fList.IndexOf(item);
        
        // Assert
        Assert.Equal(expected, index);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(500)]
    [InlineData(1280)]
    public void Insert_ShouldInsertItemAtSpecifiedIndex(int index)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (int i = 0; i < 1280; i++)
            fList.Add(i);
        
        // Act
        fList.Insert(index, -1);
        
        // Assert
        Assert.Equal(1281, fList.Count);
        Assert.Equal(-1, fList[index]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void Insert_ShouldThrowArgumentOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (int i = 0; i < 1000; i++)
            fList.Add(i);
        
        // Act
        void Action() => fList.Insert(index, -1);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    [Fact]
    public void IsReadOnly_ShouldReturnFalse()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        
        // Act
        var result = fList.IsReadOnly;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        FList<int> fList = new FList<int>();
        for (var i = 1; i <= 10; i++)
            fList.Add(i);
        
        // Act
        var result = fList.ToString();
        
        // Assert
        Assert.Equal("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", result);
    }
}
