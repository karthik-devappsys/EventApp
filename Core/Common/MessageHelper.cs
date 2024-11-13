using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EventManageApp.Core.Common
{
    public class MessageHelper
    {
        private readonly ITempDataDictionary _tempData;

        // Inject ITempDataDictionary into the service
        public MessageHelper(ITempDataDictionary tempData)
        {
            _tempData = tempData;
        }

        // Set Error Message
        public bool SetErrorMessage(string message)
        {
            _tempData["ErrorMessage"] = message;
            return false;
        }

        // Set Success Message
        public bool SetSuccessMessage(string message)
        {
            _tempData["SuccessMessage"] = message;
            return true;
        }

        // Get Error Message
        public string? GetErrorMessage()
        {
            return _tempData["ErrorMessage"]?.ToString();
        }

        // Get Success Message
        public string? GetSuccessMessage()
        {
            return _tempData["SuccessMessage"]?.ToString();
        }

        // Clear Messages
        public void ClearMessages()
        {
            _tempData.Remove("ErrorMessage");
            _tempData.Remove("SuccessMessage");
        }
    }
}