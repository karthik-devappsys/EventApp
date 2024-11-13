namespace EventManageApp.Core.Common
{
    public class FileUploadHandler
    {
        private readonly string _uploadFolderPath;

        public FileUploadHandler(string uploadFolderPath)
        {
            _uploadFolderPath = uploadFolderPath;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is not provided");
            }

            // Get the file extension and create a unique file name
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";

            // Combine the base upload path with the specified folder
            var folderPath = Path.Combine(_uploadFolderPath, folder);

            // Ensure the upload folder exists
            Directory.CreateDirectory(folderPath); // Create the user-specific folder if it doesn't exist

            var filePath = Path.Combine(folderPath, fileName);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName; // Return the unique file name
        }

        public bool DeleteFile(string folder, string fileName)
        {
            var filePath = Path.Combine(_uploadFolderPath, folder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true; // Successfully deleted
            }
            return false; // File not found
        }
    }
}