using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Request
{
    [DataContract]
    public class VMCreateCategoryTypeRequest
    {
        [DataMember]
        public string Name { get; set; }
    }
}
