using System.Collections;

namespace MyGenerics.Tests;


public class MyListTests
{
    [Fact]
    public void Constructor_ShouldInitializeMyList_WhenProvidedAnArray()
    {
        // Arrange
        MyList<int> myList;

        // Act
        myList = new MyList<int>(new int[] { 1, 2, 3 });

        // Assert
        Assert.Equal(3, myList.Count);
    }
    
    [Fact]
    public void Add_ShouldAddItem()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        
        // Act
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Assert
        for (var i = 0; i < myList.Count; i++)
            Assert.Equal(i, myList[i]);
    }
    
    [Fact]
    public void Add_ShouldIncrementCount()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();

        // Act
        for (var i = 0; i < 1000; i++)
            myList.Add(i);

        // Assert
        Assert.Equal(1000, myList.Count);
    }

    [Fact]
    public void MyListGet_ShouldRetrieveItem_WhenValidIndex()
    {
        // Arrange
        MyList<int> myList = new MyList<int> { 1 };

        // Act
        int result = myList[0];

        // Assert
        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void MyListGet_ShouldThrowIndexOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (int i = 0; i < 1000; i++)
            myList.Add(i);

        // Act
        object Function() => myList[index];

        // Assert
        Assert.Throws<IndexOutOfRangeException>((Func<object>)Function);
    }

    [Fact]
    public void MyListSet_ShouldSetItem_WhenValidIndex()
    {
        // Arrange
        MyList<int> myList = new MyList<int> { 1 };

        // Act
        myList[0] = 2;
        
        // Assert
        Assert.Equal(2, myList[0]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void MyListSet_ShouldThrowIndexOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (int i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        void Action() => myList[index] = 0;

        // Assert
        Assert.Throws<IndexOutOfRangeException>((Action)Action);
    }

    [Fact]
    public void MyListEnumerator_ShouldEnumerateItems()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);

        // Act
        int count = 0;
        foreach (var _ in myList)
            count++;

        // Assert
        Assert.Equal(1000, count);
        for (var i = 0; i < 1000; i++)
            Assert.Equal(i, myList[i]);
    }

    [Fact]
    public void MyListGetEnumerator_ShouldEnumerateWithIEnumerableGetEnumerator()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        var count = TestGetEnumeratorHelperMethod(myList);

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
    public void Clear_ShouldClearMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        myList.Clear();
        
        // Assert
        Assert.Equal(0, myList.Count);
    }

    [Fact]
    public void Contains_ShouldReturnTrue_WhenItemExistsInMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        var result = myList.Contains(500);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenItemDoesNotExistInMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);

        // Act
        var result = myList.Contains(-1);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(500)]
    public void CopyTo_ShouldCopyMyListToAnArray(int index)
    {
        // Arrange
        var array = new int[1000];
        var myList = new MyList<int>();
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
    public void Remove_ShouldRemoveItemFromMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        myList.Remove(500);
        
        // Assert
        Assert.Equal(999, myList.Count);
        Assert.NotEqual(500, myList[500]);
    }

    [Fact]
    public void Remove_ShouldReturnTrue_WhenItemExistsInMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        var result = myList.Remove(500);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExistInMyList()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        var result = myList.Remove(-1);
        
        // Assert
        Assert.Equal(1000, myList.Count);
        Assert.False(result);
    }

    [Fact]
    public void RemoveAt_ShouldRemoveItemFromMyListAtSpecifiedIndex()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
            
        // Act
        myList.RemoveAt(500);
        
        // Assert
        Assert.False(myList.Contains(500));
        Assert.Equal(999, myList.Count);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void RemoveAt_ShouldThrowArgumentOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        void Action() => myList.RemoveAt(index);
        
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
        MyList<int> myList = new MyList<int>();
        for (int i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        int index = myList.IndexOf(item);
        
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
        MyList<int> myList = new MyList<int>();
        for (int i = 0; i < 1280; i++)
            myList.Add(i);
        
        // Act
        myList.Insert(index, -1);
        
        // Assert
        Assert.Equal(1281, myList.Count);
        Assert.Equal(-1, myList[index]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void Insert_ShouldThrowArgumentOutOfRangeException_WhenInvalidIndex(int index)
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (int i = 0; i < 1000; i++)
            myList.Add(i);
        
        // Act
        void Action() => myList.Insert(index, -1);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    [Fact]
    public void IsReadOnly_ShouldReturnFalse()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        
        // Act
        var result = myList.IsReadOnly;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        MyList<int> myList = new MyList<int>();
        for (var i = 1; i <= 10; i++)
            myList.Add(i);
        
        // Act
        var result = myList.ToString();
        
        // Assert
        Assert.Equal("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", result);
    }
}
