using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Response
{
    [DataContract]
    public class VMCategoryTypeDetailsResponse : BaseResponse
    {
        [DataMember]
        public VMCategoryTypeDetails CategoryType { get; set; }
    }
}
