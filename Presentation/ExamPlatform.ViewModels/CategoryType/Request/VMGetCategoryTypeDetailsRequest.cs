using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Request
{
    [DataContract]
    public class VMGetCategoryTypeDetailsRequest
    {
        [DataMember]
        public int CategoryTypeId { get; set; }
    }
}
