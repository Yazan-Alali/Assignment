using Business.Interfaces;
using Business.Services;

namespace Tests.Services;

public class FileService_Tests
{
    [Fact]

    public void SaveContentToFile_ShouldSaveContentToFile()
    {
        // arrange
        var content = "test";
        var fileName = $"{Guid.NewGuid().ToString()}.json";
        IFileService fileService = new FileService(fileName);


        try
        {

            // act
            var result = fileService.SaveToFile(content);

            // Assert 
            Assert.True(result);

        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
        
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnContentFromFile()
    {
        // arrange
        var content = "test";
        var fileName = @$"{Guid.NewGuid().ToString()}.json";
        File.WriteAllText(fileName, content);
        
        IFileService fileService = new FileService(fileName);
        fileService.SaveToFile(content);
       
        
        try
        {

            // act
            var result = fileService.GetContentFromFile();

            // Assert 
            Assert.Equal(content, result);

        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
}