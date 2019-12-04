using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Request
{
    [DataContract]
    public class VMGetCategoryTypeListRequest
    {
        [DataMember]
        public ICollection<VMCategoryTypeDetails> CategoryTypes { get; set; }
    }
}
