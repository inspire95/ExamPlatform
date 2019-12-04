using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Request
{
    [DataContract]
    public class VMUpdateCategoryTypeRequest : VMCreateCategoryTypeRequest
    {
        [DataMember]
        public int CategoryTypeId { get; set; }
    }
}
