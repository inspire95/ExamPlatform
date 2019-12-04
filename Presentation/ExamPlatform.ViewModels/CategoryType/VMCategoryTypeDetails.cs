using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType
{
    [DataContract]
    public class VMCategoryTypeDetails : VMCategoryTypeItemList
    { 
        [DataMember]
        public bool IsActive { get; set; }
    }
}
