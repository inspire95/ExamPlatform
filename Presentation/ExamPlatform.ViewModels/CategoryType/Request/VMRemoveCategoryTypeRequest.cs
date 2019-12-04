using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Request
{
    [DataContract]
    public class VMRemoveCategoryTypeRequest
    {
        [DataMember]
        public int CategoryTypeId { get; set; }
    }
}
